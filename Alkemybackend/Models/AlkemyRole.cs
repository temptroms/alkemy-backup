using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_backend.Models
{
    public class AlkemyRole : IdentityRole {

        public AlkemyRole() : base()
        {

        }

        public AlkemyRole(string rolName) {
            Name = rolName;
        }

        public class Adminrole{
            public string Usuario { get; set; }
            public string Contraseña { get; set; }
        }
    }
}
