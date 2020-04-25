namespace University.InputModels
{
    public class SubjectInputModel : BaseInputModel<int>
    {
        public string Name { get; set; }

        public override bool IsIdEmpty()
        {
            return Id == 0;
        }
    }
}
