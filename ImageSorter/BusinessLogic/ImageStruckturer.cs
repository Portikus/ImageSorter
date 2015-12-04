using System.Collections.Generic;
using System.Linq;
using ImageSorter.Model;

namespace ImageSorter.BusinessLogic
{
    public static class ImageStruckturer
    {

        public static Folder AccessFilterDefinition(this IList<ExplorerItem> explorerItems,
            FilterDefinition filterDefinition)
        {
            var folder = new Folder(filterDefinition.Name);
            foreach (var image in explorerItems.OfType<Image>())
            {
                if (image.CreationDate > filterDefinition.StartDate && image.CreationDate < filterDefinition.EndDate)
                {
                    folder.ExplorerItems.Add(image);
                }
            }
            foreach (var image in folder.ExplorerItems)
            {
                explorerItems.Remove(image);
            }
            return folder;
        }
    }
}
