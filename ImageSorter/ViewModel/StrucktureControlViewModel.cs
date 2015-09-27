using System.Collections.ObjectModel;
using System.Linq;
using ImageSorter.Contracts;
using ImageSorter.Events;
using ImageSorter.Model;
using Universial.Core.Extensions;

namespace ImageSorter.ViewModel
{
    public class StrucktureControlViewModel : ViewModelBase
    {
        public const string UnsortedFolderName = "Unsortiert";
        private readonly IImageSearcher _imageSearcher;
        private readonly ObservableCollection<ExplorerItem> _explorerItems;
        public ReadOnlyObservableCollection<ExplorerItem> ExplorerItems { get; }

        public StrucktureControlViewModel(IImageSearcher imageSearcher)
        {
            _imageSearcher = imageSearcher;
            _explorerItems = new ObservableCollection<ExplorerItem>();
            ExplorerItems = new ReadOnlyObservableCollection<ExplorerItem>(_explorerItems);
            _explorerItems.Add(new Folder(UnsortedFolderName));
        }

        protected override void RegsiterEvents()
        {
            base.RegsiterEvents();
            EventAggregator.GetEvent<NewSourcePathEvent>().Subscribe(OnNewSourcePath);
        }

        private void OnNewSourcePath(string path)
        {
            _explorerItems
                .FirstOrDefault(x => x.Name.Equals(UnsortedFolderName))
                .CastToType<Folder>()
                .ExplorerItems
                .AddRange(_imageSearcher.GetImagesFrom(path));
        }
    }
}
