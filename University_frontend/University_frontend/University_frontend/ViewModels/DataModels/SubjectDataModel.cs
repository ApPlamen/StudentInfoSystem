namespace University_frontend.ViewModels.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class SubjectDataModel
    {
        public int? Id { get; set; } = null;

        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }
    }
}
