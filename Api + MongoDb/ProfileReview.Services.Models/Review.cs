using System;

namespace ProfileReview.Services.Models;

public class Review
{
    public DateOnly Date { get; set; }
    public int Score { get; set; }
    public string? Comment { get; set; }
}
