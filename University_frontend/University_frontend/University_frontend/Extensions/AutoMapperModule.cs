namespace University_frontend.Extensions
{
    using Autofac;
    using AutoMapper;
    using University_frontend.Services.DataServices.InputModels;
    using University_frontend.Services.DataServices.ViewModels;
    using University_frontend.ViewModels.DataModels;

    public class AutoMapperModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GradeDataModel>().AsSelf();
            builder.RegisterType<GradeInputDataModel>().AsSelf();
            builder.RegisterType<GradeViewDataModel>().AsSelf();
            builder.RegisterType<SubjectDataModel>().AsSelf();
            builder.RegisterType<SubjectInputDataModel>().AsSelf();
            builder.RegisterType<SubjectViewDataModel>().AsSelf();
            builder.RegisterType<UserDataModel>().AsSelf();
            builder.RegisterType<UserInputDataModel>().AsSelf();
            builder.RegisterType<UserViewDataModel>().AsSelf();


            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GradeViewDataModel, GradeDataModel>();
                //cfg.CreateMap<GradeDataModel, GradeViewDataModel>();
                cfg.CreateMap<GradeDataModel, GradeInputDataModel>();
                cfg.CreateMap<SubjectViewDataModel, SubjectDataModel>();
                //cfg.CreateMap<SubjectDataModel, SubjectViewDataModel>();
                cfg.CreateMap<SubjectDataModel, SubjectInputDataModel>();
                cfg.CreateMap<UserViewDataModel, UserDataModel>();
                //cfg.CreateMap<UserDataModel, UserViewDataModel>();
                cfg.CreateMap<UserDataModel, UserInputDataModel>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
