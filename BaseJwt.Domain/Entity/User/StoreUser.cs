using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BaseJWT.Domain.Entity
{
    public class User : IdentityUser
    {
        string email = String.Empty;

        public User(string email)
            : this()
        {
            IsEnabled = true;
            this.email = email;
        }

        public User()
        {
        }

        public override string Email
        {
            get => email;
            set => email = string.IsNullOrWhiteSpace(value) ? string.Empty : value.ToLower();
        }

        public bool IsEnabled { get; set; }
        public string FcmToken { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserFullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

    }
}
