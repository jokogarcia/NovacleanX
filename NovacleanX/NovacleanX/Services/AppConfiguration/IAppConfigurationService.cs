namespace NovacleanX.Services.AppConfiguration
{
    public interface IAppConfigurationService
    {
        string AppCenterDroidConnectionString { get; set; }
        string AppCenterIOSConnectionString { get; set; }
        string NotificationHubWebApiUrl { get; set; }
        string AndroidNotificationChannelName { get; set; }
        string AndroidNotificationChannelId { get; set; }
        string IntermexServiceURL { get; set; }
        string DownloadAppUrl { get; set; }
        int SourceApp { get; set; }
        string IdentityBaseUrl { get; set; }
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string FacebookClientId { get; set; }
        string FacebookAuthorizeUrl { get; set; }
        string FacebookRedirectUrl { get; set; }

        string PartnerId { get; set; }
        string ChannelId { get; set; }

    }
}
