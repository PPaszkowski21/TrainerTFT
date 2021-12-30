using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace AT.Services.Helpers
{
    public static class ImageManager
    {
        public static byte[] GetImage(string baseImagePath, string championName)
        {
            string partialName = championName;
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(baseImagePath);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
            byte[] championImage;

            try
            {
                Image image = Image.FromFile(filesInDir[0].ToString());
                using MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, image.RawFormat);
                championImage = memoryStream.ToArray();
                return championImage;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
