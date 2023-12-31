﻿using OOPDating.Entities;

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

        void LikeOrMatchProfile(UserProfile senderProfile, UserProfile receiverProfile);

        List<UserProfile> GetProfilesThatLikeYou(UserProfile receiverProfile);

        List<int> GetLikedProfiles(UserProfile senderProfile);

        void DislikeProfile(UserProfile senderProfile, UserProfile receiverProfile);

        List<UserProfile> GetMatchedProfiles(UserProfile senderProfile);

        void SendMessageToUser(Communication message);

        List<Communication> GetSpecificChat(UserProfile senderProfile, UserProfile ReceiverProfile);
    }
}
