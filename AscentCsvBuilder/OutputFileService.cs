using CsvHelper;
using System.Globalization;

namespace AscentCsvBuilder;

public class OutputFileService
{
    public static void Write<T>(List<T> data)
    {
        var fileName = typeof(T).Name.ToLower() + ".csv";
        using (var writer = new StreamWriter(fileName))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(data);
        }
    }
}