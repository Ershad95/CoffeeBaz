using AutoMapper;
using CoffeeBaz.Service.ProductService;
using CoffeeBaz.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeBaz.Web.Pages
{
    public class productDetailsModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public productDetailsModel(IProductService productService,IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public ProductDTO productDto { get; set; }
        
        public  void OnGet(int id,CancellationToken cancellationToken)
        {
            productDto = _mapper.Map<ProductDTO>(_productService.GetById(id, cancellationToken).Result);
            var t = productDto;
        }
    }
}
