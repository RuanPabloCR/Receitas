using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Infrastructure.Data.Repository
{   
    public class UserRepository : IUserRead, IUserWrite
    {
        private readonly RecipeBookDbContext _context;
        public UserRepository(RecipeBookDbContext context)
        {
            _context = context;
        }
        public async Task Add(Domain.Entities.User user)
        {
            await _context.Users.AddAsync(user);
            //await _context.SaveChangesAsync();
        }
        public async Task ExistActiveUserWithEmail(string email) =>
            await _context.Users.AnyAsync(u => u.Email == email && u.IsActive);
    }
}
