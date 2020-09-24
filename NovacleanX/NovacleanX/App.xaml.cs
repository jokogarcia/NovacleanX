using Prism;
using Prism.Ioc;
using NovacleanX.ViewModels;
using NovacleanX.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using NovacleanX.Services.AppConfiguration;
using NovacleanX.Services.ExceptionsManager;

namespace NovacleanX
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
            
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();

            //Services
            containerRegistry.RegisterInstance<IAppConfigurationService>(BuildAppConfiguration());
            containerRegistry.Register<IExceptionsManager, ExceptionsManager>();

            containerRegistry.RegisterForNavigation<SimpleModalPage, SimpleModalPageViewModel>();
        }
        private IAppConfigurationService BuildAppConfiguration()
        {
            var buildMode = "release";

#if DEBUG
            buildMode = "debug";
#endif

            using (var stream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream($"NovacleanX.Configurations.config.{buildMode}.json"))
            using (var streamReader = new StreamReader(stream))
            {
                var jsonTextReader = new JsonTextReader(streamReader);
                var jsonSerializer = new JsonSerializer();
                return jsonSerializer.Deserialize<AppConfigurationService>(jsonTextReader);
            }
        }
    }
}
