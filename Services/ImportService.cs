using ExcelImporterPOC.Interfaces;
using ExcelImporterPOC.Infrastructure;

namespace ExcelImporterPOC.Services
{
    public class ImportService
    {
        private readonly IDataInserter _inserter;

        public ImportService(IDataInserter inserter)
        {
            _inserter = inserter;
        }

        public async Task ImportAsync(string filePath, CancellationToken cancellationToken = default)
        {
            var people = ExcelReader.Read(filePath);
            await _inserter.InsertAsync(people, cancellationToken);
        }
    }
}
