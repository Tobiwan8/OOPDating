using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IZipcodeService
    {
        ZipcodeCity GetZipcodeCity(string zipcode);
        List<ZipcodeCity> GetZipcodeCities();
    }
}
