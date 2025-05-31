using System;
using ProfileReview.Api.Contracts.Profiles;
using ProfileReview.Api.Contracts.Reviews;
using ProfileReview.Services.Models;

namespace ProfileReview.Services.MappingExtensions;

public static class ProfileReviewMappingExtensions
{
    public static ProfileResponseContract AsContract(this Profile profile)
    {
        return new ProfileResponseContract
        {
            Id = profile.Id.ToString(),
            Name = profile.Name,
            Email = profile.Email,
            Description = profile.Description,
            Reviews = profile.Reviews.Select(r => r.AsProfileReviewResponseContract()).ToList()
        };
    }

    public static ProfileReviewResponseContract AsProfileReviewResponseContract(this Review review)
    {
        return new ProfileReviewResponseContract
        {
            Date = review.Date,
            Score = review.Score,
            Comment = review.Comment
        };
    }

    public static Profile AsModel(this ProfileRequestContract profileRequestContract)
    {
        return new Profile
        {
            Name = profileRequestContract.Name,
            Email = profileRequestContract.Email,
            Description = profileRequestContract.Description
        };
    }

    public static Review AsModel(this ReviewRequestContract reviewRequestContract)
    {
        return new Review
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            Score = reviewRequestContract.Score,
            Comment = reviewRequestContract.Comment
        };
    }
}
