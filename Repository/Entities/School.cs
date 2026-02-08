namespace Repository.Entities
{
    public enum SchoolTypeEnum
    {
        ElementarySchool,
        MiddleSchool,
        secondary
    }
    public class School
    {
        public int SchoolId { get; set; }
        public string NameSchool { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public SchoolTypeEnum SchoolType { get; set; }
        public int SchoolCode { get; set; }
    }
}
