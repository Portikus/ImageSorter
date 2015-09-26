using System.Collections.ObjectModel;
using ImageSorter.Model;

namespace ImageSorter.ViewModel
{
    public class StrucktureControlViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ExplorerItem> _explorerItems;
        public ReadOnlyObservableCollection<ExplorerItem> ExplorerItems { get; }

        public StrucktureControlViewModel()
        {
            _explorerItems = new ObservableCollection<ExplorerItem>();
            ExplorerItems = new ReadOnlyObservableCollection<ExplorerItem>(_explorerItems);
        }
    }
}
