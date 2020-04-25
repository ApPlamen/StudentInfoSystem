namespace University_frontend.ViewModels.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class GradeDataModel
    {
        public int? Id { get; set; } = null;

        [Required(ErrorMessage = "Student is a required field")]
        public string StudentId { get; set; }

        public string StudentName { get; set; }

        [Required(ErrorMessage = "Subject is a required field")]
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        [Required(ErrorMessage = "Teacher is a required field")]
        public string TeacherId { get; set; }

        public string TeacherName { get; set; }

        [Required(ErrorMessage = "Grade is a required field")]
        [Range(2.00, 6.00, ErrorMessage = "Grade must be between 2 and 6")]
        public double GradeValue { get; set; }
    }
}
