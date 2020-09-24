using NovacleanX.Services.ExceptionsManager;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NovacleanX.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private IExceptionsManager _exceptionsManager;
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isModal;
        protected virtual bool IsModal
        {
            get { return _isModal; }
            set { SetProperty(ref _isModal, value); }
        }

        public ViewModelBase(INavigationService navigationService, IExceptionsManager exceptionsManager)
        {
            NavigationService = navigationService;
            _exceptionsManager = exceptionsManager;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
        protected async Task HandleException(Exception ex)
        {
            await _exceptionsManager.ManageException(ex);
        }
    }
}
