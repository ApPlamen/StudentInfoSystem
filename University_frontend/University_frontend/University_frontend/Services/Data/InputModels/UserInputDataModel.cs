namespace University_frontend.Services.DataServices.InputModels
{
    using System.Linq;
    using University_frontend.Enums;

    public class UserInputDataModel
    {
        public string Id { get; set; } = string.Empty;

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        public string PasswordHash { get; set; }

        private string roleId;

        public string RoleId
        {
            get => roleId;
            set => roleId = RolesDictionary.Roles.FirstOrDefault(x => value.Equals(x.Value)).Key;
        }
    }
}
