namespace SubawardReader;

public static class SubawardNameResolver
{
    public static string? Resolve(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        var text = input.ToLowerInvariant();

        return text switch
        {
            var s when s.Contains("indiana") => "Indiana",
            var s when s.Contains("mayo") => "Mayo",
            var s when s.Contains("purdue") => "Purdue",
            var s when s.Contains("florida") => "Florida",
            _ => null
        };
    }
}