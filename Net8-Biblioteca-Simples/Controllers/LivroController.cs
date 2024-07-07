using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net8_Biblioteca_Simples.DTO.Livro;
using Net8_Biblioteca_Simples.Models;
using Net8_Biblioteca_Simples.Services.Livros;

namespace Net8_Biblioteca_Simples.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroInterface _LivroInterface;
    public LivroController(ILivroInterface livroInterface)
    {
        _LivroInterface = livroInterface;
    }

    [HttpGet("ListarLivros")]

    public async Task<ActionResult<List<LivroModel>>> ListarLivros()
    {
        var livros = await _LivroInterface.ListarLivros();
        return Ok(livros);
    }

    [HttpGet("BuscarLivroPorId/{idLivro}")]

    public async Task<ActionResult<List<LivroModel>>> BuscarLivroPorId(int idLivro)
    {
        var livro = await _LivroInterface.BuscarLivroPorId(idLivro);
        return Ok(livro);
    }

    [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]

    public async Task<ActionResult<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
    {
        var livro = await _LivroInterface.BuscarLivroPorAutorId(idAutor);
        return Ok(livro);
    }

    [HttpPost("CriarLivro")]

    public async Task<ActionResult<List<LivroModel>>> CriarLivro (LivroCriacaoDTO livroCriacaoDTO)
    {
        var livros = await _LivroInterface.CriarLivro(livroCriacaoDTO);
        return Ok(livros);
    }

    [HttpPut("EditarLivro/{idLivro}")]

    public async Task<ActionResult<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroEdicaoDTO)
    {
        var livros = await _LivroInterface.EditarLivro(livroEdicaoDTO);
        return Ok(livros);
    }

    [HttpDelete("ExcluirLivro")]

    public async Task<ActionResult<List<LivroModel>>> ExcluirLivro(int idLivro)
    {
        var livros = await _LivroInterface.ExcluirLivro(idLivro);
        return Ok(livros);
    }
}
