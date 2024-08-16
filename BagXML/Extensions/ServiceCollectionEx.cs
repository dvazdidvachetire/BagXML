using BagXML.Queries;
using BagXML.Services;
using System.Data;
using BagXML.DAL.Repositories.Implementations;
using BagXML.DAL.Repositories.Interfaces;
using System.Data.SQLite;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionEx
    {
        /// <summary>Расширение для IServiceCollection</summary>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(_ => new SQLiteConnection("Data Source=shop.db;"));

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductOrderRepository, ProductOrderRepository>();

            services.AddScoped<OpenFileDialogService>();
            services.AddScoped<XMLSerializerService>();
                        
            services.AddScoped<OrderQueries>();
            services.AddScoped<ProductOrderQueries>();
            services.AddScoped<ProductQueries>();
            services.AddScoped<UserQueries>();
        }
    }
}
