using System;
using System.ComponentModel.DataAnnotations;

namespace ProfileReview.Api.Contracts.Profiles;

public class ProfileRequestContract
{
    [MaxLength(200)]
    public required string Name { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
    [MaxLength(1000)]
    public string? Description { get; set; }
}
