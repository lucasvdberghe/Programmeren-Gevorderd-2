using System;
using ProfileReview.Api.Contracts.Profiles;
using ProfileReview.Services.Exceptions;
using ProfileReview.Services.Interfaces;
using ProfileReview.Services.MappingExtensions;
using ProfileReview.Storage.Interfaces;

namespace ProfileReview.Services;

public class ProfileService(IProfileRepository profileRepository) : IProfileService
{
    public async Task<ProfileResponseContract?> GetByIdAsync(string id)
    {
        var profile = await profileRepository.GetByIdAsync(id);
        return profile?.AsContract();
    }

    public async Task<ProfileResponseContract> CreateAsync(ProfileRequestContract profileRequestContract)
    {
        if (string.IsNullOrWhiteSpace(profileRequestContract.Name)) throw new DomainException("Name is empty");

        var newProfile = profileRequestContract.AsModel();
        var createdProfile = await profileRepository.CreateAsync(newProfile);
        return createdProfile.AsContract();
    }

    public async Task UpdateAsync(string id, ProfileRequestContract profileRequestContract)
    {
        if (string.IsNullOrWhiteSpace(profileRequestContract.Name)) throw new DomainException("Name is empty");

        var profile = await profileRepository.GetByIdAsync(id);
        if (profile is null) throw new NotFoundException();

        profile.Name = profileRequestContract.Name;
        profile.Email = profileRequestContract.Email;
        profile.Description = profileRequestContract.Description;

        await profileRepository.UpdateAsync(profile);
    }
}
