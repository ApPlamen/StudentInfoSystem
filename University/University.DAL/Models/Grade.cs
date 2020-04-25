namespace University.DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Grade : BaseDALModel<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

        [Required]
        public string TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual User Teacher { get; set; }

        [Required]
        public double GradeValue { get; set; }
    }
}
