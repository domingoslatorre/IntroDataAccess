namespace IntroDataAccess.Repositories;

using IntroDataAccess.Models;

public class UsuarioRepositoryEF : IUsuarioRepository
{
    private SistemaContext sistemaContext;

    public UsuarioRepositoryEF(SistemaContext sistemaContext)
    {
        this.sistemaContext = sistemaContext;    
    }

    public void Delete(int id)
    {
        sistemaContext.Usuarios.Remove(GetById(id));
        sistemaContext.SaveChanges();
    }

    public IEnumerable<Usuario> GetAll() => sistemaContext.Usuarios.ToList();

    public Usuario GetById(int id) => sistemaContext.Usuarios.Find(id);

    public Usuario Save(Usuario usuario)
    {
        sistemaContext.Add(usuario);
        sistemaContext.SaveChanges();
        return usuario;
    }

    public Usuario Update(Usuario usuario)
    {
        sistemaContext.Update(usuario);
        sistemaContext.SaveChanges();
        return usuario;
    }
}