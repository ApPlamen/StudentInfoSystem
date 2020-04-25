namespace University.DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Subject : BaseDALModel<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
