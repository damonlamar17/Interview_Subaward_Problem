using SubawardReader;

var parser = new SubawardParser();
var folder = Path.Combine(Directory.GetCurrentDirectory(), "Examples");

var totals = parser.ParseFolder(folder);

Console.WriteLine("\nTotal Subawards Across Files\n");

foreach (var item in totals.OrderByDescending(x => x.Value))
{
    Console.WriteLine($"{item.Key,-25} {item.Value,15:C}");
}