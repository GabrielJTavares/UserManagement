﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Domain.Shared
{
    public abstract class BaseEntity
    {
        public abstract void Inactivate();
        public abstract void Activate();
    }
}
