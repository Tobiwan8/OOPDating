namespace OOPDating.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DoB { get; set; }
        public string? Gender { get; set; }
        public string? ProfileText { get; set; }
        public int AccountID { get; set; }
        public int ZipcodeID { get; set; }
    }
}
