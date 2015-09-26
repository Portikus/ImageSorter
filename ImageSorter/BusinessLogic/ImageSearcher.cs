using System;
using System.Collections.Generic;
using ImageSorter.Contracts;
using ImageSorter.Model;

namespace ImageSorter.BusinessLogic
{
    public class ImageSearcher : IImageSearcher
    {
        public IEnumerable<Image> GetImagesFrom(string path)
        {
            throw new NotImplementedException();
        }
    }
}
