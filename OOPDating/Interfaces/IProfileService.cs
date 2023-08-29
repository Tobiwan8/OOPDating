using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IProfileService
    {
        List<UserProfile> GetProfiles();

        UserProfile GetProfile(UserProfile profile);

        UserProfile GetProfileByAccountID(Account account);

        void UpdateProfile(UserProfile profile);

        void AddProfile(UserProfile profile, Account account);

        void DeleteProfile(UserProfile profile);
        List<UserProfile> GetProfilesBySearch(ProfileSearch search);
    }
}
