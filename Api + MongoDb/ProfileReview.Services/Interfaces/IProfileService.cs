using System;
using ProfileReview.Api.Contracts.Profiles;

namespace ProfileReview.Services.Interfaces;

public interface IProfileService
{
    Task<ProfileResponseContract?> GetByIdAsync(string id);
    Task<ProfileResponseContract> CreateAsync(ProfileRequestContract profileRequestContract);
    Task UpdateAsync(string id, ProfileRequestContract profileRequestContract);
}
