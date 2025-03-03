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

        public List<UserEntity> AllUserReturn()
        {
            List<UserEntity> userEntity = this._DbContext.UserEntity.ToList();
            return userEntity;
        }

        public void AddUser(UserEntity user)
        {
            this._DbContext.UserEntity.Add(user);
        }
    }
}
