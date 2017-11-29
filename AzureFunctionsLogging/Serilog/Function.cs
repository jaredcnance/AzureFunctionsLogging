using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AzureFunctionsLogging.Extensions;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.AzureWebJobsTraceWriter;
using StackifyLib.Utils;

namespace AzureFunctionsLogging.Serilog
{
    public static class Function
    {
        private static readonly IConfigurationRoot _config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

        static Function()
        {
            _config.ConfigureStackify();
        }

        public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter traceWriter)
        {
            var body = await req.Content.ReadAsStringAsync();

            var log = new LoggerConfiguration()
                .WriteTo.RollingFile("log-{Date}.txt")
                .WriteTo.TraceWriter(traceWriter)
                .WriteTo.Stackify()
                .CreateLogger();

            log.Information("serilog: " + body);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
