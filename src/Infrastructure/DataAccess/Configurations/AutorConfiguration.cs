namespace VirtualBookstore.Infrastructure.DataAccess.Configurations;

public sealed class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("autor");

        builder
            .HasKey(a => a.AutorId);

        builder.Property(a => a.AutorId);

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(a => a.Email)
            .IsUnique();

        builder.Property(a => a.Descricao)
            .IsRequired()
            .HasMaxLength(400);

        builder.Property<DateTime>("criado_em")
            .HasDefaultValueSql("now()");
    }
}