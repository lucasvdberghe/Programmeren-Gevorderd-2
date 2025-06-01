using System;
using EventPlanner.Storage.Models;
using Task = System.Threading.Tasks.Task;

namespace EventPlanner.Storage.Interfaces;

public interface ITaskRepository
{
    Task<Models.Task> AddAsync(Models.Task task);
    Task DeleteAsync(int id);
    Task<IEnumerable<Models.Task>> GetAllAsync();
    Task<Models.Task?> GetByIdAsync(int id);
    Task UpdateAsync(Models.Task taskToUpdate);
}
