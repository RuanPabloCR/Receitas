using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Domain.Repositories.User
{
    public interface IUserRead
    {
        public async Task ExistActiveUserWithEmail(string email) { } /*=>
            await _context.Users.AnyAsync(u => u.Email == email && u.IsActive);
        */
    }
}
