namespace University_frontend.Services.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewDataModel>> GetAll();

        Task<SubjectViewDataModel> Get(int id);

        Task Save(SubjectInputDataModel model);

        Task Delete(int id);
    }
}
