namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using University_frontend.Services.DataServices;
    using University_frontend.Services.SystemServices;
    using University_frontend.ViewModels.DataModels;
    using Xamarin.Forms;

    public class UserListViewModel : BaseViewModel
    {
        private readonly IUserService userService;

        private IEnumerable<UserDataModel> users;

        public IEnumerable<UserDataModel> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged();
            }
        }

        private UserDataModel selectedUser;

        public UserDataModel SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged();
            }
        }

        public UserListViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            IUserService userService)
            : base(navigationService, dialogService, mapper)
        {
            this.userService = userService;
        }

        public ICommand AddUserClicked => new Command(AddUserClickedAction);

        public ICommand EditUserClicked => new Command(EditUserClickedAction);

        private async void AddUserClickedAction()
        {
            if (!AccountService.IsAdminOrTeacher())
            {
                await dialogService.ShowDialog("Unauthorized access", "Error", "Ok");
                return;
            }

            await navigationService.NavigateToAsync<UserViewModel>();
        }

        private async void EditUserClickedAction()
        {
            if (!AccountService.IsAdminOrTeacher())
            {
                await dialogService.ShowDialog("Unauthorized access", "Error", "Ok");
                return;
            }

            if (SelectedUser == null)
            {
                dialogService.ShowToast("Select a user.");
                return;
            }

            await navigationService.NavigateToAsync<UserViewModel>(SelectedUser);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            try
            {
                var users = await userService.GetAll();
                Users = mapper.Map<IEnumerable<UserDataModel>>(users);
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }

            IsBusy = false;

            if (!Users.Any())
            {
                await dialogService.ShowDialog("No users to display", "Information", "Ok");
            }
        }
    }
}
