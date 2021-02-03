using System;
using JetBrains.Annotations;

namespace libDiscogsDesktop.Models
{
    public sealed class VideoModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public VideoModel(string url, string title)
        {
            this.Url = url;
            this.Title = title.Replace("\n", " ").Replace("\r", " ");
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}