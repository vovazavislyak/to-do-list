﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly List<ToDoItem> _items = new List<ToDoItem>
        {
            new ToDoItem(1, "English", "Description", DateTime.Parse("18.09.2020 18:00")),
            new ToDoItem(2, "ASP.Net in Action", "", DateTime.MinValue),
            new ToDoItem(3, "JS", "", DateTime.MinValue),
            new ToDoItem(4, "ASP.Net in Action", "", DateTime.MinValue),
            new ToDoItem(5, "ASP.Net in Action", "", DateTime.MinValue),
            new ToDoItem(6, "ASP.Net in Action", "", DateTime.MinValue),
            new ToDoItem(7, "ASP.Net in Action", "", DateTime.MinValue),
            new ToDoItem(8, "ASP.Net in Action", "", DateTime.MinValue),
        };

        public IEnumerable<ToDoItem> GetAllTask() => _items;

        public void AddTask(ToDoItem item)
        {
            item.Id = (_items.Any() ?
                _items.Max(x => x.Id) : 0) + 1;
            _items.Add(item);
        }

        public void ChangeIsCompleted(int id, bool isCompleted) =>
            GetById(id).IsCompleted = isCompleted;

        public void EditTask(ToDoItem changedItem)
        {
            var item = GetById(changedItem.Id);
            var index = _items.IndexOf(item);
            _items[index] = changedItem;
        }

        public ToDoItem GetById(int id)
        {
            Debug.WriteLine($"GetById: id - {id}");
            return _items.First(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Debug.WriteLine($"ToDoRepository.Remove: id - {id}");
            var item = GetById(id);
            _items.Remove(item);
        }
    }
}