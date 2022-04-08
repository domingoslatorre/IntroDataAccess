using Microsoft.Data.Sqlite;

public class UsuarioDao : IUsuarioDao
{
    public UsuarioDao()
    {
        using(var connection = GetConnection())
        {
            connection.Open();
            
            var command = connection.CreateCommand();
            command.CommandText = 
            @"
            CREATE TABLE IF NOT EXISTS Usuario (
                codigo int not null primary key,
                nome varchar(100),
                email varchar(100),
                senha varchar(3),
                ativo bool
            );   
            ";
            command.ExecuteNonQuery();
        }
    }

    public Usuario Save(Usuario usuario)
    {
        using var connection = GetConnection();
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO Usuario VALUES($codigo, $nome, $email, $senha, $ativo)";
        command.Parameters.AddWithValue("$codigo", usuario.Codigo);
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
        command.CommandText = $"SELECT * FROM Usuario WHERE codigo = $id";
        command.Parameters.AddWithValue("$id", id);

        using var reader = command.ExecuteReader();
        return ReaderToUsuario(reader);
        
    }

    public List<Usuario> GetAll()
    {
        throw new NotImplementedException();
    }

    public Usuario Update(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    private SqliteConnection GetConnection() => new SqliteConnection("Data Source=database.db");

    private Usuario ReaderToUsuario(SqliteDataReader reader) {
        while(reader.Read()) {
            Usuario usuario = new Usuario(
                reader.GetInt32(0), 
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetBoolean(4)                
            );
            return usuario;
        }
        throw new Exception("User notfound");
    }
}