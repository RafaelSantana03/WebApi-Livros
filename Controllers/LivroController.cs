using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Livro.Dto.Livro;
using WebApi_Livro.Models;
using WebApi_Livro.Services.Autor;
using WebApi_Livro.Services.Livro;

namespace WebApi_Livro.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroInterface _livroInterface;
    public LivroController(ILivroInterface livroInterface)
    {
        _livroInterface = livroInterface;
    }

    [HttpGet("ListarLivros")]
    public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> ListarLivros()
    {
        var livros = await _livroInterface.ListarLivros();
        return Ok(livros);
    }

    [HttpGet("BuscarLivroPorId/{idLivro}")]
    public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> BuscarLivroPorId(int idLivro)
    {
        var livros = await _livroInterface.BuscarLivroPorId(idLivro);
        return Ok(livros);
    }

    [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
    public async Task<ActionResult<ResponseModel<List<LivrosModel>>>> BuscarLivroPorIdAutor(int idAutor)
    {
        var livro  = await _livroInterface.BuscarLivroPorIdAutor(idAutor);
        return Ok(livro);
    }

    [HttpPost("CriarLivro")]
    public async Task<ActionResult<List<LivrosModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
    {
        var livros = await _livroInterface.CriarLivro(livroCriacaoDto);
        return Ok(livros);
    }

    [HttpPut("EditarLivro")]
    public async Task<ActionResult<List<LivrosModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
    {
        var livros = await _livroInterface.EditarLivro(livroEdicaoDto);
        return Ok(livros);
    }

    [HttpDelete("ExcluirLivro")]
    public async Task<ActionResult<List<LivrosModel>>> ExcluirLivro(int idAutor)
    {
        var livros = await _livroInterface.ExcluirLivro(idAutor);
        return Ok(livros);
    }
}
