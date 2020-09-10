using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly List<ToDoItem> _items = new List<ToDoItem>
        {
            new ToDoItem(1, "English", "Description", DateTime.Parse("18.09.2020 18:00")),
            new ToDoItem(2, "ASP.Net in Action", "", DateTime.MinValue),
            new ToDoItem(3, "JS", "", DateTime.MinValue)
        };

        public IEnumerable<ToDoItem> GetAllTask()
        {
            return _items;
        }

        public void AddTask(ToDoItem item)
        {
            item.Id = _items.Max(x => x.Id) + 1;
            _items.Add(item);
        }

        public void ChangeIsCompleted(int id, bool isCompleted)
        {
            _items.First(x => x.Id == id).IsCompleted = isCompleted;
        }
    }
}