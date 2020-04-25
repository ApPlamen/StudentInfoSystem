namespace University.Common.Infrastructure
{
    using AutoMapper;
    using University.DAL.Models;
    using University.InputModels;
    using University.ViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GradeInputModel, Grade>();
            CreateMap<Grade, GradeViewModel>();
            CreateMap<SubjectInputModel, Subject>();
            CreateMap<Subject, SubjectViewModel>();
            CreateMap<UserInputModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
