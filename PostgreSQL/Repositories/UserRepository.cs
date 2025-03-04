using Microsoft.EntityFrameworkCore;
using PostgreSQL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQL.Repositories
{
    public class UserRepository
    {
        private readonly DbContextFOS _DbContext;

        public UserRepository(DbContextFOS dbContext)
        {
            _DbContext = dbContext;
        }

        public List<UserEntity> Get()
        {
            List<UserEntity> users = this._DbContext.Users
                .AsNoTracking()
                .ToList();

            return users;
        }

        public UserEntity Get(Guid ID)
        {
            UserEntity user = this._DbContext.Users
                .AsNoTracking()
                .Where(user => user.ID == ID)
                .First();

            return user;
        }

        public Guid Create(UserEntity user)
        {
            this._DbContext.Users.Add(user);
            this._DbContext.SaveChanges();

            return user.ID;
        }

        public Guid Update(Guid ID, string name)
        {
            this._DbContext.Users
                .Where(user => user.ID == ID)
                .ExecuteUpdate(user => user
                    .SetProperty(user => user.Name, user => name)
                );

            return ID;
        }

        public Guid Delete(Guid ID)
        {
            this._DbContext.Users
                .Where(book => book.ID == ID)
                .ExecuteDelete();

            return ID;
        }
    }
}
