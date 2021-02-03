using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.Dialogs;
using libDiscogsDesktop.Helper;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.Helper
{
    public enum Help
    {
        Download,
        Export
    }

    public static class ExportAndDownloadHelper
    {
        public static void ReleasesHelp(DataRowCollection dataRows, Help help)
        {
            ReleasesHelp(dataRows.Cast<DataRow>(), help);
        }

        public static void ReleasesHelp(IEnumerable<DataRow> dataRows, Help help)
        {
            ReleasesHelp(
                dataRows
                    .Where(d => d.Table.Columns.Contains("id") &&
                                (!d.Table.Columns.Contains("type") || d["type"].ToString() == "release"))
                    .Select(d => int.Parse(d["id"].ToString())).ToArray(),
                help
            );
        }

        public static void ReleasesHelp(int[] ids, Help help)
        {
            string folder = null;
            if (help == Help.Export)
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    folder = dialog.SelectedPath;
                }
            }

            ProgressDialog progressDialog = new ProgressDialog { InfoText = help.ToString() };

            Task.Run(() =>
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    DiscogsRelease release = DiscogsService.GetRelease(ids[i]);

                    if (release.videos == null || release.videos.Length == 0)
                    {
                        continue;
                    }

                    switch (help)
                    {
                        case Help.Download:
                            Task.WaitAll(release.videos.Select(v => Task.Run(() =>
                            {
                                MediaService.GetVideoFilePath(v.uri, out _, null);
                                MediaService.GetAudioFilePath(v.uri, out _);
                            })).ToArray());
                            break;

                        case Help.Export:
                            MediaService.ExportRelease(release, folder);
                            break;

                        default:
                            return;
                    }

                    progressDialog?.SetProgress(ProgressHelper.GetProgressPercentage(i + 1, ids.Length));
                }
            });

            progressDialog.Show();
        }
    }
}