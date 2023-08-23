using OOPDating.Entities;
using OOPDating.Interfaces;

namespace OOPDating.Services
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository _repository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _repository = profileRepository;
        }
        public void AddProfile(UserProfile profile, Account account)
        {
            _repository.AddProfile(profile, account);
        }

        public UserProfile GetProfile(UserProfile profile)
        {
            UserProfile FindDBProfile = _repository.GetProfile(profile);
            return FindDBProfile;
        }

        public List<UserProfile> GetProfiles()
        {
            var profiles = _repository.GetProfiles();
            return profiles;
        }

        public void UpdateProfile(UserProfile profile)
        {
            var dbProfile = _repository.GetProfile(profile);
            _repository.UpdateProfile(dbProfile);
        }
    }
}
