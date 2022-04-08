public class Usuario 
{
    public int Codigo { get; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }

    public Usuario(int codigo, string nome, string email, string senha)
    {
        Codigo = codigo;
        Nome = nome;
        Email = email;
        Senha = senha;
        Ativo = false;
    }

    public Usuario(int codigo, string nome, string email, string senha, bool ativo)
    {
        Codigo = codigo;
        Nome = nome;
        Email = email;
        Senha = senha;
        Ativo = ativo;
    }
}