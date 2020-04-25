namespace University_frontend.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage, IMainPageDetail
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}