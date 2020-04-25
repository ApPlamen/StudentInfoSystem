namespace University_frontend.ViewModels
{
    using AutoMapper;
    using University_frontend.Services.SystemServices;

    class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper)
            : base(navigationService, dialogService, mapper) { }
    }
}
