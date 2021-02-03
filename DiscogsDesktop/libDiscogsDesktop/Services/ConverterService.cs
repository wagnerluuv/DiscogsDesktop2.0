using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NReco.VideoConverter;

namespace libDiscogsDesktop.Services
{
    public static class ConverterService
    {
        public static bool ConvertVideoToMp3(string videoFilePath, string mp3FilePath, string failurePath)
        {
            try
            {
                FFMpegConverter converter = new FFMpegConverter();

                converter.ConvertMedia(videoFilePath, mp3FilePath, "mp3");

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

                try
                {
                    File.Create(failurePath).Close();
                }
                catch 
                {
                    //ignore
                }

                return false;
            }
        }
    }
}
