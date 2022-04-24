using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Shared.DTO;

public class CategoryDTO: BaseDTO
{
    [Display(Name ="نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public string Name { get; set; }
    [Display(Name="تصویر")]
    public string Image { get; set; }
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public string Description { get; set; }
    [Display(Name = "آیا VIP میباشد؟")]
    public bool Vip { get; set; }
    [Display(Name = "آیا فعال است؟")]
    public bool Active { get; set; }
}

