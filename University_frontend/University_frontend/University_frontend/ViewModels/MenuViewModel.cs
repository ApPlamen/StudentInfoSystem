namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using University_frontend.Enums;
    using University_frontend.Models;
    using University_frontend.Services.SystemServices;
    using Xamarin.Forms;

    public class MenuViewModel : BaseViewModel
    {
        private ObservableCollection<MainMenuItem> menuItems;

        public MenuViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper)
            : base(navigationService, dialogService, mapper)
        {
            MenuItems = new ObservableCollection<MainMenuItem>();
            LoadMenuItems();
        }

        public ICommand MenuItemTappedCommand => new Command(OnMenuItemTapped);

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => menuItems;
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }

        private void OnMenuItemTapped(object menuItemTappedEventArgs)
        {
            var menuItem = ((menuItemTappedEventArgs as ItemTappedEventArgs)?.Item as MainMenuItem);

            if (menuItem != null && menuItem.MenuText == "Log out")
            {
                navigationService.ClearBackStack();
            }

            var type = menuItem?.ViewModelToLoad;
            navigationService.NavigateToAsync(type);
        }

        private void LoadMenuItems()
        {
            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Home",
                ViewModelToLoad = typeof(MainViewModel),
                MenuItemType = MenuItemType.Home
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Grades",
                ViewModelToLoad = typeof(GradeListViewModel),
                MenuItemType = MenuItemType.Grades
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Users",
                ViewModelToLoad = typeof(UserListViewModel),
                MenuItemType = MenuItemType.Users
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Subjects",
                ViewModelToLoad = typeof(SubjectListViewModel),
                MenuItemType = MenuItemType.Subjects
            });

            MenuItems.Add(new MainMenuItem
            {
                MenuText = "Log out",
                ViewModelToLoad = typeof(LogInViewModel),
                MenuItemType = MenuItemType.Logout
            });
        }
    }
}
