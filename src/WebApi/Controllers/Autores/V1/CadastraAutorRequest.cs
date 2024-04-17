namespace VirtualBookstore.WebApi.Controllers.Autores.V1;

/// <summary>
/// Representa os dados da solicitação de cadastro de um novo Autor.
/// </summary>
/// <param name="Nome"></param>
/// <param name="Email"></param>
/// <param name="Descricao"></param>
public record CadastraAutorRequest(
    [Required]
    string Nome,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [MaxLength(400)]
    string Descricao)
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"CadastraAutorRequest[Nome: {Nome}, Email: {Email} e Descrição: {Descricao}]";
    }

    internal Autor ConvertToDomain()
    {
        return new Autor(Guid.NewGuid(), Nome, Email, Descricao);
    }
};
