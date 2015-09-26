using System.Collections.Generic;
using ImageSorter.Model;

namespace ImageSorter.Contracts
{
    public interface IImageSearcher
    {
        IEnumerable<Image> GetImagesFrom(string path);
    }
}
