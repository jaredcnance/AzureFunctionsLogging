using Autofac;
using AzureFunctionsLogging.Log4net;

namespace AzureFunctionsLogging.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddLogging(this ContainerBuilder builder)
        {
            builder.RegisterModule<TraceWriterLoggingModule>();
            return builder;
        }
    }
}
