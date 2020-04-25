namespace University_frontend.Services.DataServices
{
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public class UserService : BaseCRUDService<UserViewDataModel, UserInputDataModel, string>, IUserService
    {
        private static string path = "user";

        public UserService() : base(path)
        { }
    }
}
