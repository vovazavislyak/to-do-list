using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAllTask(int userId);

        Task AddTaskAsync(ToDoItem item);

        Task ChangeIsCompletedAsync(int id, bool isCompleted);

        Task EditTaskAsync(ToDoItem changedItem);

        Task RemoveAsync(int id);
    }
}