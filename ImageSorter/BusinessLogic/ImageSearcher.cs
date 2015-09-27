using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageSorter.Contracts;
using ImageSorter.Model;

namespace ImageSorter.BusinessLogic
{
    public class ImageSearcher : IImageSearcher
    {
        public IList<string> SearchPatterns { get; set; }

        public ImageSearcher()
        {
            SearchPatterns = new List<string>
            {
                "*.jpg",
                "*.png",
                "*.bmp"
            };
        }

        public IEnumerable<Image> GetImagesFrom(string path)
        {
            foreach (var searchPattern in SearchPatterns)
            {
                foreach (var filePath in Directory.GetFileSystemEntries(path, searchPattern, SearchOption.AllDirectories))
                {
                    var image = new Image(Path.GetFileName(filePath))
                    {
                        CreationDate = File.GetLastWriteTime(filePath),
                        FullPath = filePath
                    };
                    yield return image;
                }
            }
        }
    }
}
