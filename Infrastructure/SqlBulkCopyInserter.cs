using ExcelImporterPOC.Domain;
using ExcelImporterPOC.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ExcelImporterPOC.Infrastructure
{
    public class SqlBulkCopyInserter : IDataInserter
    {
        private readonly string _connectionString;

        public SqlBulkCopyInserter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InsertAsync(IEnumerable<Person> people, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            var dataTable = ConvertToDataTable(people); // Método para converter a lista em DataTable

            using var bulkCopy = new SqlBulkCopy(connection)
            {
                DestinationTableName = "People" // Nome da tabela no banco
            };
            
            bulkCopy.ColumnMappings.Add("Name", "Name");  // Nome da coluna no DataTable e no banco
            bulkCopy.ColumnMappings.Add("Age", "Age");    // Nome da coluna no DataTable e no banco  

            await bulkCopy.WriteToServerAsync(dataTable, cancellationToken);
        }


        private DataTable ConvertToDataTable(IEnumerable<Person> people)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Age");

            foreach (var person in people)
            {
                dataTable.Rows.Add(person.Name, person.Age);
            }

            return dataTable;
        }
    }
}
