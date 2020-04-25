namespace University.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserInputModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
