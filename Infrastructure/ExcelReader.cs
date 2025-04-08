using ExcelDataReader;
using ExcelImporterPOC.Domain;

namespace ExcelImporterPOC.Infrastructure
{
    public class ExcelReader
    {
        public static IEnumerable<Person> Read(string filePath)
        {
            // Register encoding provider before using ExcelDataReader
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);

            var people = new List<Person>();

            while (reader.Read()) // Move through the rows
            {
                var name = reader.GetString(0); // Read the "Name" column
                var ageString = reader.GetValue(1)?.ToString(); // Read the "Age" column

                // Try to convert the age
                if (int.TryParse(ageString, out int age))
                {
                    people.Add(new Person { Name = name, Age = age });                    
                }
                else
                {
                    // If it's not a valid number, you can ignore it or assign a default value
                    people.Add(new Person { Name = name, Age = 0 }); // Example: assign 0 as the default value
                }
            }

            return people;
        }
    }
}
