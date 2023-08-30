using OOPDating.Entities;

namespace OOPDating.Interfaces
{
    public interface IProfileRepository
    {
        bool AddProfile(UserProfile profile, Account account);
        bool UpdateProfile(UserProfile profile);
        public UserProfile GetProfile(UserProfile profile);
        public UserProfile GetProfileByAccountID(Account account);
        List<UserProfile> GetProfiles();
        bool DeleteProfile(UserProfile profile);
        List<UserProfile> GetProfilesBySearch(ProfileSearch search);
        bool LikeOrMatchProfile(UserProfile senderProfile, UserProfile receiverProfile);
        List<UserProfile> GetProfilesThatLikedYou(UserProfile receiverProfile);
        List<int> GetLikedProfiles(UserProfile senderProfile);
        bool DislikeProfile(UserProfile senderProfile, UserProfile receiverProfile);
        List<UserProfile> GetMatchedProfiles(UserProfile senderProfile);
    }
}
