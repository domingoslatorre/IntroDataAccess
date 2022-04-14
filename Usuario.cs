public class Usuario 
{
    public int Id { get; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }

    public Usuario()
    {
        
    }

    public Usuario(int id, string nome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        Ativo = false;
    }

    public Usuario(int id, string nome, string email, string senha, bool ativo)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        Ativo = ativo;
    }

    public override string ToString()
    {
        return $"{Id},{Nome},{Email},{Senha},{Ativo}";
    }
}