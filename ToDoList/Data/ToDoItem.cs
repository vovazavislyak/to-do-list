using System;

namespace ToDoList.Data
{
    public class ToDoItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public bool IsCompleted { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ToDoItem()
        {
            
        }
        
        public ToDoItem(int id, string name, string description = "",
                        DateTime? deadline = default, bool isCompleted = false)
        {
            Id = id;
            Name = name;
            Description = description;
            Deadline = deadline;
            IsCompleted = isCompleted;
        }
    }
}