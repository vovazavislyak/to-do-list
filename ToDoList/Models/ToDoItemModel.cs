using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;

namespace ToDoList.Models
{
    public class ToDoItemModel
    {
        [HiddenInput]
        public int Id { get; set; }
        
        [Display(Name = "Task name")]
        public string Name { get; set; }
        
        [Display(Name = "Task description")]
        public string Description { get; set; }
        
        [Display(Name = "Date and time")]
        public DateTime Deadline { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public ToDoItemModel() {}
        
        public ToDoItemModel(int id, string name, string description,
                             DateTime deadline, bool isCompleted = false)
        {
            Id = id;
            Name = name;
            Description = description;
            Deadline = deadline;
            IsCompleted = isCompleted;
        }
    }
}