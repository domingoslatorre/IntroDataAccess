var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

IUsuarioRepository usuarioRepository = new UsuarioRepository(databaseConfig);

Usuario joao = usuarioRepository.Save(new Usuario(1, "João", "joao@email.com", "123"));
Usuario maria = usuarioRepository.Save(new Usuario(2, "Maria", "maria@email.com", "abc", true));

Console.WriteLine(usuarioRepository.GetById(2));

Usuario usuarioAtualizado = usuarioRepository.Update(new Usuario(1, "XXXXX", "xxxxx@email.com", "xxx", false));
Console.WriteLine(usuarioAtualizado);
usuarioRepository.GetAll().ForEach(u => Console.WriteLine(u));

Console.WriteLine("-------");
usuarioRepository.Delete(1);
usuarioRepository.GetAll().ForEach(u => Console.WriteLine(u));





