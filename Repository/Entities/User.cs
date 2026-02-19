namespace Repository.Entities
{
    public enum SchoolTypeEnum
    {
        ElementarySchool,
        MiddleSchool,
        Secondary
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public SchoolTypeEnum SchoolType { get; set; }
    }
}
