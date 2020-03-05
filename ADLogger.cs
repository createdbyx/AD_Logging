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
            var model = new LogModel()
            {
                Type = type,
                Message = message,
                Category = category,
                TimeStamp = DateTime.Now,
            };

            this.appModel.Logging.Logs.Add(model);
        }
    }
}
