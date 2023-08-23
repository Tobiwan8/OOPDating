using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IZipcodeRepository
    {
        public ZipcodeCity GetZipcode(string zipcode);
        List<ZipcodeCity> GetZipcodes();
    }
}
