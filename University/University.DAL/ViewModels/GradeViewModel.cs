namespace University.ViewModels
{
    public class GradeViewModel : BaseViewModel<int>
    {
        public string StudentId { get; set; }

        public string StudentName { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string TeacherId { get; set; }

        public string TeacherName { get; set; }

        public double GradeValue { get; set; }
    }
}
