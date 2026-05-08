using SubawardReader;
using Xunit;
using System.IO;
using System.Linq;

public class ParserTests
{
    [Fact]
    public void ExampleFiles()
    {
        var parser = new SubawardParser();

        string solutionRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "..")
        );

        string path = Path.Combine(
            solutionRoot,
            "Examples",
            "SubawardBudgetExample1.xlsx"
        );

<<<<<<< HEAD
=======

>>>>>>> ffe5b4c28b9a6b977b78db99a1366092d8bc38cb
        Assert.True(File.Exists(path), $"File not found: {path}");

        var results = parser.ParseFile(path)
            .ToDictionary(x => x.Name, x => x.Amount);

        Console.WriteLine("Subrecipients Found:");
        foreach (var key in results.Keys)
        {
            Console.WriteLine(key);
        }

        Assert.Contains("Indiana", results.Keys);
        Assert.Contains("Mayo", results.Keys);
        Assert.Contains("Purdue", results.Keys);
        Assert.Contains("Florida", results.Keys);

        Assert.Equal(4, results.Keys.Count);
    }
}