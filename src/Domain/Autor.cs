namespace VirtualBookstore.Domain;

/// <summary>
/// Representa um autor no sistema da livraria virtual.
/// </summary>
/// <param name="AutorId">Identificador único para o autor, gerado como um GUID.</param>
/// <param name="Nome">Nome completo do autor. Este campo é obrigatório e não deve ser vazio.</param>
/// <param name="Email">Endereço de e-mail do autor. Deve seguir um formato válido de e-mail.</param>
/// <param name="Descricao">Uma breve descrição do autor, que pode incluir suas áreas de especialização, prêmios recebidos e outras informações relevantes.</param>
public record Autor(Guid AutorId, string Nome, string Email, string Descricao);
