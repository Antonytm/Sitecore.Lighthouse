using Foundation.Lighthouse.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Foundation.Lighthouse.DI
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(ILighthouseRunner), typeof(LighthouseRunner));
            serviceCollection.AddScoped(typeof(IFiles), typeof(Files));
            serviceCollection.AddScoped(typeof(IUrls), typeof(Urls));
            serviceCollection.AddScoped(typeof(IPaths), typeof(Paths));
            serviceCollection.AddScoped(typeof(ISitecoreData), typeof(SitecoreData));
            serviceCollection.AddMvcControllersInCurrentAssembly();
        }
    }
}