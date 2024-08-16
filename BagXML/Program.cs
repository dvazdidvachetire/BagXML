using BagXML.Models;
using BagXML.Queries;
using BagXML.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

Console.Title = Assembly.GetAssembly(typeof(Program))!
                        .GetName().Name!;
Console.Out.WriteLine("Запуск...\n");

var builder = Host.CreateApplicationBuilder(args);

var configuration = builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                                         .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                                         .Build();

builder.Services.RegisterServices(configuration);

using var host = builder.Build();

var fileName = string.Empty;

var opdService = builder.Services.BuildServiceProvider()
                                 .GetRequiredService<OpenFileDialogService>();
var serializer = builder.Services.BuildServiceProvider()
                                 .GetRequiredService<XMLSerializerService>();

var ordersQueries = builder.Services.BuildServiceProvider()
                                    .GetRequiredService<OrderQueries>();

var thread = new Thread(() => opdService.OpenFileDialog(out fileName));
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();

if (fileName is { Length: > 0})
{
    using var fs = new FileStream(fileName, FileMode.Open);
        
    serializer.Deserialize(fs);
    var orders = serializer.DeserializeObject as Orders;

    foreach (var order in orders!.OrdersCollection)
        ordersQueries.Create(order);

    Console.Out.WriteLine("\nДанные были сохранены в базу данных");
}

Console.Out.WriteLine("Для выхода нажмите на любую клавишу...");
Console.In.ReadLine();