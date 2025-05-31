using System;
using System.ComponentModel.DataAnnotations;

namespace ProfileReview.Api.Contracts.Reviews;

public class ReviewRequestContract
{
    public required string ProfileId { get; set; }
    [Range(1,5)]
    public int Score { get; set; }
    public string? Comment { get; set; }
}
