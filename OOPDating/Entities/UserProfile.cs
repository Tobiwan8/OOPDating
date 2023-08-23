namespace OOPDating.Entities
{
    public class UserProfile
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DoB { get; set; } = DateTime.Now;
        public string? Gender { get; set; }
        public string? ProfileText { get; set; } = null;
        public int AccountID { get; set; }
        public string? ZipcodeID { get; set; } = "2000";
    }
}
