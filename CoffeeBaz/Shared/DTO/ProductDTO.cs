using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Shared.DTO;

public class ProductDTO:BaseDTO
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public bool Vip { get; set; }
    public decimal Price { get; set; }
    public int CatergoryId { get; set; }

    public bool Active { get; set; }
}

