using System;
using System.Collections.Generic;

namespace Treinoef.Services.Models;

public class Station
{
    public int StationId { get; set; }
    public required string Name { get; set; }
    public bool HeatedWaitingArea { get; set; }
}
