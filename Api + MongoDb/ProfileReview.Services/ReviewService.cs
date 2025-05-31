using System;
using ProfileReview.Api.Contracts.Reviews;
using ProfileReview.Services.Exceptions;
using ProfileReview.Services.Interfaces;
using ProfileReview.Services.MappingExtensions;
using ProfileReview.Storage.Interfaces;

namespace ProfileReview.Services;

public class ReviewService(IProfileRepository profileRepository) : IReviewService
{
    public async Task CreateAsync(ReviewRequestContract reviewRequestContract)
    {
        if (string.IsNullOrWhiteSpace(reviewRequestContract.ProfileId)) throw new DomainException("ProfileId is empty");

        var profile = await profileRepository.GetByIdAsync(reviewRequestContract.ProfileId);
        if (profile is null) throw new NotFoundException("Profile not found");

        var createdReview = reviewRequestContract.AsModel();
        profile.Reviews.Add(createdReview);

        await profileRepository.UpdateAsync(profile);
    }
}