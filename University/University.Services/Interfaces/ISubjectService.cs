namespace University.Services
{
    using System.Collections.Generic;
    using University.InputModels;
    using University.ViewModels;

    public interface ISubjectService : IBaseService
    {
        public IEnumerable<SubjectViewModel> GetAll();

        public SubjectViewModel Get(int id);

        public void Save(SubjectInputModel model);

        public void Delete(int id);
    }
}
