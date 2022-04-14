using Microsoft.Data.Sqlite;
using Dapper;

public class UsuarioRepositoryDapper : IUsuarioRepository
{
    public DatabaseConfig DatabaseConfig { get; }

    public UsuarioRepositoryDapper(DatabaseConfig databaseConfig)
    {
        DatabaseConfig = databaseConfig;
    }

    //TODO validacao caso nao encontre
    public void Delete(int id)
    {
        using var connection = GetConnection();
        connection.Execute("DELETE FROM Usuario WHERE id=@id;", new { id = id });
    }

    public IEnumerable<Usuario> GetAll()
    {
        using var connection = GetConnection();
        return connection.Query<Usuario>("SELECT * FROM Usuario;");
    }

    //TODO validacao caso nao encontre
    public Usuario GetById(int id)
    {
        using var connection = GetConnection();
        return connection.QueryFirst<Usuario>("SELECT * FROM Usuario WHERE id=@id;", new { id = id });
    }

    public Usuario Save(Usuario usuario)
    {
        using var connection = GetConnection();
        connection.Execute("INSERT INTO Usuario VALUES(@Id, @Nome, @Email, @Senha, @Ativo);", usuario);
        return usuario;
    }

    //TODO validacao caso nao encontre
    public Usuario Update(Usuario usuario)
    {
        using var connection = GetConnection();
        connection.Execute(
            @"
            UPDATE Usuario 
            SET nome=@Nome, email=@Email, senha=@Senha, ativo=@Ativo 
            WHERE id=@Id;
            ", usuario
        );
        return usuario;
    }

    private SqliteConnection GetConnection() => new SqliteConnection($"Data Source={DatabaseConfig.DatabaseName}");

}