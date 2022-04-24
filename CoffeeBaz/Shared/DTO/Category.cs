using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Shared.DTO;

public class Category: BaseDTO
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool Vip { get; set; }
    public bool Active { get; set; }
}

