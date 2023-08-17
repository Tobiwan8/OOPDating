namespace OOPDating.Entities
{
    public class Chat : ICommunication
    {
        public int User1ID { get ; set ; }
        public int User2ID { get ; set ; }
        public string? Message { get; set; }
    }
}
