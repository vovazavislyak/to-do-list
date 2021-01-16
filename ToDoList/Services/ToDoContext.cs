using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services
{
    public sealed class ToDoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}