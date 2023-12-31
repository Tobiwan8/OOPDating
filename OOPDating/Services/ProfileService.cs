﻿using OOPDating.Entities;
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

        public void DeleteProfile(UserProfile profile)
        {
            _repository.DeleteProfile(profile);
        }

        public List<UserProfile> GetProfilesBySearch(ProfileSearch search)
        {
            return _repository.GetProfilesBySearch(search);
        }

        public void LikeOrMatchProfile(UserProfile senderProfile, UserProfile receiverProfile)
        {
            _repository.LikeOrMatchProfile(senderProfile, receiverProfile);
        }

        public List<UserProfile> GetProfilesThatLikeYou(UserProfile receiverProfile)
        {
            return _repository.GetProfilesThatLikedYou(receiverProfile);
        }

        public List<int> GetLikedProfiles(UserProfile senderProfile)
        {
            return _repository.GetLikedProfiles(senderProfile);
        }

        public void DislikeProfile(UserProfile senderProfile, UserProfile receiverProfile)
        {
            _repository.DislikeProfile(senderProfile, receiverProfile);
        }

        public List<UserProfile> GetMatchedProfiles(UserProfile senderProfile)
        {
            return _repository.GetMatchedProfiles(senderProfile);
        }

        public void SendMessageToUser(Communication message)
        {
            _repository.SendMessageToUser(message);
        }

        public List<Communication> GetSpecificChat(UserProfile senderProfile, UserProfile ReceiverProfile)
        {
            return _repository.GetSpecificChat(senderProfile, ReceiverProfile);
        }
    }
}
