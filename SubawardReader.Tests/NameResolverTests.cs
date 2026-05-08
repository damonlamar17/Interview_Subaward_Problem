using SubawardReader;

public class SubawardNameResolverTests
{
    [Theory]
    [InlineData("Indiana University", "Indiana")]
    [InlineData("Mayo Clinic", "Mayo")]
    [InlineData("Purdue Research Foundation", "Purdue")]
    [InlineData("University of Florida", "Florida")]
    public void Resolve_ShouldMapCorrectly(string input, string expected)
    {
        var result = SubawardNameResolver.Resolve(input);

        Assert.Equal(expected, result);
    }
}