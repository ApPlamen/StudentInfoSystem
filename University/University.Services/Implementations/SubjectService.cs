namespace University.Services
{
    using AutoMapper;
    using University.DAL.Models;
    using University.InputModels;
    using University.Repository;
    using University.ViewModels;

    public class SubjectService : BaseCRUDService<Subject, SubjectViewModel, SubjectInputModel, int>, ISubjectService
    {
        public SubjectService(IMapper mapper,
            IRepository<Subject> subject)
            : base(mapper, subject)
        { }
    }
}