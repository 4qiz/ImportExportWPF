using Microsoft.EntityFrameworkCore;
using Task2.Data;
using Task2.Models;

namespace Task2.Repositories
{
    public class UsersRepository
    {
        private readonly AppDbContext _context;

        public UsersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LW1User>> GetAllAsync()
        {
            using var context = new AppDbContext();
            return await context.Users.ToListAsync();
        }

        public async Task AddRangeAsync(List<LW1User> users)
        {
            using var context = new AppDbContext();
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
