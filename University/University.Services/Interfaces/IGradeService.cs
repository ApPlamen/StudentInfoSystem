namespace University.Services
{
    using System.Collections.Generic;
    using University.InputModels;
    using University.ViewModels;

    public interface IGradeService : IBaseService
    {
        public IEnumerable<GradeViewModel> GetAll();

        public GradeViewModel Get(int id);

        public void Save(GradeInputModel model);

        public void Delete(int id);
    }
}
