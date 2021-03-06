﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using DiscogsClient.Internal;
using JetBrains.Annotations;
using Newtonsoft.Json;
using DisClient = DiscogsClient.DiscogsClient;

namespace libDiscogsDesktop.Services
{
    public static class DiscogsService
    {
        private static DisClient client;

        private static Dictionary<int, DiscogsRelease> releaseCache = new Dictionary<int, DiscogsRelease>();

        private static Dictionary<int, DiscogsMaster> masterCache = new Dictionary<int, DiscogsMaster>();

        private static Dictionary<int, DiscogsArtist> artistCache = new Dictionary<int, DiscogsArtist>();

        private static Dictionary<int, DiscogsLabel> labelCache = new Dictionary<int, DiscogsLabel>();

        public static string ApplicationFolder { get; private set; }

        public static string CacheFolder => Path.Combine(ApplicationFolder ?? "", "Cache");

        public static int MaxItems { get; set; }

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
                if (File.Exists(Path.Combine(CacheFolder, nameof(releaseCache))))
                {
                    try
                    {
                        releaseCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsRelease>>(File.ReadAllText(Path.Combine(CacheFolder, nameof(releaseCache))));
                    }
                    catch
                    {
                        //ignore;
                    }
                }

                if (File.Exists(Path.Combine(CacheFolder, nameof(masterCache))))
                {
                    try
                    {
                        masterCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsMaster>>(File.ReadAllText(Path.Combine(CacheFolder, nameof(masterCache))));
                    }
                    catch
                    {
                        //ignore;
                    }
                }

                if (File.Exists(Path.Combine(CacheFolder, nameof(artistCache))))
                {
                    try
                    {
                        artistCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsArtist>>(File.ReadAllText(Path.Combine(CacheFolder, nameof(artistCache))));
                    }
                    catch
                    {
                        //ignore;
                    }
                }

                if (File.Exists(Path.Combine(CacheFolder, nameof(labelCache))))
                {
                    try
                    {
                        labelCache =
                            JsonConvert.DeserializeObject<Dictionary<int, DiscogsLabel>>(File.ReadAllText(Path.Combine(CacheFolder, nameof(labelCache))));
                    }
                    catch
                    {
                        //ignore;
                    }
                }
            }
        }

        public static void ClearCache()
        {
            if (!Directory.Exists(CacheFolder))
            {
                return;
            }

            foreach (string cacheFile in Directory.GetFiles(CacheFolder))
            {
                try
                {
                    File.Delete(cacheFile);
                }
                catch
                {
                    //ignore
                }
            }
        }

        public static void SetToken(string token)
        {
            client = new DisClient(new TokenAuthenticationInformation(token), "DiscogsDesktop", 10000);
            TokenChanged?.Invoke();
        }

        public static DiscogsIdentity GetUser()
        {
            return client.GetUserIdentityAsync().Result;
        }

        public static DiscogsMaster GetMasterRelease(int id)
        {
            if (!masterCache.ContainsKey(id))
            {
                masterCache.Add(id, client.GetMasterAsync(id).Result);
                saveCache(masterCache, nameof(masterCache));
            }

            return masterCache[id];
        }

        public static DiscogsRelease GetRelease(int id)
        {
            if (!releaseCache.ContainsKey(id))
            {
                releaseCache.Add(id, client.GetReleaseAsync(id).Result);
                saveCache(releaseCache, nameof(releaseCache));
            }

            return releaseCache[id];
        }

        public static DiscogsArtist GetArtist(int id)
        {
            if (!artistCache.ContainsKey(id))
            {
                artistCache.Add(id, client.GetArtistAsync(id).Result);
                saveCache(artistCache, nameof(artistCache));
            }

            return artistCache[id];
        }

        public static DiscogsLabel GetLabel(int id)
        {
            if (!labelCache.ContainsKey(id))
            {
                labelCache.Add(id, client.GetLabelAsync(id).Result);
                saveCache(labelCache, nameof(labelCache));
            }

            return labelCache[id];
        }

        public static void GetCollectionReleases(string username, ObservableCollection<DiscogsCollectionRelease> observable)
        {
            client.GetCollectionReleases(username, MaxItems).Subscribe(observable.Add);
        }

        public static void Search(string pattern, ObservableCollection<DiscogsSearchResult> observable)
        {
            client.Search(new DiscogsSearch { query = pattern }, MaxItems).Subscribe(observable.Add);
        }

        public static void GetLabelReleases(int id, ObservableCollection<DiscogsLabelRelease> observable)
        {
            client.GetAllLabelReleases(id, MaxItems).Subscribe(observable.Add);
        }

        public static void GetArtistReleases(int id, ObservableCollection<DiscogsArtistRelease> observable)
        {
            client.GetArtistRelease(id, new DiscogsSortInformation { sort = DiscogsArtistSortType.year, sort_order = DiscogsSortOrderType.desc }, MaxItems).Subscribe(observable.Add);
        }

        public static void DownloadImage(DiscogsImage image, string filepath)
        {
            using (Stream stream = File.Create(filepath))
            {
                client.DownloadImageAsync(image, stream).Wait();
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
    }
}