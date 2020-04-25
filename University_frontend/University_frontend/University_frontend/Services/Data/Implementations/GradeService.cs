namespace University_frontend.Services.DataServices
{
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public class GradeService : BaseCRUDService<GradeViewDataModel, GradeInputDataModel, int>, IGradeService
    {
        private static string path = "grade";

        public GradeService() : base(path)
        { }
    }
}
