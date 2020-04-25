namespace University_frontend.ViewModels.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserDataModel
    {
        public string Id { get; set; } = null;

        [Required(ErrorMessage = "User name is a required field")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is a required field")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Password is a required field")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Role is a required field")]
        public string RoleId { get; set; }
    }
}
