using Codefarts.AutoDownloader;
using Codefarts.AutoDownloader.Interfaces;
using Codefarts.AutoDownloader.Plugins;

namespace Codefarts.AutoDownloader.Plugins
{                                              
    using Codefarts.Logging;
    using System.ComponentModel.Composition;

    [Export(typeof(IGeneralPlugin))]
    [GeneralPlugin("Auto Downloader Logging")]
    public class ADPlugin : IGeneralPlugin
    {
        private ADLogger logger;
        private ApplicationModel applicationModel;

        public string Title
        {
            get
            {
                return "Auto Downloader Logging";
            }
        }

      
        public void Connect(ApplicationModel appModel)
        {
            this.applicationModel = appModel;
            this.logger = new ADLogger(appModel);
            // Logging.LoggedEntry += this.Logging_LoggedEntry;
            Logs.Instance.Repositories.Add(this.logger);
        }

        //private void Logging_LoggedEntry(object sender, LogModelEventArgs e)
        //{
        //    this.applicationModel.Logging.Logs.Add(e.Message);
        //}

        public void Disconnect()
        {
            // Logging.LoggedEntry -= this.Logging_LoggedEntry;
            Logs.Instance.Repositories.Remove(this.logger);
            this.logger = null;
            this.applicationModel = null;
        }
    }
}