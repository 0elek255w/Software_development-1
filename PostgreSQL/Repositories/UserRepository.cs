using Microsoft.EntityFrameworkCore;
using PostgreSQL.Tables;

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

        public UserEntity? Get(string email, string password, out string errorMessage)
        {
            bool exists = this._DbContext.Users.Any(user => user.Email == email);

            if (!exists)
            {
                errorMessage = $"no user with email {email}";
                return null;
            }

            UserEntity user = this._DbContext.Users
                .AsNoTracking()
                .Where(user => user.Email == email)
                .First();

            if (user.Password != password)
            {
                errorMessage = $"incorrect password";
                return null;
            }

            errorMessage = String.Empty;
            return user;
        }

        public bool Create(UserEntity userToCreate)
        {
            bool exists = this._DbContext.Users.Any(user => user.Email == userToCreate.Email);

            if (exists)
                return false;

            this._DbContext.Users.Add(userToCreate);
            this._DbContext.SaveChanges();

            return true;
        }

        public bool Update(string email, string password, string newName, out string errorMessage)
        {
            bool exists = this._DbContext.Users.Any(user => user.Email == email);

            if (!exists)
            {
                errorMessage = $"no user with email {email}";
                return false;
            }

            UserEntity user = this._DbContext.Users
                .Where(user => user.Email == email)
                .First();

            if (user.Password != password)
            {
                errorMessage = $"incorrect password";
                return false;
            }

            errorMessage = String.Empty;
            user.Name = newName;
            this._DbContext.SaveChanges();
            return true;
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
