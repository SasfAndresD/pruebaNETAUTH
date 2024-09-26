using authtestAdavila.Models;
using System.Collections.Generic;
using System.Linq;

namespace authtestAdavila.Service
{
    public class UserService
    {
        private List<User> _users = new List<User>
    {
        new User { Username = "AdminUser", Password = "admin123", Role = "Admin" },
        new User { Username = "ClientUser", Password = "client123", Role = "Cliente" }
    };

        public User Authenticate(string username, string password)
        {
            return _users.SingleOrDefault(x => x.Username == username && x.Password == password);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }
}
