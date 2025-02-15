using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Domain.Repositories.User
{
    public interface IUserWrite
    {

        public async Task Add(Entities.User user)
        {
            await _context.Users.AddAsync(user);
            //await _context.SaveChangesAsync();
        }
    }
}
