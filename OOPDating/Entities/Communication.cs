namespace OOPDating.Entities
{
    public class Chat
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
