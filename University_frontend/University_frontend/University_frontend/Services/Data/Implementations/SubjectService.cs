namespace University_frontend.Services.DataServices
{
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public class SubjectService : BaseCRUDService<SubjectViewDataModel, SubjectInputDataModel, int>, ISubjectService
    {
        private static string path = "subject";

        public SubjectService() : base(path)
        { }
    }
}
