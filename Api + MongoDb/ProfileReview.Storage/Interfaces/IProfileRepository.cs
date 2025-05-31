using System;
using ProfileReview.Services.Models;

namespace ProfileReview.Storage.Interfaces;

public interface IProfileRepository
{
    Task<Profile?> GetByIdAsync(string id);
    Task<Profile> CreateAsync(Profile profile);
    Task UpdateAsync(Profile profile);
}
