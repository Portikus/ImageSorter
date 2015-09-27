using ImageSorter.Events;

namespace ImageSorter.ViewModel
{
    public class PathControlViewModel : ViewModelBase
    {
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
                _evaluateSourcePath();
            }
        }

        private void _evaluateSourcePath()
        {
            foreach (var path in SourcePath.Split(';'))
            {
                EventAggregator.GetEvent<NewSourcePathEvent>().Publish(path.Trim());
            }
        }
    }
}
