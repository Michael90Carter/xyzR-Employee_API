using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using xyzR_Employee_API.Model;

public interface IEmployeeCsvService
{
    byte[] ExportEmployeesToCsv(IEnumerable<Employee> employees);
}

public class EmployeeCsvService : IEmployeeCsvService
{
    public byte[] ExportEmployeesToCsv(IEnumerable<Employee> employees)
    {
        using var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

        csvWriter.WriteRecords(employees);
        streamWriter.Flush();

        return memoryStream.ToArray();
    }
}
