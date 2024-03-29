﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.Models
{
    public class RolePagePermission : BaseModel
    {
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public int PageID { get; set; }
        public virtual Page Page { get; set; }
        public int PermissionID { get; set; }
        public virtual Permission Permission { get; set; }
  
    }
}
