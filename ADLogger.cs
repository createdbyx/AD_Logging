using Codefarts.AutoDownloader;

namespace Codefarts.AutoDownloader.Plugins
{
    using System;
    using Codefarts.Logging;

    public class ADLogger : ILogging
    {
        private ApplicationModel appModel;

        public ADLogger(ApplicationModel appModel)
        {
            this.appModel = appModel;
        }

        public void Log(string message)
        {
            this.Log(LogEntryType.Generic, message, null);
        }

        public void Log(LogEntryType type, string message)
        {
            this.Log(type, message, null);
        }

        public void Log(string message, string category)
        {
            this.Log(LogEntryType.Generic, message, category);
        }

        public void Log(LogEntryType type, string message, string category)
        {
            var data = DateTime.Now.ToString("u");
            data += " " + type;
            data += " " + (string.IsNullOrWhiteSpace(category) ? string.Empty : "(" + category + ")");
            data += " " + message;

            //var ioc = Container.Default;
            //var platform = ioc.Resolve<IPlatformProvider>();
            // platform.OnUIThread(() => this.appModel.Logging.Logs.Add(data));
            this.appModel.Logging.Logs.Add(data);
        }
    }
}
