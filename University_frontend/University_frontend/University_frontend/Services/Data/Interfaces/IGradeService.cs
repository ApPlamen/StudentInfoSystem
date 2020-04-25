namespace University_frontend.Services.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;

    public interface IGradeService
    {
        Task<IEnumerable<GradeViewDataModel>> GetAll();

        Task<GradeViewDataModel> Get(int id);

        Task Save(GradeInputDataModel model);

        Task Delete(int id);
    }
}
