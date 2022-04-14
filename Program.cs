var databaseConfig = new DatabaseConfig();

var databaseSetup = new DatabaseSetup(databaseConfig);

//IUsuarioRepository usuarioRepository = new UsuarioRepositoryDapper(databaseConfig);

//Usuario joao = usuarioRepository.Save(new Usuario(10, "João", "joao@email.com", "123"));
//Usuario maria = usuarioRepository.Save(new Usuario(11, "Maria", "maria@email.com", "abc", true));

//Console.WriteLine(usuarioRepository.GetById(3));
//Console.WriteLine("-------");

//Usuario usuarioAtualizado = usuarioRepository.Update(new Usuario(8, "XXXXX", "xxxxx@email.com", "xxx", false));
// Console.WriteLine(usuarioAtualizado);
//usuarioRepository.GetAll().ToList().ForEach(u => Console.WriteLine(u));

//Console.WriteLine("-------");
//usuarioRepository.Delete(10);
//usuarioRepository.GetAll().ToList().ForEach(u => Console.WriteLine(u));


using var db = new SistemaContext(databaseConfig);

//db.Add(new Usuario(1, "João", "joao@email.com", "123"));
//db.Add(new Usuario(2, "Maria", "maria@email.com", "abc", true));
//db.SaveChanges();

db.Usuarios.ToList().ForEach(u => Console.WriteLine(u));

// Unhandled exception. System.InvalidOperationException: The instance of entity type 'Usuario' 
// cannot be tracked because another instance with the same key value for {'Id'} is already being tracked. 
db.ChangeTracker.Clear();


db.Usuarios.Update(new Usuario(2, "Maria da Silva", "mariasilva@email.com", "abcdef", false));
db.SaveChanges();

Console.WriteLine(db.Usuarios.Single(u => u.Id == 2));
var usuario17 = db.Usuarios.Find(17);
Console.WriteLine(usuario17);

db.Usuarios.Remove(usuario17);
db.SaveChanges();

db.Usuarios.ToList().ForEach(u => Console.WriteLine(u));
