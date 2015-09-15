using System.Collections.ObjectModel;
using ImageSorter.Model;

namespace ImageSorter.ViewModel
{
    public class FilterDefinitionsViewModel
    {
        private ObservableCollection<FilterDefinition> _filterDefinitions;
        public ReadOnlyObservableCollection<FilterDefinition> FilterDefinitions { get; }

        public FilterDefinitionsViewModel()
        {
            _filterDefinitions = new ObservableCollection<FilterDefinition>();
            FilterDefinitions = new ReadOnlyObservableCollection<FilterDefinition>(_filterDefinitions);
        } 
    }
}