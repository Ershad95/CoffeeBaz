﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Shared.DTO;
public class Table:BaseEntity
{
    public int ChairCount { get; set; }
    public bool Reserved { get; set; }
    public bool Vip { get; set; }

    public string QrCode { get; set; }
    public string Number { get; set; }
}

