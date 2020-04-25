namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System.Threading.Tasks;
    using University_frontend.Services.SystemServices;

    public class MainViewModel : BaseViewModel
    {
        private MenuViewModel menuViewModel;

        public MainViewModel(
            INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            MenuViewModel menuViewModel)
            : base(navigationService, dialogService, mapper)
        {
            this.menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => menuViewModel;
            set
            {
                menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
            (
                menuViewModel.InitializeAsync(data),
                navigationService.NavigateToAsync<HomeViewModel>()
            );
        }
    }
}
