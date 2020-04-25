namespace University.InputModels
{
    public class GradeInputModel : BaseInputModel<int>
    {
        public string StudentId { get; set; }

        public int SubjectId { get; set; }

        public string TeacherId { get; set; }

        public double GradeValue { get; set; }

        public override bool IsIdEmpty()
        {
            return Id == 0;
        }
    }
}
