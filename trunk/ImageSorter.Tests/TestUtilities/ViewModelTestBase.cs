using ImageSorter.ViewModel;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Prism.Events;
using Universial.Core.Extensions.Unity;
using Universial.Test.UnityTestHelper;

namespace ImageSorter.Tests.TestUtilities
{
    [Ignore]
    public class ViewModelTestBase<T> : UnityTestBase<T> where T: ViewModelBase
    {
        protected IEventAggregator EventAggregator;

        protected override void SetUp()
        {
            base.SetUp();
            Container.RegisterInstance<IEventAggregator, EventAggregator>();
            EventAggregator = Container.Resolve<IEventAggregator>();
        }
    }
}
