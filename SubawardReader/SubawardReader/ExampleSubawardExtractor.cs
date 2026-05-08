using ClosedXML.Excel;

namespace SubawardReader;

public class ExampleSubawardExtractor
{
    public IEnumerable<SubawardRecord> Extract(IXLWorksheet ws)
    {
        bool inSection = false;

        foreach (var row in ws.RowsUsed())
        {
            var rowText = string.Join(" ", row.Cells().Select(c => c.GetString()));

            if (rowText.Contains("G. Other Direct Costs"))
            {
                inSection = true;
                continue;
            }

            if (inSection && rowText.StartsWith("H."))
                yield break;

            if (!inSection)
                continue;

            if (!rowText.Contains("Subaward:") ||
                rowText.Contains("Total") ||
                rowText.Contains("Exempt"))
                continue;

            var raw = rowText[(rowText.IndexOf("Subaward:") + "Subaward:".Length)..]
                .Trim()
                .ToLower();

            var name = SubawardNameResolver.Resolve(raw);
            if (name == null)
                continue;

            decimal amount = row.Cells()
                .Select(c => c.GetString()
                    .Replace("$", "")
                    .Replace(",", "")
                    .Trim())
                .Where(t => decimal.TryParse(t, out _))
                .Select(decimal.Parse)
                .FirstOrDefault();

            yield return new SubawardRecord(name, amount);
        }
    }
}