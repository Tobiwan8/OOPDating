using OOPDating.Interfaces;

namespace OOPDating.Entities
{
    public class Like : ICommunication
    {
        public int User1ID { get ; set ; }
        public int User2ID { get ; set ; }
        public bool IsLiked { get ; set ; }
    }
}
