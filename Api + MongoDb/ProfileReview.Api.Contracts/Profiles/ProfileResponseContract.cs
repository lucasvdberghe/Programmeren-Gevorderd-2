using System;

namespace ProfileReview.Api.Contracts.Profiles;

public class ProfileResponseContract
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Description { get; set; }
    public List<ProfileReviewResponseContract> Reviews { get; set; } = new();
}

public class ProfileReviewResponseContract
{
    public DateOnly Date { get; set; }
    public int Score { get; set; }
    public string? Comment { get; set; }
}