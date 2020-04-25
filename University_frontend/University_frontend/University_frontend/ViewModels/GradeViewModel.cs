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

    public class GradeViewModel : BaseViewModel
    {
        private readonly IGradeService gradeService;
        private readonly IUserService userService;
        private readonly ISubjectService subjectService;

        private GradeDataModel grade;

        public GradeDataModel Grade
        {
            get => grade;
            set
            {
                grade = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<UserDataModel> students;

        public IEnumerable<UserDataModel> Students
        {
            get => students;
            set
            {
                students = value.Where(u => u.RoleId.Equals(RolesDictionary.RoleStrings.Student)).ToList();
                OnPropertyChanged();
            }
        }

        public UserDataModel SelectedStudent
        {
            get
            {
                if (Students == null) return null;

                var student = students.Where(u => u.Id == Grade.StudentId).FirstOrDefault();
                return student;
            }
            set
            {
                Grade.StudentId = value.Id;
                OnPropertyChanged();
            }
        }

        private IEnumerable<UserDataModel> teachers;

        public IEnumerable<UserDataModel> Teachers
        {
            get => teachers;
            set
            {
                teachers = value.Where(u => u.RoleId.Equals(RolesDictionary.RoleStrings.Teacher)).ToList();
                OnPropertyChanged();
            }
        }

        public UserDataModel SelectedTeacher
        {
            get
            {
                if (Teachers == null) return null;
                
                var student = teachers.Where(u => u.Id == Grade.TeacherId).FirstOrDefault();
                return student;
            }
            set
            {
                Grade.TeacherId = value.Id;
                OnPropertyChanged();
            }
        }

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

        public SubjectDataModel SelectedSubject
        {
            get
            {
                if (students == null) return null;
                
                var subject = subjects.Where(s => s.Id == Grade.SubjectId).FirstOrDefault();
                return subject;
            }
            set
            {
                Grade.SubjectId = (int)value.Id;
                OnPropertyChanged();
            }
        }

        public GradeViewModel(INavigationService navigationService,
            IDialogService dialogService,
            IMapper mapper,
            IGradeService gradeService,
            IUserService userService,
            ISubjectService subjectService)
            : base(navigationService, dialogService, mapper)
        {
            this.gradeService = gradeService;
            this.userService = userService;
            this.subjectService = subjectService;
        }

        public ICommand SaveGradeClicked => new Command(SaveGradeClickedAction);

        public ICommand DeleteGradeClicked => new Command(DeleteGradeClickedAction);

        private async void SaveGradeClickedAction()
        {
            var errorMessage = ValidateHelper.Validate(grade);

            if (!String.IsNullOrEmpty(errorMessage))
            {
                await dialogService.ShowDialog(errorMessage.ToString().Trim(), "Error", "Ok");
                return;
            }

            try
            {
                var grade = mapper.Map<GradeInputDataModel>(Grade);
                await gradeService.Save(grade);
                dialogService.ShowToast("Grade edited successfully.");
                await navigationService.NavigateBackAsync();
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }
        }

        private async void DeleteGradeClickedAction()
        {
            try
            {
                await gradeService.Delete((int)Grade.Id);
                dialogService.ShowToast("Grade deleted successfully.");
                await navigationService.NavigateBackAsync();
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }
        }

        public override async Task InitializeAsync(object selectedGrade)
        {
            IsBusy = true;

            try
            {
                var users = await userService.GetAll();
                Students = mapper.Map<IEnumerable<UserDataModel>>(users);
                Teachers = mapper.Map<IEnumerable<UserDataModel>>(users);
            }
            catch (Exception e)
            {
                dialogService.ShowToast("Something went wrong.");
                await navigationService.NavigateToAsync<LogInViewModel>();
            }

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

            if (selectedGrade == null)
            {
                Grade = new GradeDataModel();
                IsBusy = false;
                return;
            }

            try
            {
                var grade = await gradeService.Get((int)((GradeDataModel)selectedGrade).Id);
                Grade = mapper.Map<GradeDataModel>(grade);
                SelectedStudent = Students.First(s => s.Id.Equals(Grade.StudentId));
                SelectedSubject = Subjects.First(s => s.Id == Grade.SubjectId);
                SelectedTeacher = Teachers.First(s => s.Id.Equals(Grade.TeacherId));
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
