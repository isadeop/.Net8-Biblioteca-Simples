using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net8_Biblioteca_Simples.DTO.Autor;
using Net8_Biblioteca_Simples.Models;
using Net8_Biblioteca_Simples.Services.Autor;

namespace Net8_Biblioteca_Simples.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorInterface _autorInterface;
    public AutorController(IAutorInterface autorInterface)
    {
        _autorInterface = autorInterface;
    }

    [HttpGet("ListarAutores")]

    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
    {
        var autores = await _autorInterface.ListarAutores();
        return Ok(autores);
    }

    [HttpGet("BuscarAutorPorId/{idAutor}")]

    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
    {
        var autor = await _autorInterface.BuscarAutorPorId(idAutor);
        return Ok(autor);
    }

    [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]

    public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorLivro(int idLivro)
    {
        var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
        return Ok(autor);
    }

    [HttpPost("CriarAutor")]

    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDTO autorCriacaoDto)
    {
        var autor = await _autorInterface.CriarAutor(autorCriacaoDto);
        return Ok(autor);
    }

    [HttpPut("EditarAutor")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor (AutorEdicaoDTO autorEdicaoDto)
    {
        var autor = await _autorInterface.EditarAutor(autorEdicaoDto);
        return Ok(autor);
    }

    [HttpDelete("ExcluirAutor/{idAutor}")]
    public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor (int idAutor)
    {
        var autor = await _autorInterface.ExcluirAutor(idAutor);
        return Ok(autor);
    }


}
