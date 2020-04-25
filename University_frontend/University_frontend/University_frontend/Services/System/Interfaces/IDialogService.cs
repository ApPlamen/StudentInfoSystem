namespace University_frontend.Services.SystemServices
{
    using System.Threading.Tasks;

    public interface IDialogService
    {
        Task ShowDialog(string message, string title, string buttonLabel);

        void ShowToast(string message);
    }
}
