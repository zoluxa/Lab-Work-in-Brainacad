using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace Airport.Desktop
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = new ModuleCatalog();
            moduleCatalog.AddModule(typeof(AirlineModule.AirlineModuleModule));
            return moduleCatalog;
        }
    }
}
