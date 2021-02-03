using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.Dialogs;
using libDiscogsDesktop.Helper;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.Helper
{
    public static class DownloadHelper
    {
        public static void DownloadReleasesOld(DataRow[] rows)
        {
            DownloadReleasesOld(
                rows
                    .Where(d => d.Table.Columns.Contains("id") &&
                                (!d.Table.Columns.Contains("type") || d["type"].ToString() == "release"))
                    .Select(d => int.Parse(d["id"].ToString())).ToArray()
            );
        }

        public static void DownloadReleasesOld(int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return;
            }

            ProgressDialog progressDialog = new ProgressDialog { InfoText = "downloading releases" };

            Task.Run(() =>
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DiscogsRelease release = DiscogsService.GetRelease(ids[i]);

                    if (release.videos == null)
                    {
                        continue;
                    }

                    Task.WaitAll(release.videos.Select(v => Task.Run(() =>
                    {
                        MediaService.GetVideoFilePath(v.uri, out _, null);
                        MediaService.GetAudioFilePath(v.uri, out _);
                    })).ToArray());

                    progressDialog?.SetProgress(ProgressHelper.GetProgressPercentage(i + 1, ids.Length));
                }
            });

            progressDialog.Show();
        }
    }
}