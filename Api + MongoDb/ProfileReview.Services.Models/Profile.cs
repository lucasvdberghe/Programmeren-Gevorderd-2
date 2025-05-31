using System;
using MongoDB.Bson;

namespace ProfileReview.Services.Models;

public class Profile
{
    public ObjectId Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Description { get; set; }
    public List<Review> Reviews { get; set; } = new();
}
