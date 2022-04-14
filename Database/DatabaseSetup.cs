namespace IntroDataAccess.Database;

using Microsoft.Data.Sqlite;

public class DatabaseSetup
{
    public DatabaseConfig DatabaseConfig { get; }

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        DatabaseConfig = databaseConfig;
        CreateTableUsuario();
    }

    private void CreateTableUsuario()
    {
        using var connection = new SqliteConnection($"Data Source={DatabaseConfig.DatabaseName}");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='Usuario';";

        object? tableName = command.ExecuteScalar();

        if (tableName != null)
            return;

        command.CommandText =
        @"
        CREATE TABLE IF NOT EXISTS Usuario (
            id int not null primary key,
            nome varchar(100),
            email varchar(100),
            senha varchar(3),
            ativo bool
        );   
        ";
        command.ExecuteNonQuery();
    }
}