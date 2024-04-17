namespace VirtualBookstore.WebApi.Controllers.Autores.V1;

/// <summary>
/// Controller para o endpoint de registro de autores.
/// </summary>
/// <param name="logger"></param>
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
[Route("api/v1/autores")]
public sealed class AutorController(ILogger<AutorController> logger) : ControllerBase
{
    private readonly ILogger<AutorController> _logger = logger;

    /// <summary>
    /// Cadastra um novo Autor.
    /// </summary>
    /// <param name="request">Os dados da solicitação de cadastro do Autor.</param>
    /// <param name="appDbContext">.</param>
    /// <param name="cancellationToken">O token para monitorar solicitações de cancelamento.</param>
    /// <returns>O resultado do cadastro do Autor.</returns>
    /// <response code="201">O Autor foi cadastrado com sucesso.</response>
    /// <response code="400">O Autor não foi cadastrado porque os dados da solicitação fornecidos são inválidos.</response>
    /// <remarks>
    /// Este endpoint permite o cadastro de um novo Autor. Os dados da solicitação devem ser válidos.
    /// </remarks>
    /// <example>
    /// POST /api/v1/autores
    /// {
    ///     "nome": "Fulano",
    ///     "email": "fulano@email.com",
    ///     "descricao": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla tristique lorem eros, vel semper dui."
    ///  }
    ///  </example>
    [HttpPost(Name = "CadastraAutor")]
    [ProducesResponseType(typeof(ApiResponse<AutorCadastradoResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<ValidationProblemDetails>), StatusCodes.Status400BadRequest)]
    public async Task<IResult> CadastraAutorAsync(
        [FromBody] CadastraAutorRequest request,
        [FromServices] AppDbContext appDbContext,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Recebendo {request}", request);

        var autor = request.ConvertToDomain();

        await appDbContext.AddAsync(autor, cancellationToken);
        await appDbContext.SaveChangesAsync(cancellationToken);

        var result = ApiResponse<AutorCadastradoResponse>.CreateSuccess(new AutorCadastradoResponse(autor));

        return Results.Created("", result);
    }
}
