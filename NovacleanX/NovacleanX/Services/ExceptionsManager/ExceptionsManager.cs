
using Microsoft.AppCenter.Crashes;
using NovacleanX.Helpers;
using NovacleanX.Models;
using NovacleanX.Resources;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace NovacleanX.Services.ExceptionsManager
{
    public class ExceptionsManager : IExceptionsManager
    {
        private readonly INavigationService _navigationService;

       

        public ExceptionsManager(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public async Task ManageException(Exception exception)
        {
            Crashes.TrackError(exception);
            DebugLogger.Log($"Exception {exception.ToString()}\nMessage: {exception.Message}", "ExceptionsManager");

            var simpleModalInput = new SimpleModalInput
            {
                IsErrorModal = true,
                TitleText = AppResources.ExceptionModal_Title,
                OkButtonText = AppResources.ExceptionModal_OkButton,
                ShowOkButton = true
            };

            if (exception is IOException)
            {

            }

            //if (exception is BackendServiceBusinessException)
            //{
            //    simpleModalInput.Message = !string.IsNullOrWhiteSpace(exception.Message) ? exception.Message : _localizationService.GetString("ExceptionModal_GenericError");
            //    var bsbe = exception as BackendServiceBusinessException;
            //    if (bsbe.ErrorCode == BackendServiceBusinessException.ErrorCodes.USER_ALREADY_EXISTS ||
            //        bsbe.ErrorCode == BackendServiceBusinessException.ErrorCodes.DEVICE_NOT_FOUND)
            //    {
            //        simpleModalInput.OkCommand = _logoutAndNavigateHomeCommand;
            //    }

            //}
            //else if (exception is MandatoryDocumentNotAcceptedException)
            //{
            //    simpleModalInput.Message = _localizationService.GetString("ExceptionModal_DocumentError");
            //}

            //else if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //{
            //    //Lack of connectivity 
            //    simpleModalInput.Message = _localizationService.GetString("ExceptionModal_LackOfConnectivityError");
            //}
            //else
            //{
            //    simpleModalInput.Message = _localizationService.GetString("ExceptionModal_GenericError");
            //}
            //if (exception is InvalidRefreshTokenException)
            //{
            //    //RefreshToken expired, redirect to login page
            //    simpleModalInput.OkCommand = _logoutAndNavigateHomeCommand;
            //    simpleModalInput.Message = _localizationService.GetString("ExceptionModal_SessionExpired");
            //}

            var navigationParameters = new NavigationParameters
            {
                { NavigationParameterKeys.SIMPLE_MODAL_INPUT, simpleModalInput }
            };

            await _navigationService.NavigateAsync(PagesKeys.SIMPLE_MODAL_PAGE, navigationParameters, true);
            

        }
    }
}
