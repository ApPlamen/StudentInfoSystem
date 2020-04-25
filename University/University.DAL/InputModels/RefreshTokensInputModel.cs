namespace University.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class RefreshTokensInputModel
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
