using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;

namespace ImageSorter.ViewModel
{
    public class ViewModelBase : BindableBase
    {
        [Dependency]
        public IEventAggregator EventAggregator { get; set; }
    }
}
