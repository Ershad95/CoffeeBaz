using CoffeeBaz.Data.DataRepository;
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
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddSingleton<IQrCodeService, QrCodeService>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
