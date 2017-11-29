using System;
using Autofac;
using AzureFunctionsLogging.Extensions;
using Microsoft.Extensions.Configuration;

namespace AzureFunctionsLogging.Log4net
{
    internal class ServiceProvider
    {
        private static readonly IConfigurationRoot _config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        public IContainer Instance => _lazyContainer.Value;
        private static readonly Lazy<IContainer> _lazyContainer = new Lazy<IContainer>(Build);

        static IContainer Build()
        {
            _config.ConfigureStackify();

            var builder = new ContainerBuilder();

            builder.RegisterInstance(_config);

            builder.AddLogging();
            builder.RegisterType<FunctionProcessor>();

            return builder.Build();
        }
    }
}
