using System.Linq;
using ToDoList.Models;

namespace ToDoList.Services
{
    public static class SampleData
    {
        public static void Initialize(ToDoContext context)
        {
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.Add(new User
            {
                Email = "login@g.com", Name = "User", Password = "1111", 
                ToDoItems = new [] {new ToDoItem {Name = "Task", UserId = 1}}
            });

            context.SaveChanges();
        }
    }
}