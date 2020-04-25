namespace University_frontend.Services.DataServices.ViewModels
{
    using University_frontend.Enums;

    public class UserViewDataModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Fullname { get; set; }

        private string roleId;

        public string RoleId
        {
            get
            {
                string result;
                RolesDictionary.Roles.TryGetValue(roleId, out result);
                return result;
            }
            set => roleId = value;
        }
    }
}
