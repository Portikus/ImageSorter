using System.Collections.ObjectModel;
using System.Windows.Input;
using ImageSorter.Events;
using ImageSorter.Events.Args;
using ImageSorter.Model;
using Prism.Commands;

namespace ImageSorter.ViewModel
{
    public class FilterDefinitionsViewModel : ViewModelBase
    {
        #region Properties

        public ReadOnlyObservableCollection<FilterDefinition> FilterDefinitions { get; }

        public ICommand AddFilterDefinitionCommand => _addFilterDefinitionCommand;

        #endregion

        #region Fields

        private readonly ObservableCollection<FilterDefinition> _filterDefinitions;
        private readonly DelegateCommand _addFilterDefinitionCommand;

        #endregion

        public FilterDefinitionsViewModel()
        {
            _filterDefinitions = new ObservableCollection<FilterDefinition>();
            FilterDefinitions = new ReadOnlyObservableCollection<FilterDefinition>(_filterDefinitions);
            _addFilterDefinitionCommand = new DelegateCommand(_addFilterDefinitionCommandExecute);
        }

        #region Commands

        private void _addFilterDefinitionCommandExecute()
        {
            var newDefinition = new FilterDefinition();
            _filterDefinitions.Add(newDefinition);
            EventAggregator.GetEvent<NewFilterDefinitionEvent>().Publish(new FilterDefinitionEventArgs(newDefinition));
        }

        #endregion
    }
}