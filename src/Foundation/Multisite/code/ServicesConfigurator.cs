using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.Abstractions;
using Sitecore.DependencyInjection;
using Wedia.Foundation.Multisite.Placeholders;

namespace Wedia.Foundation.Multisite
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Replace(ServiceDescriptor.Singleton<BasePlaceholderCacheManager, SiteSpecificPlaceholderCacheManager>());
        }
    }
}