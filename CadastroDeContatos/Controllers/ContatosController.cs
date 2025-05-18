using CadastroDeContatos.Models;
using CadastroDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeContatos.Controllers;
public class ContatosController : Controller
{
    private readonly IContatoRepositorio _contatoRepositorio;
    public ContatosController(IContatoRepositorio contatoRepositorio)
    {
        _contatoRepositorio = contatoRepositorio;
    }

    public IActionResult Index()
    {
        var contatos = _contatoRepositorio.BuscarTodos();
        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        ContatoModel contato = _contatoRepositorio.ListarPorId(id);
        return View(contato);
    }

    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _contatoRepositorio.Apagar(id);

            if (apagado)
            {
                TempData["MensagemSucesso"] = "Cadastro excluído com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = $"Ops, não foi possível excluir!";
            }
            return RedirectToAction("Index");
        }
        catch (Exception erro)
        {

            TempData["MensagemErro"] = $"Ops, não conseguimos excluir o cadastro, detalhes do erro: {erro.Message}";
            return RedirectToAction("Index");
        }

    }

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(contato);
            }

            _contatoRepositorio.Adicionar(contato);
            TempData["MensagemSucesso"] = "Cadastrado com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar o contato, detalhes do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Alterar(ContatoModel contato)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View("Editar", contato);
            }

            _contatoRepositorio.Atualizar(contato);
            TempData["MensagemSucesso"] = "Alterado com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception erro)
        {
            TempData["MensagemErro"] = $"Ops, não conseguimos alterar o contato, detalhes do erro: {erro.Message}";
            return RedirectToAction("Index");
        }
    }
}
