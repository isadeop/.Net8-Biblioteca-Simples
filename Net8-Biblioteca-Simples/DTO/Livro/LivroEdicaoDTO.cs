using Net8_Biblioteca_Simples.DTO.Vinculo;
using Net8_Biblioteca_Simples.Models;

namespace Net8_Biblioteca_Simples.DTO.Livro;

public class LivroEdicaoDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    public AutorVinculoDTO Autor { get; set; }
}
