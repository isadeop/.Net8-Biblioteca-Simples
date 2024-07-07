namespace Net8_Biblioteca_Simples.Models;

public class ResponseModel<T>
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; } = String.Empty;
    public bool Status { get; set; } = true;
}
