namespace University.DAL.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using University.Common.Authentication;
    using University.DAL.Models;

    public static class DbInitializer
    {
        public static void Initialize(this UniversityContext data)
        {
            SeedRoles(data);
            SeedAdmin(data);

            data.SaveChanges();
        }

        private static void SeedRoles(UniversityContext data)
        {
            if (data.Roles.Count() == 0)
            {
                data.Roles.Add(new Role()

                {
                    Id = "6bff149e-59cf-4101-9a4a-9da9deb5b28f",
                    ConcurrencyStamp = "637fe1ac-8683-47ba-a95b-234ca60c5385",
                    Name = RoleStrings.Admin,
                    NormalizedName = RoleStrings.Admin.ToUpper()
                });

                data.Roles.Add(new Role()
                {
                    Id = "89dfcf49-8322-4620-8f1a-f560fe525d79",
                    ConcurrencyStamp = "5cda244b-53e2-4e25-909a-52d0c5e4f045",
                    Name = RoleStrings.Student,
                    NormalizedName = RoleStrings.Student.ToUpper()
                });

                data.Roles.Add(new Role()
                {
                    Id = "c5a90709-70f5-439d-aa50-af8058b300ce",
                    ConcurrencyStamp = "8d6399c8-0143-4163-836e-82605879693b",
                    Name = RoleStrings.Teacher,
                    NormalizedName = RoleStrings.Teacher.ToUpper()
                });
            }
        }

        private static void SeedAdmin(UniversityContext data)
        {
            if (data.Users.Count(u => u.RoleId.Equals(RoleIds.Admin)) == 0)
            {
                User admin = new User
                {
                    Id = "8e13686a-ce33-4f7e-b599-5f7f0db57e72",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "7a5a5685-9a1f-4284-bca9-2d2974b89e37",
                    Email = "admin@admin.com",
                    EmailConfirmed = false,
                    LockoutEnabled = true,
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    NormalizedUserName = "ADMIN",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    UserName = "admin",
                    Fullname = "Administrator",
                    RoleId = RoleIds.Admin,
                };
                admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "1111111");

                data.Users.Add(admin);
            }
        }
    }
}
