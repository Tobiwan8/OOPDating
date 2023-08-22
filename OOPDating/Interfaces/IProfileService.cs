using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IProfileService
    {
        List<UserProfile> GetProfiles();

        UserProfile GetProfile(UserProfile profile);

        void UpdateProfile(UserProfile profile);

        void AddProfile(UserProfile profile);
    }
}
