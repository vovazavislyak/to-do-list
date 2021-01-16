using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Services
{
    public interface IUserRepository
    {
        Task<bool> ContainsUserWithEmailAsync(string email);

        Task AddUserAsync(User user);

        Task<bool> IsCorrectEmailAndPasswordAsync(string email, string password);
        
        Task<User> GetUserAsync(string email);
    }
}