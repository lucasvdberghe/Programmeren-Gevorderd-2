using System;
using EventPlanner.Api.Contracts.Task;

namespace EventPlanner.Services.Interfaces;

public interface ITaskService
{
    Task<IEnumerable<TaskResponseContract>> GetAllAsync();
    Task<TaskResponseContract?> GetByIdAsync(int id);
    Task<TaskResponseContract> CreateAsync(TaskRequestContract taskRequestContract);
    Task UpdateAsync(int id, TaskRequestContract taskRequestContract);
    Task PatchStatusAsync(int id, TaskPatchRequestContract taskPatchRequestContract);
    Task DeleteAsync(int id);
}
