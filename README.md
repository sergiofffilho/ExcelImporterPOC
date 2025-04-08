# ExcelImporterPOC - IN PROGESS

This is a proof of concept (POC) application that demonstrates how to import a large Excel file (5 million rows) into an SQL Server database using C#. The application uses the `ExcelDataReader` library for reading Excel files and `SqlBulkCopy` for efficient data insertion into the database.

## Requirements

- .NET 6.0 or higher
- SQL Server (LocalDB or an external instance)
- Excel file (with sample data)

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ExcelImporterPOC.git
   cd ExcelImporterPOC
2. Install the required dependencies:
    ```bash
    dotnet restore
3. Set up your SQL Server instance and create the database and table.
4. Update the connection string in the application (in the appsettings.json or directly in the code) to point to your SQL Server instance.
5. Build and run the project:
    ```bash
    dotnet build
    dotnet run sqlbulk <path_to_your_excel_file>
## Usage
The program reads an Excel file and inserts its content into the People table in the SQL Server database.

The People table should have the following schema:
    bash```
    sql

    CREATE TABLE People (
        Name NVARCHAR(100),
        Age INT
    );
## Troubleshooting
If you get an SSL certificate error when connecting to SQL Server, you may need to install a trusted certificate or disable encryption for the connection.

Ensure that the Excel file is properly formatted, with Name in the first column and Age in the second column.