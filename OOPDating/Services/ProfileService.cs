using OOPDating.Entities;
using OOPDating.Interfaces;
using OOPDating.Pages;

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

        public UserProfile GetProfileByAccountID(Account account)
        {
            UserProfile FindDBProfile = _repository.GetProfileByAccountID(account);
            return FindDBProfile;
        }

        public List<UserProfile> GetProfiles()
        {
            var profiles = _repository.GetProfiles();
            return profiles;
        }

        public void UpdateProfile(UserProfile profile)
        {            
            _repository.UpdateProfile(profile);
        }
    }
}
