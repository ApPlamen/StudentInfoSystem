namespace University_frontend.Services.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public interface IUserService
    {
        Task<IEnumerable<UserViewDataModel>> GetAll();

        Task<UserViewDataModel> Get(string id);

        Task Save(UserInputDataModel model);

        Task Delete(string id);
    }
}