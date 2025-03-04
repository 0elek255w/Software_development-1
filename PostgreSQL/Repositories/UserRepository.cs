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

        public UserEntity? Get(string email, string password)
        {
            UserEntity user = this._DbContext.Users
                .AsNoTracking()
                .Where(user => user.Email == email)
                .First();

            if (user.Password != password)
                return null;

            return user;
        }

        public Guid Create(UserEntity user)
        {
            this._DbContext.Users.Add(user);
            this._DbContext.SaveChanges();

            return user.ID;
        }

        public string Update(string email, string name)
        {
            this._DbContext.Users
                .Where(user => user.Email == email)
                .ExecuteUpdate(user => user
                    .SetProperty(user => user.Name, user => name)
                );

            return email;
        }

        public bool Delete(string email, string password)
        {
            UserEntity userToDelete = this._DbContext.Users
                .Where(user => user.Email == email)
                .First();

            if (userToDelete.Password != password)
                return false;

            this._DbContext.Users
                .Where(user => (user.ID == userToDelete.ID))
                .ExecuteDelete();

            return true;
        }
    }
}
