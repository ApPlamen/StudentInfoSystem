namespace University_frontend.Services.DataServices
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using University_frontend.Extensions;

    public class BaseCRUDService<ViewDataModel, InputDataModel, IdType> : BaseService, IBaseCRUDService<ViewDataModel, InputDataModel, IdType>
    {
        private string path;

        public BaseCRUDService(string path)
        {
            this.path = path;
        }

        public async Task<IEnumerable<ViewDataModel>> GetAll()
        {
            HttpResponseMessage response = await this.GetAsync(path);
            var result = HttpHelper.GetContent<IEnumerable<ViewDataModel>>(response);

            return result;
        }

        public async Task<ViewDataModel> Get(IdType id)
        {
            HttpResponseMessage response = await this.GetAsync(path + "/" + id);
            var result = HttpHelper.GetContent<ViewDataModel>(response);

            return result;
        }

        public async Task Save(InputDataModel model)
        {
            ByteArrayContent content = HttpHelper.CreateByteContent(model);
            HttpResponseMessage response = await this.PostAsync(path, content);
        }

        public async Task Delete(IdType id)
        {
            HttpResponseMessage response = await this.DeleteAsync(path + "/" + id);
        }
    }
}
