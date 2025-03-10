namespace PostgreSQL.Objects
{
    public class UserObject
    {
        public Guid? ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public string? Type { get; set; } = string.Empty;

        public UserObject(Guid? iD, string email, string? password, string? name, string? image, string? type)
        {
            ID = iD;
            Email = email;
            Password = password;
            Name = name;
            Image = image;
            Type = type;
        }
    }
}
