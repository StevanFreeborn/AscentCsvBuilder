using CsvHelper;
using System.Globalization;

namespace AscentCsvBuilder;

public class OutputFileService
{
    public static void Write<T>(List<T> data, string fileName)
    {
        using (var writer = new StreamWriter(fileName))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(data);
        }
    }
}