namespace WebApi_Livro.Models;

public class LivrosModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    //Criando uma situação onde o livro tem apenas um Autor
    public AutorModel Autor { get; set; }
}
