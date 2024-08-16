﻿using BagXML.Queries;
using BagXML.Services;
using System.Data;
using BagXML.DAL.Repositories.Implementations;
using BagXML.DAL.Repositories.Interfaces;
using System.Data.SQLite;
using Microsoft.Extensions.Configuration;
using BagXML;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>представляет расширение для IServiceCollection</summary>
    public static class ServiceCollectionEx
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnection>(_ => 
            {
                var connection = new SQLiteConnection(configuration["ConnectionStrings:SQLiteProvider"]);

                SQLiteConnection.Changed += (sender, eventArgs) =>
                {
                    Console.Out.WriteLine($"{eventArgs.EventType}: {eventArgs.Text}");
                };

                return connection;
            });

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

            services.AddAutoMapper(typeof(Profiler));
        }
    }
}
