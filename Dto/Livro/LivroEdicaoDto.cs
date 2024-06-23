using WebApi_Livro.Dto.Livro.Vinculo;
using WebApi_Livro.Models;

namespace WebApi_Livro.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorVinculoDto Autor { get; set; }
    }
}
