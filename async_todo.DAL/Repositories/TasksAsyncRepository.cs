using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using async_todo.DAL.Entities;
using async_todo.DAL.Interfaces;
using System.Linq;

namespace async_todo.DAL.Repositories
{
    public class TasksAsyncRepository<T>:ITasksAsyncRepository<T> where T:class
    {
        private ToDoDbContext _context;

        public TasksAsyncRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetTodoItem(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddToDoItem(T item)
        {
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> UpdateToDoItem(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<T> Delete(T item)
        {
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }
    }
}
