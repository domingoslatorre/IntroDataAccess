using Microsoft.Data.Sqlite;

public class UsuarioRepository : IUsuarioRepository
{
    public DatabaseConfig DatabaseConfig { get; }
    
    public UsuarioRepository(DatabaseConfig databaseConfig)
    {
        DatabaseConfig = databaseConfig;
    }

    public Usuario Save(Usuario usuario)
    {
        using var connection = GetConnection();
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO Usuario VALUES($id, $nome, $email, $senha, $ativo);";
        command.Parameters.AddWithValue("$id", usuario.Id);
        command.Parameters.AddWithValue("$nome", usuario.Nome);
        command.Parameters.AddWithValue("$email", usuario.Email);
        command.Parameters.AddWithValue("$senha", usuario.Senha);
        command.Parameters.AddWithValue("$ativo", usuario.Ativo);
        command.ExecuteNonQuery();

        return usuario;
    }

    public Usuario GetById(int id)
    {
        using var connection = GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM Usuario WHERE id = $id;";
        command.Parameters.AddWithValue("$id", id);

        using var reader = command.ExecuteReader();
        if(reader.Read()) {
            return ReaderToUsuario(reader);
        }
        throw new Exception("User not found");
        
    }

    public List<Usuario> GetAll()
    {
        using var connection = GetConnection();
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = $"SELECT * FROM Usuario;";

        using var reader = command.ExecuteReader();
        return ReaderToListOfUsuarios(reader);
    }

    public Usuario Update(Usuario usuario)
    {
        using var connection = GetConnection();
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = 
        @" 
        UPDATE Usuario 
        SET nome=$nome, email=$email, senha=$senha, ativo=$ativo
        WHERE id=$id;
        ";
        command.Parameters.AddWithValue("$id", usuario.Id);
        command.Parameters.AddWithValue("$nome", usuario.Nome);
        command.Parameters.AddWithValue("$email", usuario.Email);
        command.Parameters.AddWithValue("$senha", usuario.Senha);
        command.Parameters.AddWithValue("$ativo", usuario.Ativo);
        
        command.ExecuteNonQuery();
        
        return GetById(usuario.Id);
    }

    public void Delete(int id)
    {
        using var connection = GetConnection();
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = $"DELETE FROM Usuario WHERE id=$id;";
        command.Parameters.AddWithValue("$id", id);
        command.ExecuteNonQuery();
    }

    private SqliteConnection GetConnection() => new SqliteConnection($"Data Source={DatabaseConfig.DatabaseName}");

    private Usuario ReaderToUsuario(SqliteDataReader reader) 
    {
        Usuario usuario = new Usuario(
            reader.GetInt32(0), 
            reader.GetString(1),
            reader.GetString(2),
            reader.GetString(3),
            reader.GetBoolean(4)                
        );
        return usuario;
    }

    private List<Usuario> ReaderToListOfUsuarios(SqliteDataReader reader) 
    {
        var usuarios = new List<Usuario>();
        while(reader.Read()) {
            usuarios.Add(ReaderToUsuario(reader));
        }
        return usuarios;
    }
}