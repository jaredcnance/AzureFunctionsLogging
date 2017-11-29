using System.IO;
using Microsoft.Azure.WebJobs;

namespace AzureFunctionsLogging.Extensions
{
    public static class ExecutionContextExtensions
    {
        private static string _functionDirectory;

        public static void LoadLog4NetConfig(this ExecutionContext context)
        {
            // only load once -- will have to re-read when the AppDomain gets reloaded
            if (string.IsNullOrEmpty(_functionDirectory) == false)
                return;

            _functionDirectory = context.FunctionDirectory;

            var finfo = new FileInfo($"{_functionDirectory}\\Log4Net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(finfo);
        }
    }
}
