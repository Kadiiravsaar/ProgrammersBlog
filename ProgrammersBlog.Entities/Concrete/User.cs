﻿using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public int RoleId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } // hashlemek için byte kullandık
        public string UserName { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public Role Role { get; set; }
        public ICollection<Article> Articles { get; set; }

    }
}
