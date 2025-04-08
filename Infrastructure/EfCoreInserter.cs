using ExcelImporterPOC.Domain;
using ExcelImporterPOC.Interfaces;

namespace ExcelImporterPOC.Infrastructure
{
    public class EfCoreInserter : IDataInserter 
    { 
        private readonly string _connectionString;
        
        public EfCoreInserter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task InsertAsync(IEnumerable<Person> people, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}