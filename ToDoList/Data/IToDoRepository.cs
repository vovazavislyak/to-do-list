using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Data
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