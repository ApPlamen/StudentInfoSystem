namespace University_frontend.Services.DataServices.InputModels
{
    public class GradeInputDataModel
    {
        public int Id { get; set; } = 0;

        public string StudentId { get; set; }

        public int SubjectId { get; set; }

        public string TeacherId { get; set; }

        public double GradeValue { get; set; }
    }
}
