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
        command.CommandText = $"SELECT * FROM Usuario";

        using var reader = command.ExecuteReader();
        return ReaderToListOfUsuarios(reader);
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