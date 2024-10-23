using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Core.Models
{
    public class User
    {
        private User(Guid id, string userName, string passwordHash)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            //Email = email;
        }

        public Guid Id { get; }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        //public string Email { get; }

        public static User Create(Guid id, string userName, string passwordHash)
        {
            return new User(id, userName, passwordHash);
        }
    }
}
