using Ihatedthiswork.БД_классы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ihatedthiswork
{
    public class UserService
    {
        private readonly DBforISGameContext _dbContext;

        public UserService(DBforISGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Получить пользователя по ID
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        // Регистрация пользователя
        public async Task RegisterUserAsync(string username, string email)
        {
            if (!ValidationHelper.IsValidEmail(email))
            {
                throw new ArgumentException("Неверный формат email.");
            }

            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Пользователь с таким email уже существует.");
            }

            var newUser = new User
            {
                Username = username,
                Email = email,
                DateJoined = DateTime.Now,
                LastLogin = DateTime.Now
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }
    }

}
