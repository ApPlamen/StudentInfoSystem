namespace University_frontend.Services.DataServices.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LogInCredentialsInputDataModel
    {
        [Required(ErrorMessage = "Email is a required field")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a required field")]
        public string Password { get; set; }
    }
}
