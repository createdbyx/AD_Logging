namespace Codefarts.AutoDownloader.Plugins
{
    using System.ComponentModel.Composition;
    using Codefarts.AutoDownloader;
    using Codefarts.AutoDownloader.Interfaces;
    using Codefarts.Logging;

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

        public ApplicationModel Application
        {
            get
            {
                return this.applicationModel;
            }
        }

        public void Connect(ApplicationModel appModel)
        {
            this.applicationModel = appModel;
            this.logger = new ADLogger(appModel);
            // Logging.LoggedEntry += this.Logging_LoggedEntry;
            Logging.Repositories.Add(this.logger);
        }

        //private void Logging_LoggedEntry(object sender, LogModelEventArgs e)
        //{
        //    this.applicationModel.Logging.Logs.Add(e.Message);
        //}

        public void Disconnect()
        {
            // Logging.LoggedEntry -= this.Logging_LoggedEntry;
            Logging.Repositories.Remove(this.logger);
            this.logger = null;
            this.applicationModel = null;
        }
    }
}