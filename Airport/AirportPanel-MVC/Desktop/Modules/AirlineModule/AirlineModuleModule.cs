using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Airport.Desktop.AirlineModule
{
    public class AirlineModuleModule : IModule
    {
        IUnityContainer _container;
        IRegionManager _regionManager;

        public AirlineModuleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("ToolbarRegion", typeof(ToolbarView));
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(ContentView));
        }
    }
}
