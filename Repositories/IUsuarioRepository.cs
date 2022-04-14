namespace IntroDataAccess.Repositories;

using IntroDataAccess.Models;

interface IUsuarioRepository
{
    Usuario Save(Usuario usuario);
    Usuario GetById(int id);
    IEnumerable<Usuario> GetAll();
    Usuario Update(Usuario usuario);
    void Delete(int id);
}