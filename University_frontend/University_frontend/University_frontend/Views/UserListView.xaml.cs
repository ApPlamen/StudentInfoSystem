namespace University_frontend.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListView : ContentPage, IMainPageDetail
    {
        public UserListView()
        {
            InitializeComponent();
        }
    }
}