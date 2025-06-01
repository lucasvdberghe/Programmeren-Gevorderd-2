using System;
using EventPlanner.Api.Contracts.Task;
using EventPlanner.Services.Exceptions;
using EventPlanner.Services.Interfaces;
using EventPlanner.Services.Mapping;
using EventPlanner.Storage.Interfaces;

namespace EventPlanner.Services;

public class TaskService(ITaskRepository taskRepository, IEventRepository eventRepository, IAuditService auditService) : ITaskService
{
    public async Task<IEnumerable<TaskResponseContract>> GetAllAsync()
    {
        var taskContracts = (await taskRepository.GetAllAsync()).Select(t => t.AsContract()).ToList();

        await auditService.AddEntryAsync("Task", "R", null, taskContracts);

        return taskContracts;
    }

    public async Task<TaskResponseContract?> GetByIdAsync(int id)
    {
        var taskContract = (await taskRepository.GetByIdAsync(id))?.AsContract();

        await auditService.AddEntryAsync("Task", "R", null, taskContract);

        return taskContract;
    }

    public async Task<TaskResponseContract> CreateAsync(TaskRequestContract taskRequestContract)
    {
        var taskEvent = await eventRepository.GetByIdAsync(taskRequestContract.EventId);
        if (taskEvent is null) throw new DomainException("Event not found");

        var taskToCreate = taskRequestContract.AsModel(taskEvent);

        var createdTaskContract = (await taskRepository.AddAsync(taskToCreate)).AsContract();

        await auditService.AddEntryAsync("Task", "C", null, createdTaskContract);

        return createdTaskContract;
    }

    public async Task UpdateAsync(int id, TaskRequestContract taskRequestContract)
    {
        var taskToUpdate = await taskRepository.GetByIdAsync(id);
        if (taskToUpdate is null) throw new NotFoundException("Task not found");

        var taskRequestEvent = await eventRepository.GetByIdAsync(taskRequestContract.EventId);
        if (taskRequestEvent is null) throw new DomainException("Event not found");

        var originalTaskContract = taskToUpdate.AsContract();

        taskToUpdate.Name = taskRequestContract.Name;
        taskToUpdate.Event = taskRequestEvent;
        taskToUpdate.Description = taskRequestContract.Description;
        taskToUpdate.Importance = taskRequestContract.Importance;
        taskToUpdate.Status = taskRequestContract.Status;
        taskToUpdate.DeadlineDateTime = taskRequestContract.DeadlineDateTime;
        taskToUpdate.LastUpdated = DateTime.UtcNow;

        await taskRepository.UpdateAsync(taskToUpdate);
        await auditService.AddEntryAsync("Task", "U", originalTaskContract, taskToUpdate.AsContract());
    }

    public async Task PatchStatusAsync(int id, TaskPatchRequestContract taskPatchRequestContract)
    {
        var taskToUpdate = await taskRepository.GetByIdAsync(id);
        if (taskToUpdate is null) throw new NotFoundException("Task not found");

        var originalTaskContract = taskToUpdate.AsContract();

        taskToUpdate.Status = taskPatchRequestContract.Status;

        await taskRepository.UpdateAsync(taskToUpdate);
        await auditService.AddEntryAsync("Task", "U", originalTaskContract, taskToUpdate.AsContract());
    }

    public async Task DeleteAsync(int id)
    {
        var taskToDelete = await taskRepository.GetByIdAsync(id);
        if (taskToDelete is null) throw new NotFoundException("Task not found");

        await auditService.AddEntryAsync("Task", "D", taskToDelete.AsContract(), null);
        await taskRepository.DeleteAsync(id);
    }
}
