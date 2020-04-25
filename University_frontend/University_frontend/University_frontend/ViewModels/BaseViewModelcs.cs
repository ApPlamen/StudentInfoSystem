namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using University_frontend.Services.SystemServices;

    public class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigationService navigationService;
        protected readonly IDialogService dialogService;
        protected readonly IMapper mapper;

        public BaseViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.mapper = mapper;
        }

        private bool isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }
    }
}
