using OOPDating.Interfaces;

namespace OOPDating.Entities
{
    public class Communication
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
