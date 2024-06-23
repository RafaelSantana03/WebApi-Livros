using WebApi_Livro.Dto.Autor;
using WebApi_Livro.Models;

namespace WebApi_Livro.Services.Autor
{
    public interface IAutorInterface
    {
        //Método que lista os autores
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        //Método que busca por ID
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        //Método que busca o autor por Id do Livro
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);

    }
}
