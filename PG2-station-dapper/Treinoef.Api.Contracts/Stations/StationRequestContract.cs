using System;
using System.ComponentModel.DataAnnotations;

namespace Treinoef.Api.Contracts.Stations;

public class StationRequestContract
{
    [MaxLength(100)]
    public required string Name { get; set; }
    public bool HeatedWaitingArea { get; set; }
}
