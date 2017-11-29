using System;
using log4net;
using log4net.Core;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsLogging.Log4net
{
    /// <summary>
    /// log4net ILog → TraceWriter Adapater
    /// </summary>
    /// 
    /// <inheritdoc />
    public class ILogTraceWriterAdapter : ILog
    {
        private readonly TraceWriter _traceWriter;
        private readonly ILog _log;
        public ILogger Logger => _log.Logger;

        public ILogTraceWriterAdapter(Type caller, TraceWriter traceWriter)
        {
            _log = LogManager.GetLogger(caller);
            _traceWriter = traceWriter;
        }

        public void Debug(object message)
        {
            _traceWriter.Verbose(message.ToString());
            _log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _traceWriter.Verbose(message.ToString());
            _log.Debug(message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _traceWriter.Verbose(string.Format(format));
            _log.DebugFormat(format, args);
        }

        public void DebugFormat(string format, object arg0)
        {
            _traceWriter.Verbose(string.Format(format));
            _log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            _traceWriter.Verbose(string.Format(format));
            _log.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _traceWriter.Verbose(string.Format(format));
            _log.DebugFormat(format, arg0, arg1, arg2);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _traceWriter.Verbose(string.Format(format));
            _log.DebugFormat(provider, format, args);
        }

        public void Info(object message)
        {
            _traceWriter.Info(message.ToString());
            _log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _traceWriter.Info(message.ToString());
            _log.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _traceWriter.Info(string.Format(format));
            _log.InfoFormat(format, args);
        }

        public void InfoFormat(string format, object arg0)
        {
            _traceWriter.Info(string.Format(format));
            _log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            _traceWriter.Info(string.Format(format));
            _log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _traceWriter.Info(string.Format(format));
            _log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _traceWriter.Info(string.Format(format));
            _log.InfoFormat(provider, format, args);
        }

        public void Warn(object message)
        {
            _traceWriter.Warning(message.ToString());
            _log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _traceWriter.Warning(message.ToString());
            _log.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _traceWriter.Warning(string.Format(format));
            _log.WarnFormat(format, args);
        }

        public void WarnFormat(string format, object arg0)
        {
            _traceWriter.Warning(string.Format(format));
            _log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            _traceWriter.Warning(string.Format(format));
            _log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _traceWriter.Warning(string.Format(format));
            _log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _traceWriter.Warning(string.Format(format));
            _log.WarnFormat(provider, format, args);
        }

        public void Error(object message)
        {
            _traceWriter.Error(message.ToString());
            _log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            _traceWriter.Error(message.ToString(), exception);
            _log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _traceWriter.Error(string.Format(format));
            _log.ErrorFormat(format, args);
        }

        public void ErrorFormat(string format, object arg0)
        {
            _traceWriter.Error(string.Format(format));
            _log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _traceWriter.Error(string.Format(format));
            _log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _traceWriter.Error(string.Format(format));
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _traceWriter.Error(string.Format(format));
            _log.ErrorFormat(provider, format, args);
        }

        public void Fatal(object message)
        {
            _traceWriter.Error(message.ToString());
            _log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _traceWriter.Error(message.ToString());
            _log.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _traceWriter.Error(format);
            _log.FatalFormat(format, args);
        }

        public void FatalFormat(string format, object arg0)
        {
            _traceWriter.Error(format);
            _log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            _traceWriter.Error(format);
            _log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _traceWriter.Error(format);
            _log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _traceWriter.Error(format);
            _log.FatalFormat(provider, format, args);
        }

        public bool IsDebugEnabled => _log.IsDebugEnabled;
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
    }
}
