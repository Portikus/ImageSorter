using System.Collections.ObjectModel;
using ImageSorter.Model;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;

namespace ImageSorter.ViewModel
{
    public class ShellViewModel : BindableBase
    {
        #region Properties

        private string _targetPath;
        private string _sourcePath;

        public string TargetPath
        {
            get { return _targetPath; }
            set
            {
                _targetPath = value;
                OnPropertyChanged();
            }
        }

        public string SourcePath
        {
            get { return _sourcePath; }
            set
            {
                _sourcePath = value;
                OnPropertyChanged();
            }
        }

        #region Dependencies

        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        [Dependency]
        public FilterDefinitionsViewModel FilterDefinitionViewModel { get; set; }
        

        #endregion

        #endregion

    }
}
