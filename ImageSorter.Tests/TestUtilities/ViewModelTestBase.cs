using ImageSorter.Contracts;
using ImageSorter.ViewModel;
using Microsoft.Practices.Unity;
using NSubstitute;
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
            Container.RegisterInstance(Substitute.For<IImageSearcher>());
            EventAggregator = Container.Resolve<IEventAggregator>();
        }
    }
}
