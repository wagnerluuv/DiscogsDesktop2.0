﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DiscogsClient.Client;
using DiscogsClient.Data.Result;
using Newtonsoft.Json;

namespace libDiscogsDesktop.Services
{
    public static class DiscogsService
    {
        private static Discogs client;

        private static Dictionary<int, DiscogsRelease> releaseCache = new Dictionary<int, DiscogsRelease>();

        private static Dictionary<int, DiscogsMaster> masterCache = new Dictionary<int, DiscogsMaster>();

        private static Dictionary<int, DiscogsArtist> artistCache = new Dictionary<int, DiscogsArtist>();

        private static Dictionary<int, DiscogsLabel> labelCache = new Dictionary<int, DiscogsLabel>();

        private static Dictionary<string, DiscogsCollectionRelease[]> collectionCache = new Dictionary<string, DiscogsCollectionRelease[]>();

        private static Dictionary<string, HashSet<string>> likes = new Dictionary<string, HashSet<string>>();

        private static object saveLikeLock = new object();

        public static string ApplicationFolder { get; private set; }

        public static string CacheFolder => Path.Combine(ApplicationFolder ?? "", "Cache");

        public static string LikesFolder => Path.Combine(ApplicationFolder ?? "", "Likes");

        public static string ExportFieldInTitle { get; set; }

        public static event Action TokenChanged;

        public static void SetApplicationFolder(string folder)
        {
            ApplicationFolder = folder;

            if (!Directory.Exists(CacheFolder))
            {
                Directory.CreateDirectory(CacheFolder);
            }
            else
            {
                if (File.Exists(Path.Combine(CacheFolder, nameof(collectionCache))))
                    try
                    {
                        collectionCache =
                            JsonConvert.DeserializeObject<Dictionary<string, DiscogsCollectionRelease[]>>(
                                File.ReadAllText(Path.Combine(CacheFolder, nameof(collectionCache))));
                    }
                    catch
                    {
                        //ignore;
                    }

                if (File.Exists(Path.Combine(CacheFolder, nameof(releaseCache))))
                    try
                    {
                        releaseCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsRelease>>(
                                File.ReadAllText(Path.Combine(CacheFolder, nameof(releaseCache))));
                    }
                    catch
                    {
                        //ignore;
                    }

                if (File.Exists(Path.Combine(CacheFolder, nameof(masterCache))))
                    try
                    {
                        masterCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsMaster>>(
                                File.ReadAllText(Path.Combine(CacheFolder, nameof(masterCache))));
                    }
                    catch
                    {
                        //ignore;
                    }

                if (File.Exists(Path.Combine(CacheFolder, nameof(artistCache))))
                    try
                    {
                        artistCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsArtist>>(
                                File.ReadAllText(Path.Combine(CacheFolder, nameof(artistCache))));
                    }
                    catch
                    {
                        //ignore;
                    }

                if (File.Exists(Path.Combine(CacheFolder, nameof(labelCache))))
                    try
                    {
                        labelCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsLabel>>(
                                File.ReadAllText(Path.Combine(CacheFolder, nameof(labelCache))));
                    }
                    catch
                    {
                        //ignore;
                    }
            }

            if (!Directory.Exists(LikesFolder))
            {
                Directory.CreateDirectory(LikesFolder);
            }
            else
            {
                if (File.Exists(Path.Combine(LikesFolder, nameof(likes))))
                    try
                    {
                        likes =
                            JsonConvert.DeserializeObject<Dictionary<string, HashSet<string>>>(
                                File.ReadAllText(Path.Combine(LikesFolder, nameof(likes))));
                    }
                    catch
                    {
                        //ignore;
                    }

            }
        }

        public static void ClearCache()
        {
            if (!Directory.Exists(CacheFolder)) return;

            foreach (string cacheFile in Directory.GetFiles(CacheFolder))
                try
                {
                    File.Delete(cacheFile);
                }
                catch
                {
                    //ignore
                }
        }

        public static void SetToken(string token)
        {
            client = new Discogs(token);
            TokenChanged?.Invoke();
        }

        public static DiscogsIdentity GetUser()
        {
            return client.GetUser();
        }

        public static DiscogsCustomField[] GetCustomFields()
        {
            return client.GetCustomFields().fields;
        }

        public static DiscogsMaster GetMasterRelease(int id)
        {
            if (!masterCache.ContainsKey(id))
            {
                masterCache.Add(id, client.GetMaster(id));
                saveCache(masterCache, nameof(masterCache));
            }

            return masterCache[id];
        }

        public static DiscogsRelease GetRelease(int id)
        {
            if (!releaseCache.ContainsKey(id))
            {
                releaseCache.Add(id, client.GetRelease(id));
                saveCache(releaseCache, nameof(releaseCache));
            }

            return releaseCache[id];
        }

        public static DiscogsArtist GetArtist(int id)
        {
            if (!artistCache.ContainsKey(id))
            {
                artistCache.Add(id, client.GetArtist(id));
                saveCache(artistCache, nameof(artistCache));
            }

            return artistCache[id];
        }

        public static DiscogsLabel GetLabel(int id)
        {
            if (!labelCache.ContainsKey(id))
            {
                labelCache.Add(id, client.GetLabel(id));
                saveCache(labelCache, nameof(labelCache));
            }

            return labelCache[id];
        }

        public static void GetCollectionReleases(ObservableCollection<DiscogsCollectionRelease> observable, bool overwriteCache)
        {
            string username = GetUser().username;

            if (overwriteCache && collectionCache.ContainsKey(username))
            {
                collectionCache.Remove(username);
            }
            if (!collectionCache.ContainsKey(username))
            {
                collectionCache.Add(username, client.GetCollectionReleases(username));
                saveCache(collectionCache, nameof(collectionCache));
            }

            foreach (DiscogsCollectionRelease discogsCollectionRelease in collectionCache[username])
                observable.Add(discogsCollectionRelease);
        }

        public static void Search(string pattern, ObservableCollection<DiscogsSearchResult> observable)
        {
            //client.Search(new DiscogsSearch { query = pattern }, MaxItems).Subscribe(observable.Add);
        }

        public static void GetLabelReleases(int id, ObservableCollection<DiscogsLabelRelease> observable)
        {
            DiscogsLabelRelease[] releases = client.GetLabelReleases(id);
            foreach (DiscogsLabelRelease discogsLabelRelease in releases) observable.Add(discogsLabelRelease);
        }

        public static void GetArtistReleases(int id, ObservableCollection<DiscogsArtistRelease> observable)
        {
            DiscogsArtistRelease[] releases = client.GetArtistReleases(id);
            foreach (DiscogsArtistRelease discogsArtistRelease in releases) observable.Add(discogsArtistRelease);
        }

        public static void DownloadImage(DiscogsImage image, string filepath)
        {
            File.WriteAllBytes(filepath, client.DownloadImage(image));
        }

        public static bool LikesTrack(DiscogsRelease release, string track)
        {
            lock (likes)
            {
                string key = $"{release.id}_{track}";

                string username = GetUser().username;

                return likes.ContainsKey(username) && likes[username].Contains(key);
            }
        }

        public static void LikeTrack(DiscogsRelease release, string track, bool like)
        {
            lock (likes)
            {
                string key = $"{release.id}_{track}";

                string username = GetUser().username;

                if (!likes.ContainsKey(username))
                {
                    likes.Add(username, new HashSet<string>());
                }

                if (like && !likes[username].Contains(key))
                {
                    likes[username].Add(key);
                }
                else if (!like && likes[username].Contains(key))
                {
                    likes[username].Remove(key);
                }

                saveLikes();
            }
        }

        private static void saveCache(object cache, string name)
        {
            Task.Run(() =>
            {
                try
                {
                    File.WriteAllText(Path.Combine(CacheFolder, name), JsonConvert.SerializeObject(cache));
                }
                catch
                {
                    //ignore
                }
            });
        }

        private static void saveLikes()
        {
            Task.Run(() =>
            {
                lock (saveLikeLock)
                {
                    try
                    {
                        File.WriteAllText(Path.Combine(LikesFolder, nameof(likes)), JsonConvert.SerializeObject(likes));
                    }
                    catch
                    {
                        //ignore
                    }
                }
            });
        }
    }
}