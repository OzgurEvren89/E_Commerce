using Microsoft.Extensions.Configuration;

namespace Proje.Model.Services.ConfigurationService
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}
