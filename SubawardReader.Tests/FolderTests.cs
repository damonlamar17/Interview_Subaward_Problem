using SubawardReader;

public class SubawardFolderTests
{
    [Fact]
    public void ParseFolder_ShouldAggregateMultipleFiles()
    {
        var parser = new SubawardParser();

        var path = Path.Combine(AppContext.BaseDirectory, "TestData");

        var results = parser.ParseFolder(path);

        Assert.True(results.Count >= 4);
    }
}