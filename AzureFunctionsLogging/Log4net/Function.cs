using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using Microsoft.Azure.WebJobs.Host;
using Autofac;
using AzureFunctionsLogging.Extensions;
using Microsoft.Azure.WebJobs;
using StackifyLib.Utils;

namespace AzureFunctionsLogging.Log4net
{
    public static class Function
    {
        private static readonly IContainer _serviceProvider = new ServiceProvider().Instance;

        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log, ExecutionContext context)
        {
            context.LoadLog4NetConfig();

            var body = await req.Content.ReadAsStringAsync();

            using (var scope = _serviceProvider.BeginLifetimeScope(b => b.RegisterInstance(log)))
            {
                var processor = scope.Resolve<FunctionProcessor>();
                processor.Process(body);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }

    public class FunctionProcessor
    {
        private readonly ILog _log;

        public FunctionProcessor(ILog log)
        {
            _log = log;
        }

        public void Process(string body) => _log.Info("log4net: " + body);
    }
}
