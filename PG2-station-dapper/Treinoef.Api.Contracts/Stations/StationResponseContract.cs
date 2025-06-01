using System;

namespace Treinoef.Api.Contracts.Stations;

public class StationResponseContract
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool HeatedWaitingArea { get; set; }
}
