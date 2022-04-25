
using System.ComponentModel.DataAnnotations;
namespace CoffeeBaz.Shared.DTO;

public class ProductDTO:BaseDTO
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public string Name { get; set; }
    [Display(Name = "تصویر")]
    public string Image { get; set; }
    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public string Description { get; set; }
    [Display(Name = "آیا VIP میباشد؟")]
    public bool Vip { get; set; }
    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public decimal Price { get; set; }
    public int CatergoryId { get; set; }
    [Display(Name = "آیا فعال میباشد؟")]
    public bool Active { get; set; }
}

