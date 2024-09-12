using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Repositories
{
    public static class UsersRepository
    {
        private static AppDbContext _context = new AppDbContext();

        public static async Task<List<LW1User>> GetAllAsync()
        {
            using var context = new AppDbContext();
            return await context.Users.ToListAsync();
        }

        public static async Task AddRangeAsync(List<LW1User> users)
        {
            using var context = new AppDbContext();
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        public static async Task AddAsync(LW1User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public static async Task<bool> UserExistAsync(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }
    }
}
