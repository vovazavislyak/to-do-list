using System.Linq;

namespace ToDoList.Data
{
    public class SampleData
    {
        public static void Initialize(ToDoContext context)
        {
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            context.Users.Add(new User
            {
                Login = "login", Name = "User", Password = "1111", 
                ToDoItems = new [] {new ToDoItem {Name = "Task", UserId = 1}}
            });

            context.SaveChanges();
        }
    }
}