using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscogsClient.Data.Result;
using RestSharp;

namespace DiscogsClient.Client
{
    public class Discogs
    {
        private readonly string Token;

        private readonly RestClient Client;

        public Discogs(string token)
        {
            this.Token = token;

            this.Client = new RestClient("https://api.discogs.com");

            Client.AddDefaultHeaders(new Dictionary<string, string>
            {
                {"Authorization", $"Discogs token={token}"},
                {"Accept-Encoding", "gzip"}
            });
        }

        public DiscogsIdentity GetUser()
        {
            DiscogsIdentity user = this.Client.Execute<DiscogsIdentity>(new RestRequest("oauth/identity", Method.GET)).Data;

            return user;
        }

        public DiscogsMaster GetMaster(int id)
        {
            throw new NotImplementedException();
        }

        public DiscogsRelease GetRelease(int id)
        {
            throw new NotImplementedException();
        }

        public DiscogsArtist GetArtist(int id)
        {
            throw new NotImplementedException();
        }

        public DiscogsLabel GetLabel(int id)
        {
            throw new NotImplementedException();
        }

        public void DownloadImage(DiscogsImage image, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
