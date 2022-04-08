﻿IUsuarioDao usuarioDao = new UsuarioDao();
Usuario joao = usuarioDao.Save(new Usuario(1, "João", "joao@email.com", "123"));
Usuario maria = usuarioDao.Save(new Usuario(2, "Maria", "maria@email.com", "abc", true));

Console.WriteLine(usuarioDao.GetById(2));

usuarioDao.GetAll().ForEach(u => Console.WriteLine(u));
