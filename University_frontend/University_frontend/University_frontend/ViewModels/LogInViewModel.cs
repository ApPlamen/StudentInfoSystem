namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System;
    using System.Windows.Input;
    using University_frontend.Extensions;
    using University_frontend.Services.DataServices;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.SystemServices;
    using Xamarin.Forms;

    public class LogInViewModel : BaseViewModel
    {
        private readonly IAccountService accountService;

        private LogInCredentialsInputDataModel credentials = new LogInCredentialsInputDataModel();

        public LogInCredentialsInputDataModel Credentials
        {
            get => credentials;
            set
            {
                credentials = value;
                OnPropertyChanged();
            }
        }

        public LogInViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            IAccountService accountService)
            : base(navigationService, dialogService, mapper)
        {
            this.accountService = accountService;
        }

        public ICommand LogInClicked => new Command(LogInClickedAction);

        private async void LogInClickedAction()
        {
            var errorMessage = ValidateHelper.Validate(Credentials);

            if (!String.IsNullOrEmpty(errorMessage))
            {
                await dialogService.ShowDialog(errorMessage.ToString().Trim(), "Error", "Ok");
                return;
            }

            try
            {
                await accountService.LogIn(Credentials);
            }
            catch(Exception e)
            {
                await dialogService.ShowDialog("Please check your email or password", "User not found!", "Ok");
                return;
            }

            await navigationService.NavigateToAsync<MainViewModel>();
        }
    }
}
