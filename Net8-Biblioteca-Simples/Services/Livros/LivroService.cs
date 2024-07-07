using Microsoft.EntityFrameworkCore;
using Net8_Biblioteca_Simples.Data;
using Net8_Biblioteca_Simples.DTO.Livro;
using Net8_Biblioteca_Simples.Models;

namespace Net8_Biblioteca_Simples.Services.Livros;

public class LivroService : ILivroInterface
{
    private readonly AppDbContext _context;
    public LivroService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorAutorId(int idAutor)
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
        try
        {
            var livro = await _context.Livros.Include(a => a.Autor)
                .Where(livroBanco => livroBanco.Autor.Id == idAutor)
                .ToListAsync();

            if (livro == null)
            {
                resposta.Mensagem = "O livro não foi encontrado!";
                return resposta;
            }

            resposta.Dados = livro;
            resposta.Mensagem = "Livro encontrado com sucesso!";
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Status = false;
            resposta.Mensagem = ex.Message;
            return resposta;
        }
    }

    public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
    {
        ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
        try
        {
            var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

            if(livro == null)
            {
                resposta.Mensagem = "O livro não foi encontrado!";
                return resposta;
            }

            resposta.Mensagem = "Livro encontrado com sucesso!";
            resposta.Dados = livro;
            return resposta;
        }catch (Exception ex)
        {
            resposta.Status = false;
            resposta.Mensagem = ex.Message;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDto)
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
        try
        {

            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);

            if(autor == null)
            {
                resposta.Mensagem = "O autor não existe!";
                return resposta;
            }

            var livro = new LivroModel()
            {
                Titulo = livroCriacaoDto.Titulo,
                Autor = autor
            };

            _context.Add(livro);
            await _context.SaveChangesAsync();

            resposta.Mensagem = "Livro criado com sucesso!";
            resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
            return resposta;
            
        }catch(Exception ex)
        {
            resposta.Status = false;
            resposta.Mensagem = ex.Message;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroedicaoDto)
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
        try
        {
            var livro = await _context.Livros.Include(a=> a.Autor)
                .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroedicaoDto.Id);

            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroedicaoDto.Autor.Id);

            if (livro == null)
            {
                resposta.Mensagem = "Não foi possível encontrar o livro!";
                return resposta;
            }

            if (autor == null)
            {
                resposta.Mensagem = "Não foi possível encontrar o autor!";
                return resposta;
            }


            livro.Titulo = livroedicaoDto.Titulo;
            livro.Autor = autor;

             _context.Update(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Livros.ToListAsync();
            resposta.Mensagem = "Livro editado com sucesso!";
            return resposta;

        }
        catch(Exception ex)
        {
            resposta.Status = false;
            resposta.Mensagem = ex.Message;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
        try
        {
            var livro = await _context.Livros.Include(a=>a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

            if(livro == null)
            {
                resposta.Mensagem = "O livro não foi encontrado!";
                return resposta;
            }

            _context.Remove(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = await _context.Livros.ToListAsync();
            resposta.Mensagem = "Livro excluído com sucesso!";
            return resposta;

        }catch(Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
    {
        ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
        try
        {
            var livros = await _context.Livros.Include(a=> a.Autor).ToListAsync();

            resposta.Dados = livros;
            resposta.Mensagem = "Todos os livros foram listados!";

            return resposta;

        } catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}
