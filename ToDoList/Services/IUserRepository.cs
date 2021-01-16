using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IUserRepository
    {
        bool ContainsUserWithEmail(string email);

        Task AddUserAsync(User user);

        bool IsCorrectEmailAndPassword(string email, string password);
        
        User GetUser(string email);
    }
}