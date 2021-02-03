using System;
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
    public static class ExportHelper
    {
        public static void ExportReleasesOld(DataRow[] dataRows)
        {
            ExportReleasesOld(
                dataRows
                    .Where(d => d.Table.Columns.Contains("id") &&
                                (!d.Table.Columns.Contains("type") || d["type"].ToString() == "release"))
                    .Select(d => int.Parse(d["id"].ToString())).ToArray()
            );
        }

        public static void ExportReleasesOld(int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                return;
            }

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string folder = dialog.SelectedPath;

                ProgressDialog progressDialog = new ProgressDialog { InfoText = $"exporting releases to {dialog.SelectedPath}" };

                Task.Run(() =>
                {
                    for (int i = 0; i < ids.Length; i++)
                    {
                        DiscogsRelease release = DiscogsService.GetRelease(ids[i]);
                        MediaService.ExportRelease(release, folder);
                        progressDialog?.SetProgress(ProgressHelper.GetProgressPercentage(i + 1, ids.Length));
                    }
                });

                progressDialog.Show();
            }
        }
    }
}