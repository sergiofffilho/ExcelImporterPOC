using ExcelImporterPOC.Domain;

namespace ExcelImporterPOC.Interfaces
{
    public interface IDataInserter
    {
        Task InsertAsync(IEnumerable<Person> people, CancellationToken cancellationToken = default);
    }
}