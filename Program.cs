// Program.cs
using ExcelImporterPOC.Infrastructure;
using ExcelImporterPOC.Interfaces;
using ExcelImporterPOC.Services;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: dotnet run <strategy> <excel_path>");
            return;
        }

        string strategy = args[0].ToLower();
        string excelPath = args[1];
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=ExcelImportDB;Trusted_Connection=True;TrustServerCertificate=True;";

        IDataInserter inserter = strategy switch
        {
            "sqlbulk" => new SqlBulkCopyInserter(connectionString),
            "dapper" => new DapperInserter(connectionString),
            "ef" => new EfCoreInserter(connectionString),
            _ => throw new ArgumentException("Estratégia inválida. Use: sqlbulk, dapper ou ef.")
        };

        var service = new ImportService(inserter);
        await service.ImportAsync(excelPath);
    }
}
