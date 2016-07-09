using System.Data.Entity;
using System.Linq;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Specs;
using MyStore.Domain.Repositories;
using MyStore.Infra.Persistence.Contexts;

namespace MyStore.Infra.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly MyStoreDataContext _context;

        public UserRepository(MyStoreDataContext context)
        {
            _context = context;
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = EntityState.Modified;
        }

        public User GetUserByUsername(string username)
        {
            return _context
                .Users
                .Where(UserSpecs.GetByUsername(username))
                .FirstOrDefault();
        }

        public User GetByAuthorizationCode(string authorizationCode)
        {
            return _context
                .Users
                .Where(UserSpecs.GetByAuthorizationCode(authorizationCode))
                .FirstOrDefault();
        }
    }
}