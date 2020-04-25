namespace University_frontend.Services.DataServices.ViewModels
{
    public class GradeViewDataModel
    {
        public int Id { get; set; }

        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string TeacherId { get; set; }

        public string TeacherName { get; set; }

        public double GradeValue { get; set; }
    }
}
