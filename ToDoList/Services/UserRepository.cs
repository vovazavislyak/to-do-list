using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoContext _context;

        public UserRepository(ToDoContext context)
        {
            _context = context;
        }
        
        public async Task<bool> ContainsUserWithEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(user => user.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsCorrectEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Users.AnyAsync(user => user.Email == email && user.Password == password);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users.FirstAsync(user => user.Email == email);
        }
    }
}