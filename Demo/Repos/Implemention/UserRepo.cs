using Demo.AppContext;
using Demo.GenericRepo;
using Demo.Models;
using Demo.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repos.Implemention
{
    public class UserRepo : Generic<User>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Email == email);
        }
    }
}
