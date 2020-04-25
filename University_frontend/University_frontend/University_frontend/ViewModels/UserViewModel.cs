namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using University_frontend.Enums;
    using University_frontend.Extensions;
    using University_frontend.Services.DataServices;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.SystemServices;
    using University_frontend.ViewModels.DataModels;
    using Xamarin.Forms;

    public class UserViewModel : BaseViewModel
    {
        private readonly IUserService userService;

        private UserDataModel user;

        public UserDataModel User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            IUserService userService)
            : base(navigationService, dialogService, mapper)
        {
            this.userService = userService;
        }

        public ICommand SaveUserClicked => new Command(SaveUserClickedAction);

        public ICommand DeleteUserClicked => new Command(DeleteUserClickedAction);

        private async void SaveUserClickedAction()
        {
            var errorMessage = ValidateHelper.Validate(user);

            if (!String.IsNullOrEmpty(errorMessage))
            {
                await dialogService.ShowDialog(errorMessage.ToString().Trim(), "Error", "Ok");
                return;
            }

            try
            {
                await userService.Save(mapper.Map<UserInputDataModel>(User));
                dialogService.ShowToast("User edited successfully.");
                await navigationService.NavigateBackAsync();
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }
        }

        private async void DeleteUserClickedAction()
        {
            try
            {
                await userService.Delete(User.Id);
                dialogService.ShowToast("User deleted successfully.");
                await navigationService.NavigateBackAsync();
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }
        }

        public override async Task InitializeAsync(object selectedUser)
        {
            IsBusy = true;

            if (selectedUser == null)
            {
                User = new UserDataModel();
                IsBusy = false;
                return;
            }

            try
            {
                var user = await userService.Get(((UserDataModel)selectedUser).Id);
                User = mapper.Map<UserDataModel>(user);
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }

            IsBusy = false;
        }
    }
}
