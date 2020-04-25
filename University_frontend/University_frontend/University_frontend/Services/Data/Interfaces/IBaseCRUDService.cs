namespace University_frontend.Services.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseCRUDService<ViewDataModel, InputDataModel, IdType>
    {
        Task<IEnumerable<ViewDataModel>> GetAll();

        Task<ViewDataModel> Get(IdType id);

        Task Save(InputDataModel model);

        Task Delete(IdType id);
    }
}
