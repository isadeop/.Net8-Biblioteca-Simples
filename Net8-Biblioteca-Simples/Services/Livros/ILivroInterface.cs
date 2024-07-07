using Net8_Biblioteca_Simples.DTO.Livro;
using Net8_Biblioteca_Simples.Models;

namespace Net8_Biblioteca_Simples.Services.Livros;

public interface ILivroInterface
{
    Task<ResponseModel<List<LivroModel>>> ListarLivros();
    Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
    Task<ResponseModel<List<LivroModel>>> BuscarLivroPorAutorId(int idAutor);
    Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDTO livroCriacaoDto);
    Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDTO livroedicaoDto);
    Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);

}
