using funny.Models;

namespace funny.Builders
{
    public class UserBuilder// добавить fluent api
    {

        private readonly UserDTO _user = new();

        public UserBuilder()
        {
            _user.Id = Guid.NewGuid().ToString();
            _user.Roles = new List<string> { "User" };
            _user.CreatedDatetime = DateTime.UtcNow;
            _user.LastUpdateDatetime = DateTime.UtcNow;
            _user.LastPasswordChangeDatetime = DateTime.UtcNow;
            _user.Archive = false;
            _user.Blocked = false;
        }

        public UserBuilder SetBaseInfo(string fullName, string phone)
        {
            _user.PhoneNumber = phone;

            if (!string.IsNullOrWhiteSpace(fullName))
            {
                var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0) _user.FirstName = parts[0];
                if (parts.Length > 1) _user.Surname = parts[1];
                if (parts.Length > 2) _user.MiddleName = string.Join(" ", parts.Skip(2));
            }

            return this;
        }

        public UserDTO Build() => _user;
    }
}