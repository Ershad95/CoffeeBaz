﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Data.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime{ get; set; }
    }
}
