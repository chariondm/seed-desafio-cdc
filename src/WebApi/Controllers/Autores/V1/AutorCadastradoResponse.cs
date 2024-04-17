namespace VirtualBookstore.WebApi.Controllers.Autores.V1;

/// <summary>
/// Represensa a resposta de sucesso para o cadastro de um novo Autor.
/// </summary>
/// <param name="Id">Identificador unico do Autor cadastrado.</param>
public record AutorCadastradoResponse(Guid Id)
{
    internal AutorCadastradoResponse(Autor autor) : this(autor.AutorId)
    {

    }
};
