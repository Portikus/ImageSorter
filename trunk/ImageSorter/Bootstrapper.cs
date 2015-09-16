using System;
using System.Windows;
using ImageSorter.View;
using ImageSorter.ViewModel;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;

namespace ImageSorter
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.DataContext = ServiceLocator.Current.GetInstance<ShellViewModel>();
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            Container.RegisterInstance<IEventAggregator>(Container.Resolve<EventAggregator>());
            var _test = new ContainerControlledLifetimeManager();
        }
    }
}
