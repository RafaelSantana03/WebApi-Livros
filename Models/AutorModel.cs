using System.Text.Json.Serialization;

namespace WebApi_Livro.Models;

public class AutorModel
{
    //Cada Propriedade é uma coluna na tabela
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }

    [JsonIgnore]
    //Criando uma situação onde o autor pode escrever varios Livros
    public ICollection<LivrosModel> Livros{ get; set; }
}
