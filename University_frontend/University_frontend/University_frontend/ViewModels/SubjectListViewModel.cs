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

    public class SubjectListViewModel : BaseViewModel
    {
        private readonly ISubjectService subjectService;

        private IEnumerable<SubjectDataModel> subjects;

        public IEnumerable<SubjectDataModel> Subjects
        {
            get => subjects;
            set
            {
                subjects = value;
                OnPropertyChanged();
            }
        }

        private SubjectDataModel selectedSubject;

        public SubjectDataModel SelectedSubject
        {
            get => selectedSubject;
            set
            {
                selectedSubject = value;
                OnPropertyChanged();
            }
        }

        public SubjectListViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            ISubjectService subjectService)
            : base(navigationService, dialogService, mapper)
        {
            this.subjectService = subjectService;
        }

        public ICommand AddSubjectClicked => new Command(AddSubjectClickedAction);

        public ICommand EditSubjectClicked => new Command(EditSubjectClickedAction);

        private async void AddSubjectClickedAction()
        {
            await navigationService.NavigateToAsync<SubjectViewModel>();
        }

        private async void EditSubjectClickedAction()
        {
            if (SelectedSubject == null)
            {
                dialogService.ShowToast("Select a subject.");
                return;
            }

            await navigationService.NavigateToAsync<SubjectViewModel>(SelectedSubject);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            try
            {
                var subjects = await subjectService.GetAll();
                Subjects = mapper.Map<IEnumerable<SubjectDataModel>>(subjects);
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }

            IsBusy = false;

            if (!Subjects.Any())
            {
                await dialogService.ShowDialog("No subjects to display", "Information", "Ok");
            }
        }
    }
}
