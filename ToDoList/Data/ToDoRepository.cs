using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoItem> GetAllTask(int userId) => 
            _context.ToDoItems.Where(item => item.UserId == userId);

        public async Task AddTaskAsync(ToDoItem item)
        {
            await _context.ToDoItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeIsCompletedAsync(int id, bool isCompleted)
        {
            var item = await GetByIdAsync(id);
            
            item.IsCompleted = isCompleted;

            await _context.SaveChangesAsync();
        }

        public async Task EditTaskAsync(ToDoItem changedItem)
        {
            _context.ToDoItems.Update(changedItem);

            await _context.SaveChangesAsync();
        }

        private async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FirstAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            _context.ToDoItems.Remove(new ToDoItem {Id = id});

            await _context.SaveChangesAsync();
        }
    }
}