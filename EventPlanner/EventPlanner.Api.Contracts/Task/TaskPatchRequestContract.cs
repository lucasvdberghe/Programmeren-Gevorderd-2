using System;
using EventPlanner.Shared;

namespace EventPlanner.Api.Contracts.Task;

public class TaskPatchRequestContract
{
    public StatusEnum Status { get; set; }
}
