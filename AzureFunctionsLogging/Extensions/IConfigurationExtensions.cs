using Microsoft.Extensions.Configuration;
using StackifyLib;

namespace AzureFunctionsLogging.Extensions
{
    public static class IConfigurationExtensions
    {
        public static IConfigurationRoot ConfigureStackify(this IConfigurationRoot config)
        {
            Config.SetConfiguration(config);
            Config.AppName = config["Stackify.AppName"];
            Config.ApiKey = config["Stackify.ApiKey "];
            Config.Environment = config["Stackify.Environment"];
            return config;
        }
    }
}
