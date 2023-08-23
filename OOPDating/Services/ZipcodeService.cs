using OOPDating.Entities;
using OOPDating.Interfaces;

namespace OOPDating.Services
{
    public class ZipcodeService : IZipcodeService
    {
        private IZipcodeRepository _repository;

        public ZipcodeService(IZipcodeRepository zipcodeRepository)
        {
            _repository = zipcodeRepository;
        }

        public ZipcodeCity GetZipcodeCity(string zipcode)
        {
            return _repository.GetZipcode(zipcode);
        }

        public List<ZipcodeCity> GetZipcodeCities()
        {
            return _repository.GetZipcodes();
        }
    }
}
