using System.Linq;
using Autofac;
using Autofac.Core;
using log4net;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsLogging.Log4net
{
    /// <summary>
    /// Constructs the TraceWriterLogger by passing in the type of the calling
    /// class and the resolved TraceWriter instance
    /// </summary>
    /// 
    /// <inheritdoc />
    public class TraceWriterLoggingModule : Module
    {
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry,
            IComponentRegistration registration
        ) => registration.Preparing += OnComponentPreparing;

        private void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            e.Parameters = e.Parameters.Union(
                new[]
                {
                    new ResolvedParameter(
                        (p, i) => p.ParameterType == typeof(ILog),
                        (p, i) => new ILogTraceWriterAdapter(p.Member.DeclaringType, e.Context.Resolve<TraceWriter>())
                    ),
                });
        }
    }
}
