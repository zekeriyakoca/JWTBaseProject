using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseJWT.Domain.DTO.Account
{
    public class EmailToAdministratorDto
    {
        public string Email { get; set; }

        public int PhoneCode { get; set; }

        public string PhoneNumber { get; set; }
    }
}
