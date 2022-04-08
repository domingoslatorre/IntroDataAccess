interface IUsuarioDao
{
    Usuario Save(Usuario usuario);
    Usuario GetById(int id);
    List<Usuario> GetAll();
    Usuario Update(Usuario usuario);
    void Delete(int id);
}