using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Shared.DTO;

public class BaseDTO
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
}

