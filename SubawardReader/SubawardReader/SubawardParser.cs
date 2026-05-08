using ClosedXML.Excel;

namespace SubawardReader;

public class SubawardParser
{
    private readonly ExampleSubawardExtractor _extractor = new();

    public Dictionary<string, decimal> ParseFolder(string folderPath)
    {
        return Directory.GetFiles(folderPath, "*.xlsx")
            .SelectMany(ParseFile)
            .GroupBy(r => r.Name)
            .ToDictionary(
                g => g.Key,
                g => g.Sum(x => x.Amount),
                StringComparer.OrdinalIgnoreCase);
    }

    public IEnumerable<SubawardRecord> ParseFile(string filePath)
    {
        using var workbook = new XLWorkbook(filePath);
        var ws = workbook.Worksheets.First();

        return _extractor.Extract(ws).ToList();
    }
}