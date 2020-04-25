namespace University_frontend.Services.SystemServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;
    using Xamarin.Forms;
    using University_frontend.ViewModels;
    using University_frontend.Views;

    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            await NavigateToAsync<LogInViewModel>();
        }

        public async Task ClearBackStack()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task PopToRootAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                await mainPage.Detail.Navigation.PopToRootAsync();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is MainView || page is LogInView)
            {
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is MainView)
            {
                var mainPage = CurrentApplication.MainPage as MainView;

                CustomNavigationPage navigationPage;

                if (page is IMainPageDetail)
                {
                    navigationPage = new CustomNavigationPage(page);
                    mainPage.Detail = navigationPage;
                }
                else
                {
                    navigationPage = mainPage.Detail as CustomNavigationPage;

                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        await navigationPage.PushAsync(page);
                    }
                }

                mainPage.IsPresented = false;
            }
            else
            {
                CustomNavigationPage navigationPage = CurrentApplication.MainPage as CustomNavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new CustomNavigationPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return mappings[viewModelType];
        }

        protected Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;

            return page;
        }

        private void CreatePageViewModelMappings()
        {

            mappings.Add(typeof(GradeListViewModel), typeof(GradeListView));
            mappings.Add(typeof(GradeViewModel), typeof(GradeView));
            mappings.Add(typeof(HomeViewModel), typeof(HomeView));
            mappings.Add(typeof(LogInViewModel), typeof(LogInView));
            mappings.Add(typeof(MainViewModel), typeof(MainView));
            mappings.Add(typeof(MenuViewModel), typeof(MenuView));
            mappings.Add(typeof(SubjectListViewModel), typeof(SubjectListView));
            mappings.Add(typeof(SubjectViewModel), typeof(SubjectView));
            mappings.Add(typeof(UserListViewModel), typeof(UserListView));
            mappings.Add(typeof(UserViewModel), typeof(UserView));
        }
    }
}