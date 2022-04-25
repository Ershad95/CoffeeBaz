using CoffeeBaz.Service.CategoryService;
using CoffeeBaz.Service.OrderService;
using CoffeeBaz.Service.ProductService;
using CoffeeBaz.Service.QrCode;
using CoffeeBaz.Service.QrCodeService.CoffeeBaz.Service.QrCode;
using CoffeeBaz.Service.TableService;
using Microsoft.Extensions.DependencyInjection;

namespace CoffeeBaz.Core.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddAllLocalServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IQrCodeService, QrCodeService>();
            services.AddScoped<ITableService, TableService>();
            //services.AddScoped<CoffeeBaz.Data.Context.CoffeBazContext>();
        }

       
    }
}
