using System.Threading.Tasks;
using async_todo.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace async_todo.DAL.Interfaces
{
    public interface ITasksAsyncRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetTodoItem(int id);
        Task<T> AddToDoItem(T item);
        Task<T> UpdateToDoItem(T item);
        Task<T> Delete(T item);
        IQueryable<T> Query();
    }
}