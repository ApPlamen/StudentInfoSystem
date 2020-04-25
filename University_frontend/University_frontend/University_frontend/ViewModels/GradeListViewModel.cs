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

    public class GradeListViewModel : BaseViewModel
    {
        private readonly IGradeService gradeService;

        private IEnumerable<GradeDataModel> grades;

        public IEnumerable<GradeDataModel> Grades
        {
            get => grades;
            set
            {
                grades = value;
                OnPropertyChanged();
            }
        }

        private GradeDataModel selectedGrade;

        public GradeDataModel SelectedGrade
        {
            get => selectedGrade;
            set
            {
                selectedGrade = value;
                OnPropertyChanged();
            }
        }

        public GradeListViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IGradeService gradeService,
            IMapper mapper)
            : base(navigationService, dialogService, mapper)
        {
            this.gradeService = gradeService;
        }

        public ICommand AddGradeClicked => new Command(AddGradeClickedAction);

        public ICommand EditGradeClicked => new Command(EditGradeClickedAction);

        private async void AddGradeClickedAction()
        {
            await navigationService.NavigateToAsync<GradeViewModel>();
        }

        private async void EditGradeClickedAction()
        {
            if (SelectedGrade == null)
            {
                dialogService.ShowToast("Select a grade.");
                return;
            }
            await navigationService.NavigateToAsync<GradeViewModel>(SelectedGrade);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            try
            {
                var grades = await gradeService.GetAll();
                Grades = mapper.Map<IEnumerable<GradeDataModel>>(grades);
            }
            catch(Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }

            IsBusy = false;

            if (!Grades.Any())
            {
                await dialogService.ShowDialog("No grades to display", "Information", "Ok");
            }
        }
    }
}
