using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAllTask();

        void AddTask(ToDoItem item);

        void ChangeIsCompleted(int id, bool isCompleted);
    }
}