namespace Repository.Entities
{
    public enum AgeGroupEnum
    {
        AtoC = 1,   // כיתות א-ג
        DtoE = 2,   // כיתות ד-ה
        FtoH = 4,   // כיתות ו-ח
        ItoL = 8    // כיתות ט-יב
    }
    public class AgeGroup
    {
        public int AgeGroupId { get; set; }
        public AgeGroupEnum ageGroup { get; set; }
        public string Description { get; set; }

        public ICollection<Routes> Routes { get; set; }
        public ICollection<Branches> Branches { get; set; }
    }
}
