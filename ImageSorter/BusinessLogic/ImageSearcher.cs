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
            var files = new List<string>();
            foreach (var searchPattern in SearchPatterns)
            {
                files.AddRange(Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories));
            }
            return files.Select(file => new Image(file));
        }
    }
}
