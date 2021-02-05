using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DiscogsClient.Data.Result;
using Newtonsoft.Json;
using RestSharp;

namespace DiscogsClient.Client
{
    public class Discogs
    {
        private readonly RestClient client;

        private DiscogsCustomFields customFields;

        private DiscogsIdentity user;

        public Discogs(string token)
        {
            client = new RestClient("https://api.discogs.com");

            client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {"Authorization", $"Discogs token={token}"},
                {"Accept-Encoding", "gzip"}
            });
        }

        public DiscogsIdentity GetUser()
        {
            return user ?? (user = Get<DiscogsIdentity>("oauth/identity"));
        }

        public DiscogsMaster GetMaster(int masterId)
        {
            return Get<DiscogsMaster>($"masters/{masterId}");
        }

        public DiscogsRelease GetRelease(int releaseId)
        {
            return Get<DiscogsRelease>($"releases/{releaseId}");
        }

        public DiscogsArtist GetArtist(int artistId)
        {
            return Get<DiscogsArtist>($"artists/{artistId}");
        }

        public DiscogsLabel GetLabel(int labelId)
        {
            return Get<DiscogsLabel>($"labels/{labelId}");
        }

        public DiscogsCustomFields GetCustomFields()
        {
            return customFields ??
                   (customFields = Get<DiscogsCustomFields>($"/users/{GetUser().username}/collection/fields"));
        }

        public DiscogsCollectionRelease[] GetCollectionReleases()
        {
            return GetReleases<DiscogsCollectionRelease>($"/users/{GetUser().username}/collection/folders/0/releases")
                .ToArray();
        }

        public DiscogsLabelRelease[] GetLabelReleases(int labelId)
        {
            return GetReleases<DiscogsLabelRelease>($"labels/{labelId}/releases").ToArray();
        }

        public DiscogsArtistRelease[] GetArtistReleases(int artistId)
        {
            return GetReleases<DiscogsArtistRelease>($"artists/{artistId}/releases").ToArray();
        }

        private T Get<T>(string url)
        {
            IRestResponse restResponse = client.Execute(new RestRequest(url, Method.GET));

            int rateLimitRemaining = Convert.ToInt32(restResponse.Headers
                .FirstOrDefault(parameter => parameter.Name == "X-Discogs-Ratelimit-Remaining")?.Value);

            if (rateLimitRemaining < 30) Thread.Sleep(1000);

            T data = JsonConvert.DeserializeObject<T>(restResponse.Content);

            return data;
        }

        private IEnumerable<T> GetReleases<T>(string url)
        {
            while (url != null)
            {
                DiscogsPaginableReleases<T> paginable = Get<DiscogsPaginableReleases<T>>(url);

                foreach (T result in paginable.GetResults()) yield return result;

                url = paginable.pagination.urls.next;
            }
        }

        public byte[] DownloadImage(DiscogsImage image)
        {
            return client.DownloadData(new RestRequest(image.resource_url));
        }
    }
}