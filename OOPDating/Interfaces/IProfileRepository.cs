using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IProfileRepository
    {
        bool AddProfile(UserProfile profile);
        bool UpdateProfile(UserProfile profile);
        public UserProfile GetProfile(UserProfile profile);
        List<UserProfile> GetProfiles();
    }
}
