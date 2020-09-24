namespace NovacleanX.Services.AppConfiguration
{
    public class AppConfigurationService : IAppConfigurationService
    {
        public string AppCenterDroidConnectionString { get; set; }
        public string AppCenterIOSConnectionString { get; set; }
        public string NotificationHubWebApiUrl { get; set; }
        public string AndroidNotificationChannelName { get; set; }
        public string AndroidNotificationChannelId { get; set; }
        public string IntermexServiceURL { get; set; }
        public int SourceApp { get; set; }
        public string DownloadAppUrl { get; set; }
        public string IdentityBaseUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string FacebookClientId { get; set; }
        public string FacebookAuthorizeUrl { get; set; }
        public string FacebookRedirectUrl { get; set; }
        public string PartnerId { get; set; }
        public string ChannelId { get; set; }

    }
}
