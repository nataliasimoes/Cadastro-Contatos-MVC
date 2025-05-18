using CadastroDeContatos.Data;
using CadastroDeContatos.Models;

namespace CadastroDeContatos.Repositorio;

public class ContatoRepositorio : IContatoRepositorio
{
    private readonly BancoContext _bancoContext;
    public ContatoRepositorio (BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public ContatoModel Adicionar (ContatoModel contato)
    {
        // INSERT no banco
        _bancoContext.Contatos.Add(contato);
        _bancoContext.SaveChanges();
        return contato;
    }

    public List<ContatoModel> BuscarTodos ()
    {
        return _bancoContext.Contatos.ToList();
    }

    public ContatoModel ListarPorId (int id)
    {
        return _bancoContext.Contatos.FirstOrDefault(c => c.Id == id);
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel contatoDb = ListarPorId(contato.Id);

        if (contatoDb == null)
        {
            throw new System.Exception("Houve um erro na atualização!");
        }

        contatoDb.Nome = contato.Nome;
        contatoDb.Email = contato.Email;
        contatoDb.Celular = contato.Celular;

        _bancoContext.Contatos.Update(contatoDb);
        _bancoContext.SaveChanges();

        return contatoDb;
    }
}
