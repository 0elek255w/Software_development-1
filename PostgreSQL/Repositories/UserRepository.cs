using Microsoft.EntityFrameworkCore;
using PostgreSQL.Tables;
using PostgreSQL.Objects;
using PostgreSQL;

namespace PostgreSQL.Repositories
{
    public class UserRepository
    {
        private readonly DbContextFOS _DbContext;

        public UserRepository(DbContextFOS dbContext)
        {
            _DbContext = dbContext;
        }

        public bool Exists(string email)
        {
            return this._DbContext.Users.Any(user => user.Email == email);
        }

        public bool Exists(Guid ID)
        {
            return this._DbContext.Users.Any(user => user.ID == ID);
        }

        public UserEntity? Get(string email, string password, out string errorMessage)
        {
            if (!this.Exists(email))
            {
                errorMessage = $"no user with email {email} exists";
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

            errorMessage = string.Empty;
            return user;
        }

        public bool Create(UserObject user, out string errorMessage)
        {
            if (this.Exists(user.Email))
            {
                errorMessage = $"user with email {user.Email} already exists";
                return false;
            }

            UserEntity userToCreate = new UserEntity()
            {
                ID = Guid.NewGuid(),
                Email = user.Email,
                Password = user.Password, // TODO: can be null
                Name = user.Name, // TODO: can be null
                Image = user.Image == null ? string.Empty : user.Image,
                Type = UserTypes.User
            };

            userToCreate.ID = Guid.NewGuid();
            this._DbContext.Users.Add(userToCreate);
            this._DbContext.SaveChanges();

            errorMessage = string.Empty;
            return true;
        }

        public bool Update(string email, string password, string? newName, string? newImage, out string errorMessage)
        {
            if (!this.Exists(email))
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

            if (newName != null)
                user.Name = newName;

            if (newImage != null)
                user.Image = newImage;

            errorMessage = string.Empty;
            this._DbContext.SaveChanges();
            return true;
        }

        public bool Delete(string email, string password, out string errorMessage)
        {
            if (!this.Exists(email))
            {
                errorMessage = $"no user with email {email}";
                return false;
            }

            UserEntity userToDelete = this._DbContext.Users
                .Where(user => user.Email == email)
                .First();

            if (userToDelete.Password != password)
            {
                errorMessage = "incorrect password";
                return false;
            }

            this._DbContext.Users
                .Where(user => (user.ID == userToDelete.ID))
                .ExecuteDelete();

            errorMessage = string.Empty;
            return true;
        }
    }
}
