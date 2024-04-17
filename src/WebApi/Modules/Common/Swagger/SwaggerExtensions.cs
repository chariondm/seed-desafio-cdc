namespace VirtualBookstore.WebApi.Modules.Common.Swagger;

/// <summary>
/// Provides extension methods for configuring Swagger documentation and UI in an ASP.NET Core application.
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// Adds custom Swagger generation with predefined options to the specified IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add services to.</param>
    /// <returns>The original IServiceCollection for chaining.</returns>
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Virtual Bookstore API",
                Description = "A Virtual Bookstore API oferece uma plataforma robusta para gerenciamento de uma livraria virtual, facilitando a exploração e aquisição de livros de diversos gêneros. Com esta API, usuários podem criar, atualizar, deletar e consultar informações detalhadas sobre livros, autores e categorias, bem como gerenciar pedidos e avaliações de clientes. Destinada a desenvolvedores que buscam integrar funcionalidades de livraria em seus aplicativos ou plataformas, a API é construída seguindo as melhores práticas de design e qualidade de código em .NET, garantindo alta disponibilidade e escalabilidade. Suporte técnico e documentação adicional estão disponíveis para facilitar a integração e o uso contínuo da API.",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Support Team",
                    Email = "support@example.com",
                    Url = new Uri("https://github.com/chariondm/seed-desafio-cdc/issues")
                },
                License = new OpenApiLicense
                {
                    Name = "Desafio CDC",
                    Url = new Uri("https://github.com/chariondm/seed-desafio-cdc")
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }

    /// <summary>
    /// Configures the application to use Swagger middleware for generating Swagger documentation and Swagger UI based on the environment.
    /// </summary>
    /// <param name="app">The IApplicationBuilder to configure.</param>
    /// <param name="env">The web hosting environment to check for development mode.</param>
    /// <returns>The original IApplicationBuilder for chaining.</returns>
    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Virtual Bookstore API v1"));
        }

        return app;
    }
}
