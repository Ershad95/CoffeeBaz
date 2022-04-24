using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeBaz.Shared.DTO;
public class TableDTO:BaseDTO
{
    [Display(Name = "تعداد صندلی ها")]
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    public int ChairCount { get; set; }
    [Display(Name = "میز رزرو شده است؟")]
    public bool Reserved { get; set; }
    [Display(Name = "شامل سرویس های VIP میباشد")]
    public bool Vip { get; set; }
    [Display(Name = "میز دردسترس میباشد؟")]
    public bool Active { get; set; }
    public bool CleanRequire { get; set; }
    [Display(Name = "بارکد میز")]
    public string QrCode { get; set; }
    [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
    [Display(Name = "شماره میز")]
    public string Number { get; set; }
}

