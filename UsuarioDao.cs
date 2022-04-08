using Microsoft.Data.Sqlite;

public class UsuarioDao : IUsuarioDao
{

    public UsuarioDao()
    {
        SqliteConnection connection = new SqliteConnection("Data Source=database.db");
        connection.Open();
        
        SqliteCommand command = connection.CreateCommand();
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
        connection.Close();
    }

    public Usuario Save(Usuario usuario)
    {
        SqliteConnection connection = new SqliteConnection("Data Source=database.db");
        connection.Open();
        
        SqliteCommand command = connection.CreateCommand();
        command.CommandText = $"INSERT INTO Usuario VALUES({usuario.Codigo}, '{usuario.Nome}', '{usuario.Email}', '{usuario.Senha}', {usuario.Ativo})";
        command.ExecuteNonQuery();
        connection.Close();

        return usuario;
    }

    public Usuario GetById(int id)
    {
        throw new NotImplementedException();
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
}