using Microsoft.EntityFrameworkCore;
using WebApi_Livro.Dto.Livro;
using WebApi_Livro.Models;
using WebApi_Livro.Data;
using WebApi_Livro.Dto.Autor;
using WebApi_Livro.Dto.Livro.Vinculo;

namespace WebApi_Livro.Services.Livro;

public class LivroService : ILivroInterface
{
    private readonly AppDbContext _context;
    public LivroService(AppDbContext context)
    {
        _context = context;
    }
    //
    public async Task<ResponseModel<LivrosModel>> BuscarLivroPorId(int idLivro)
    {
        ResponseModel<LivrosModel> resposta = new ResponseModel<LivrosModel>();
        try
        {
            var livro = await _context.Livros.Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
            if (livro == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }


            resposta.Dados = livro;
            resposta.Mensagem = "Livro Localizado com sucesso!";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    //
    public async Task<ResponseModel<List<LivrosModel>>> BuscarLivroPorIdAutor(int idAutor)
    {
        //Criando a nossa Resposta
        ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();

        try
        {
            var livro = await _context.Livros.Include(a => a.Autor)
                .Where(livroBanco => livroBanco.Autor.Id ==  idAutor)
                .ToListAsync(); 

            if (livro == null)
            {
                resposta.Mensagem = "Nenhum registro localizado!";
                return resposta;
            }
            resposta.Dados = livro;
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    //
    public async  Task<ResponseModel<List<LivrosModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
    {
        ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();
        try
        {

            var autor = await _context.Autores
                 .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

            if(autor == null)
            {
                resposta.Mensagem = "Nenhum registro de autor localizado!";
                return resposta;
            }

            var livro = new LivrosModel()
            {
                Titulo = livroCriacaoDto.Titulo,
                Autor = autor,
            };

            _context.Add(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    //
    public async Task<ResponseModel<List<LivrosModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
    {
        ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>(); 
        try
        {
            var livro = await _context.Livros
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(livroBAnco => livroBAnco.Id == livroEdicaoDto.Id);

            var autor = await _context.Autores
                .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.Autor.Id);

            //Se o autor informado não existir deve retornar uma mensagem
            if (autor == null)
            {
                resposta.Mensagem = "Nenhum Autor localizado";
                return resposta;
            }
            if (livro == null)
            {
                resposta.Mensagem = "Nenhum livro localizado";
                return resposta;
            }

            //livro.Id = livroEdicaoDto.Id;
            livro.Titulo = livroEdicaoDto.Titulo;
            livro.Autor = autor;
            
            _context.Update(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Livros.ToListAsync();
            resposta.Mensagem = "Livro Editado com sucesso!";

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
        
    }
    //
    public async Task<ResponseModel<List<LivrosModel>>> ExcluirLivro(int idLivro)
    {
        ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();

        try
        {
            var livro = await _context.Livros
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
            //Se o autor informado não existir deve retornar uma mensagem
            if (livro == null)
            {
                resposta.Mensagem = "Nenhum livro localizado";
                return resposta;
            }

            _context.Remove(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Livros.ToListAsync();
            resposta.Mensagem = "Livro Removido com sucesso!";
            resposta.Status = true;

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
    //
    public async Task<ResponseModel<List<LivrosModel>>> ListarLivros()
    {
        //Criando a nossa Resposta
        ResponseModel<List<LivrosModel>> resposta = new ResponseModel<List<LivrosModel>>();

        try
        {
            var livros = await _context.Livros.Include(a => a.Autor).ToListAsync();

            resposta.Dados = livros;
            resposta.Mensagem = "Todos os livros foram coletados!";
            resposta.Status = true;
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}
