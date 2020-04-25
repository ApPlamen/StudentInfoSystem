namespace University.Services
{
    using System.Collections.Generic;
    using University.InputModels;
    using University.ViewModels;

    public interface IUserService : IBaseService
    {
        public IEnumerable<UserViewModel> GetAll();

        public UserViewModel Get(string id);

        public void Save(UserInputModel model);

        public void Delete(string id);
    }
}
