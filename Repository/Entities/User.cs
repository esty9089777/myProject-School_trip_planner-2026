namespace Repository.Entities
{
    public enum SchoolTypeEnum
    {
        ElementarySchool,
        MiddleSchool,
        Secondary
    }

    public enum UserRoleEnum
    {
        Admin,
        User,
        BusinessOwner
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public SchoolTypeEnum SchoolType { get; set; }
        public UserRoleEnum UserRole { get; set; }
    }
}
