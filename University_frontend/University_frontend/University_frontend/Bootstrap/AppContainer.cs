namespace University_frontend.Bootstrap
{
    using Autofac;
    using System;
    using University_frontend.Extensions;
    using University_frontend.Services.DataServices;
    using University_frontend.Services.SystemServices;
    using University_frontend.ViewModels;

    public class AppContainer
    {
        private static IContainer container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<GradeListViewModel>();
            builder.RegisterType<GradeViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<LogInViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<SubjectListViewModel>();
            builder.RegisterType<SubjectViewModel>();
            builder.RegisterType<UserListViewModel>();
            builder.RegisterType<UserViewModel>();

            //Services
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<GradeService>().As<IGradeService>();
            builder.RegisterType<SubjectService>().As<ISubjectService>();
            builder.RegisterType<UserService>().As<IUserService>();

            //AutoMapper Configurations
            builder.RegisterModule<AutoMapperModule>();

            container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return  container.Resolve<T>();
        }
    }
}
