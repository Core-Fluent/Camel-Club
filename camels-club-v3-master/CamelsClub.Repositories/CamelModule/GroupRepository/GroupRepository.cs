﻿using CamelsClub.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsClub.Repositories
{
    public class GroupRepository : GenericRepository<Models.Group> , IGroupRepository
    {
        public GroupRepository(CamelsClubContext context): base(context)
        {

        }
    }
}
