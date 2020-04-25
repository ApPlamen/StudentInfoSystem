namespace University_frontend.Enums
{
    using System.Collections.Generic;

    public static class RolesDictionary
    {
        public static Dictionary<string, string> Roles { get; } = new Dictionary<string, string>()
        {
            {
                RoleIds.Admin,
                RoleStrings.Admin
            },
            {
                RoleIds.Student,
                RoleStrings.Student
            },
            {
                RoleIds.Teacher,
                RoleStrings.Teacher
            },
        };

        public static class RoleIds
        {
            public const string Admin = "6bff149e-59cf-4101-9a4a-9da9deb5b28f";
            public const string Student = "89dfcf49-8322-4620-8f1a-f560fe525d79";
            public const string Teacher = "c5a90709-70f5-439d-aa50-af8058b300ce";
        }

        public static class RoleStrings
        {
            public const string Admin = "Admin";
            public const string Student = "Student";
            public const string Teacher = "Teacher";
        }
    }
}
