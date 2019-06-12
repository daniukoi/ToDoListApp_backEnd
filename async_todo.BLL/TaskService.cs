using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using async_todo.DAL;
using async_todo.DAL.Entities;
using System.Linq;
using async_todo.DAL.Interfaces;
namespace async_todo.BLL
{
    public class TaskService:ITaskService
    {
        private readonly ITasksAsyncRepository<Tasks> _taskRepository;
        public TaskService(ITasksAsyncRepository<Tasks> taskrepository)
        {
            _taskRepository = taskrepository;
        }

        public async Task<Tasks> CreateTaskAsync(Tasks item)
        {
            return await _taskRepository.AddToDoItem(item);
        }

        public async Task<Tasks> DeleteTaskAsync(Tasks item)
        {
            return await _taskRepository.Delete(item);
        }

        public async Task<List<Tasks>> GetTasksAsync()
        {
            return await _taskRepository.Query().ToListAsync();
        }

        public async Task<Tasks> UpdateTaskAsync(Tasks item)
        {
            var temp = _taskRepository.GetAllAsync().Result.First<Tasks>(t => t.Id == item.Id);
            temp.Completed = !item.Completed;

            return await _taskRepository.UpdateToDoItem(temp);
        }
    }
}
