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

    public static void Write<T>(List<T> data, string fileName, int maxFileSizeMb)
    {
        var MAX_BYTES = maxFileSizeMb * 1000 * 1000;

        List<byte[]> parts = new List<byte[]>();

        using (var memoryStream = new MemoryStream())
        {
            using (var writer = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteHeader<T>();
                csvWriter.NextRecord();
                csvWriter.Flush();
                writer.Flush();

                var headerSize = memoryStream.Length;
                foreach (var record in data)
                {
                    csvWriter.WriteRecord(record);
                    csvWriter.NextRecord();

                    csvWriter.Flush();
                    writer.Flush();

                    if (memoryStream.Length > (MAX_BYTES - headerSize))
                    {
                        parts.Add(memoryStream.ToArray());

                        memoryStream.SetLength(0);
                        memoryStream.Position = 0;

                        csvWriter.WriteHeader<T>();
                        csvWriter.NextRecord();
                    }
                }

                if (memoryStream.Length > headerSize)
                {
                    parts.Add(memoryStream.ToArray());
                }
            }
        }

        if (parts.Count == 1)
        {
            var part = parts.First();

            File.WriteAllBytes(fileName, part);
        }
        else if (parts.Count > 1)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                var part = parts[i];

                File.WriteAllBytes($"{i + 1}of{parts.Count}_{fileName}", part);
            }
        }
    }
}