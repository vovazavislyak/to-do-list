using System.Collections.Generic;

namespace ToDoList.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAllTask();

        void AddTask(ToDoItem item);

        void ChangeIsCompleted(int id, bool isCompleted);

        void EditTask(ToDoItem changedItem);

        ToDoItem GetById(int id);

        void Remove(int id);
    }
}