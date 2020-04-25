namespace University.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using University.DAL.Models;
    using University.InputModels;
    using University.Repository;
    using University.ViewModels;

    public class GradeService : BaseCRUDService<Grade, GradeViewModel, GradeInputModel, int>, IGradeService
    {
        public GradeService(IMapper mapper,
            IRepository<Grade> grade)
            : base(mapper, grade)
        { }

        public override IEnumerable<GradeViewModel> GetAll()
        {
            var grades = this.repo.All()
                .Select(g => new GradeViewModel()
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    StudentName = g.Student.Fullname,
                    SubjectId = g.SubjectId,
                    SubjectName = g.Subject.Name,
                    TeacherId = g.TeacherId,
                    TeacherName = g.Teacher.Fullname,
                    GradeValue = g.GradeValue,
                })
                .ToList();

            return grades;
        }
    }
}