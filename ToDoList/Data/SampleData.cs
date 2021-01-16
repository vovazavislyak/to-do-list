using System.Linq;

namespace ToDoList.Data
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
                Email = "login", Name = "User", Password = "1111", 
                ToDoItems = new [] {new ToDoItem {Name = "Task", UserId = 1}}
            });

            context.SaveChanges();
        }
    }
}