using Ihatedthiswork.БД_классы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ihatedthiswork
{
    public class FriendService
    {
        private readonly DBforISGameContext _dbContext;

        public FriendService(DBforISGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Добавление друга
        public async Task AddFriendAsync(int currentUserId, int friendUserId)
        {
            if (currentUserId == friendUserId)
            {
                throw new ArgumentException("Невозможно добавить себя в друзья.");
            }

            var existingFriendship = await _dbContext.Friends
                .FirstOrDefaultAsync(f =>
                    (f.UserId1 == currentUserId && f.UserId2 == friendUserId) ||
                    (f.UserId1 == friendUserId && f.UserId2 == currentUserId));

            if (existingFriendship != null)
            {
                throw new InvalidOperationException("Этот пользователь уже в вашем списке друзей.");
            }

            var newFriendship = new Friend
            {
                UserId1 = currentUserId,
                UserId2 = friendUserId
            };

            await _dbContext.Friends.AddAsync(newFriendship);
            await _dbContext.SaveChangesAsync();
        }

        // Удаление друга
        public async Task RemoveFriendAsync(int currentUserId, int friendUserId)
        {
            var friendship = await _dbContext.Friends
                .FirstOrDefaultAsync(f =>
                    (f.UserId1 == currentUserId && f.UserId2 == friendUserId) ||
                    (f.UserId1 == friendUserId && f.UserId2 == currentUserId));

            if (friendship == null)
            {
                throw new InvalidOperationException("Этот пользователь не найден в вашем списке друзей.");
            }

            _dbContext.Friends.Remove(friendship);
            await _dbContext.SaveChangesAsync();
        }

        // Получение списка друзей
        public async Task<List<User>> GetFriendsAsync(int userId)
        {
            var friends = await _dbContext.Friends
                .Where(f => f.UserId1 == userId || f.UserId2 == userId)
                .Select(f => f.UserId1 == userId ? f.UserId2 : f.UserId1)
                .ToListAsync();

            var friendUsers = await _dbContext.Users
                .Where(u => friends.Contains(u.UserId))
                .ToListAsync();

            return friendUsers;
        }
    }

}
