using System;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using ProfileReview.Api.Contracts.Profiles;
using ProfileReview.Services.Exceptions;
using ProfileReview.Services.Interfaces;
using ProfileReview.Services.MappingExtensions;
using ProfileReview.Storage;
using ProfileReview.Storage.Interfaces;

namespace ProfileReview.Services;

public class ProfileService(ProfileReviewDbContext dbContext) : IProfileService
{
    public async Task<ProfileResponseContract?> GetByIdAsync(string id)
    {
        var profile = await dbContext.Profiles.FindAsync(new ObjectId(id));
        return profile?.AsContract();
    }

    public async Task<ProfileResponseContract> CreateAsync(ProfileRequestContract profileRequestContract)
    {
        if (string.IsNullOrWhiteSpace(profileRequestContract.Name)) throw new DomainException("Name is empty");

        var newProfile = profileRequestContract.AsModel();
        await dbContext.Profiles.AddAsync(newProfile);
        await dbContext.SaveChangesAsync();

        return newProfile.AsContract();
    }

    public async Task UpdateAsync(string id, ProfileRequestContract profileRequestContract)
    {
        if (string.IsNullOrWhiteSpace(profileRequestContract.Name)) throw new DomainException("Name is empty");

        var profile = await dbContext.Profiles.SingleOrDefaultAsync(p => p.Id.ToString() == id);
        if (profile is null) throw new NotFoundException();

        profile.Name = profileRequestContract.Name;
        profile.Email = profileRequestContract.Email;
        profile.Description = profileRequestContract.Description;

        await dbContext.SaveChangesAsync();
    }
}
