using Microsoft.Practices.Unity;

namespace ImageSorter.ViewModel
{
    public class ShellViewModel : ViewModelBase
    {
        #region Properties

        [Dependency]
        public FilterDefinitionsViewModel FilterDefinitionViewModel { get; set; }

        [Dependency]
        public PathControlViewModel PathControlViewModel { get; set; }
        
        [Dependency]
        public StrucktureControlViewModel StrucktureControlViewModel { get; set; }

        #endregion

    }
}
