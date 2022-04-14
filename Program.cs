var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

IUsuarioRepository usuarioRepository = new UsuarioRepositoryDapper(databaseConfig);

//Usuario joao = usuarioRepository.Save(new Usuario(10, "João", "joao@email.com", "123"));
//Usuario maria = usuarioRepository.Save(new Usuario(11, "Maria", "maria@email.com", "abc", true));

Console.WriteLine(usuarioRepository.GetById(3));
Console.WriteLine("-------");

Usuario usuarioAtualizado = usuarioRepository.Update(new Usuario(8, "XXXXX", "xxxxx@email.com", "xxx", false));
// Console.WriteLine(usuarioAtualizado);
usuarioRepository.GetAll().ToList().ForEach(u => Console.WriteLine(u));

Console.WriteLine("-------");
usuarioRepository.Delete(10);
usuarioRepository.GetAll().ToList().ForEach(u => Console.WriteLine(u));





