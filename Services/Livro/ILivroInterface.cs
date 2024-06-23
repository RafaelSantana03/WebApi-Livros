using WebApi_Livro.Dto.Autor;
using WebApi_Livro.Dto.Livro;
using WebApi_Livro.Models;

namespace WebApi_Livro.Services.Livro;

public interface ILivroInterface
{
    //Método que lista os autores
    Task<ResponseModel<List<LivrosModel>>> ListarLivros();
    //Método que busca por ID
    Task<ResponseModel<LivrosModel>> BuscarLivroPorId(int idLivro);
    //Método que busca o autor por Id do Livro
    Task<ResponseModel<List<LivrosModel>>> BuscarLivroPorIdAutor(int idAutor);
    Task<ResponseModel<List<LivrosModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
    Task<ResponseModel<List<LivrosModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
    Task<ResponseModel<List<LivrosModel>>> ExcluirLivro(int idLivro);
}
