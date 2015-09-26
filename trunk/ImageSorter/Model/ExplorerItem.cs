using System.Collections.ObjectModel;

namespace ImageSorter.Model
{
    public abstract class ExplorerItem
    {
        public string Name { get; }

        protected ExplorerItem(string name)
        {
            Name = name;
        }
    }

    public class Folder : ExplorerItem
    {
        public ObservableCollection<ExplorerItem> ExplorerItems { get; }
        public Folder(string name) : base(name)
        {
            ExplorerItems = new ObservableCollection<ExplorerItem>();
        }
    }

    public class Image : ExplorerItem
    {
        public Image(string name) : base(name)
        {
        }
    }
}
