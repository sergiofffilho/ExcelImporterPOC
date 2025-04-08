using ExcelImporterPOC.Domain;
using ExcelImporterPOC.Interfaces;

namespace ExcelImporterPOC.Infrastructure
{
    public class DapperInserter : IDataInserter 
    {
        private readonly string _connectionString;

        public DapperInserter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task InsertAsync(IEnumerable<Person> people, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}