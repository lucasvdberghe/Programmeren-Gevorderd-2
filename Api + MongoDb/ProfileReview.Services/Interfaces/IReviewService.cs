using System;
using ProfileReview.Api.Contracts.Reviews;

namespace ProfileReview.Services.Interfaces;

public interface IReviewService
{
    Task CreateAsync(ReviewRequestContract reviewRequestContract);
}
