using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;

namespace ImageSorter.ViewModel
{
    public abstract class ViewModelBase : BindableBase
    {
        private IEventAggregator _eventAggregator;

        [Dependency]
        public IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
            set
            {
                _eventAggregator = value; 
                RegsiterEvents();
            }
        }

        protected virtual void RegsiterEvents() { }
    }
}
