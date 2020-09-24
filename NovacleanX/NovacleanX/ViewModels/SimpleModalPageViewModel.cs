using NovacleanX.Helpers;
using NovacleanX.Models;
using NovacleanX.Resources;
using NovacleanX.Services.ExceptionsManager;
using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace NovacleanX.ViewModels
{
    public class SimpleModalPageViewModel : ViewModelBase
    {

        private string _modalTitle;
        public string ModalTitle
        {
            get { return _modalTitle; }
            set { SetProperty(ref _modalTitle, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _okButtonText;
        public string OkButtonText
        {
            get { return _okButtonText; }
            set { SetProperty(ref _okButtonText, value); }
        }

        private string _cancelButtonText;
        public string CancelButtonText
        {
            get { return _cancelButtonText; }
            set { SetProperty(ref _cancelButtonText, value); }
        }

        private bool _showOkButton;
        public bool ShowOkButton
        {
            get { return _showOkButton; }
            set { SetProperty(ref _showOkButton, value); }
        }

        private bool _showCancelButton;
        public bool ShowCancelButton
        {
            get { return _showCancelButton; }
            set { SetProperty(ref _showCancelButton, value); }
        }

        private Color _modalHeaderColor;
        public Color ModalHeaderColor
        {
            get { return _modalHeaderColor; }
            set { SetProperty(ref _modalHeaderColor, value); }
        }

        private DelegateCommand _okButtonCommand;
        public DelegateCommand OkButtonCommand
        {
            get => _okButtonCommand ?? (_okButtonCommand = new DelegateCommand(OkButtonCommand_Excecute));
        }

        private DelegateCommand _cancelButtonCommand;
        public DelegateCommand CancelButtonCommand
        {
            get => _cancelButtonCommand ?? (_cancelButtonCommand = new DelegateCommand(CancelButtonCommand_Excecute));
        }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public SimpleModalPageViewModel(INavigationService navigationService,
            IExceptionsManager exceptionsManager)
            : base(navigationService, exceptionsManager)
        {
          
        }

        public override void Initialize(INavigationParameters parameters)
        {
            SimpleModalInput simpleModalInput = null;
            IsModal = true;

            if (parameters.TryGetValue<SimpleModalInput>(NavigationParameterKeys.SIMPLE_MODAL_INPUT, out simpleModalInput))
            {
                ModalHeaderColor = simpleModalInput.IsErrorModal ?
                    (Color)Application.Current.Resources["ErrorTitleColor"] :
                    (Color)Application.Current.Resources["ModalTitleColor"];

                ModalTitle = simpleModalInput.TitleText;
                Message = simpleModalInput.Message;
                ShowOkButton = simpleModalInput.ShowOkButton;
                ShowCancelButton = simpleModalInput.ShowCancelButton;
                OkCommand = simpleModalInput.OkCommand;
                CancelCommand = simpleModalInput.CancelCommand;

                if (simpleModalInput.ShowOkButton)
                {
                    OkButtonText = simpleModalInput.OkButtonText;
                }

                if (simpleModalInput.ShowCancelButton)
                {
                    CancelButtonText = simpleModalInput.CancelButtonText;
                }
            }

            base.Initialize(parameters);
        }

        private async void OkButtonCommand_Excecute()
        {

            OkCommand?.Execute(null);

            await NavigationService.GoBackAsync();
        }

        private async void CancelButtonCommand_Excecute()
        {
            CancelCommand?.Execute(null);

            await NavigationService.GoBackAsync();
        }
    }
}
