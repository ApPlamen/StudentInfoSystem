namespace University_frontend.ViewModels
{
    using AutoMapper;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using University_frontend.Extensions;
    using University_frontend.Services.DataServices;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.SystemServices;
    using University_frontend.ViewModels.DataModels;
    using Xamarin.Forms;

    public class SubjectViewModel : BaseViewModel
    {
        private readonly ISubjectService subjectService;

        private SubjectDataModel subject;

        public SubjectDataModel Subject
        {
            get => subject;
            set
            {
                subject = value;
                OnPropertyChanged();
            }
        }

        public SubjectViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            ISubjectService subjectService)
            : base(navigationService, dialogService, mapper)
        {
            this.subjectService = subjectService;
        }

        public ICommand SaveSubjectClicked => new Command(SaveSubjectClickedAction);

        public ICommand DeleteSubjectClicked => new Command(DeleteSubjectClickedAction);

        private async void SaveSubjectClickedAction()
        {
            var errorMessage = ValidateHelper.Validate(subject);

            if (!String.IsNullOrEmpty(errorMessage))
            {
                await dialogService.ShowDialog(errorMessage.ToString().Trim(), "Error", "Ok");
                return;
            }

            try
            {
                await subjectService.Save(mapper.Map<SubjectInputDataModel>(Subject));
                dialogService.ShowToast("Subject edited successfully.");
                await navigationService.NavigateBackAsync();
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }
        }

        private async void DeleteSubjectClickedAction()
        {
            try
            {
                await subjectService.Delete((int)Subject.Id);
                dialogService.ShowToast("Subject deleted successfully.");
                await navigationService.NavigateBackAsync();
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }
        }

        public override async Task InitializeAsync(object selectedSubject)
        {
            IsBusy = true;

            if (selectedSubject == null)
            {
                Subject = new SubjectDataModel();
                IsBusy = false;
                return;
            }

            try
            {
                var subject = await subjectService.Get((int)((SubjectDataModel)selectedSubject).Id);
                Subject = mapper.Map<SubjectDataModel>(subject);
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
