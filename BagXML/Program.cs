using BagXML.DTOs;
using BagXML.Services;

Console.Out.WriteLine("Initialize...");

var fileName = string.Empty;

var opdService = new OpenFileDialogService();
var serializer = new XMLSerializerService();

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
Console.In.ReadLine();