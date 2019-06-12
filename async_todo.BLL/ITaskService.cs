using async_todo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace async_todo.BLL
{
    public interface ITaskService
    {
        Task<List<Tasks>> GetTasksAsync();
        Task<Tasks> DeleteTaskAsync(Tasks item);
        Task<Tasks> CreateTaskAsync(Tasks item);
        Task<Tasks> UpdateTaskAsync(Tasks item);
    }
}
