using BagXML.Models;
using BagXML.Queries;
using BagXML.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.Out.WriteLine("Initialize...");

var builder = Host.CreateApplicationBuilder(args);

builder.Services.RegisterServices();

using var host = builder.Build();

var fileName = string.Empty;

var opdService = builder.Services.BuildServiceProvider()
                                 .GetRequiredService<OpenFileDialogService>();
var serializer = builder.Services.BuildServiceProvider()
                                 .GetRequiredService<XMLSerializerService>();

var user = builder.Services.BuildServiceProvider()
                           .GetRequiredService<UserQueries>();
user.Create(new User());

var thread = new Thread(() => opdService.OpenFileDialog(out fileName));
thread.SetApartmentState(ApartmentState.STA);
thread.Start();
thread.Join();

if (fileName is { Length: > 0})
{
    using var fs = new FileStream(fileName, FileMode.Open);
        
    serializer.Deserialize(fs);
    var orders = serializer.DeserializeObject as Orders;
}

Console.Out.WriteLine("Done!");