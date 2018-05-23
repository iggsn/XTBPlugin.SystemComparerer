using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;

namespace CRMP.XTBPlugin.SystemComparer.AppCode
{
    internal class Telemetry : IDisposable
    {
        private readonly TelemetryClient _tmClient;
        private readonly SystemComparerPluginControl _pluginControl;

        public Telemetry(SystemComparerPluginControl pluginControl)
        {
            _pluginControl = pluginControl;

            _tmClient = new TelemetryClient
            {
                InstrumentationKey = "TO_BE_REPLACED"
            };

            _tmClient.Context.Session.Id = Guid.NewGuid().ToString();
            _tmClient.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
            _tmClient.Context.Component.Version = SystemComparerPlugin.CurrentVersion;
            _tmClient.Context.Device.Id = SystemComparerPlugin.Name;
        }

        public void LogEvent(string action)
        {
            LogData(TelemetryEventType.Event, action);
        }

        public void LogDependency(string action)
        {
            LogData(TelemetryEventType.Dependency, action);
        }

        public void LogTrace(string action)
        {
            LogData(TelemetryEventType.Trace, action);
        }

        public void LogException(string action, Exception exception)
        {
            LogData(TelemetryEventType.Exception, action, exception);
        }

        public void LogData(TelemetryEventType eventType, string action, Exception exception = null)
        {
            if (!_pluginControl.Settings.AllowLogUsage.GetValueOrDefault(false))
            {
                return;
            }

            switch (eventType)
            {
                case TelemetryEventType.Event:
                    _tmClient.TrackEvent(action, AssembleProperties());
                    break;
            }
        }

        public void Flush()
        {
            _tmClient.Flush();
        }

        private Dictionary<string, string> AssembleProperties(string action = null)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>
            {
                {  "plugin" , _tmClient.Context.Device.Id }
            };

            if (action != null)
            {
                properties.Add("action", action);
            }

            return properties;
        }

        public void Dispose()
        {
            _tmClient?.Flush();
            System.Threading.Thread.Sleep(1000);

            _pluginControl?.Dispose();
        }
    }
}

