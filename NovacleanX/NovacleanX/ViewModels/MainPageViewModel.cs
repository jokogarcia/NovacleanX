using NovacleanX.DependencyServices;
using NovacleanX.Helpers;
using NovacleanX.Services.ExceptionsManager;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovacleanX.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string loginEmail;
        private string loginPassword;
        private IAuth _authService;

        public string LoginEmail { get => loginEmail; set => SetProperty(ref loginEmail, value); }
        public string LoginPassword { get => loginPassword; set => SetProperty(ref loginPassword, value); }
        public DelegateCommand LoginCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService,
            IExceptionsManager exceptionsManager,
            IAuth authService
            )
            : base(navigationService, exceptionsManager)
        {
            _authService = authService;
            Title = "Main Page";
            LoginCommand = new DelegateCommand(LoginCommand_Execute);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            LoginEmail = "jokogarcia@gmail.com";
            LoginPassword = "joko183";
        }
        private async void LoginCommand_Execute()
        {
            try
            {
                var authToken = await _authService.LoginWithEmailPassword(LoginEmail, LoginPassword);
                DebugLogger.Log(authToken, "AuthToken");
            }catch (Exception ex)
            {
                await HandleException(ex);
            }
        }
    }
}
