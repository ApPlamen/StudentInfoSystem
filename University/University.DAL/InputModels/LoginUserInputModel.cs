namespace University.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginUserInputModel
    {
        //[Required]
        //[EmailAddress]
        public string Email { get; set; }

        //[Required]
        public string Password { get; set; }
    }
}
