namespace University.Services
{
    using System.Collections.Generic;

    public interface IBaseCRUDService<DALModel, ViewModel, InputModel, IdType>
    {
        public IEnumerable<ViewModel> GetAll();

        public ViewModel Get(IdType id);

        public void Save(InputModel model);

        public void Delete(IdType id);
    }
}
