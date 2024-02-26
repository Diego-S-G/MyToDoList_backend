using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyToDoList.Domain.Entities;

namespace MyToDoList.Infrastructure.ConfigurationMap
{
    public class CorEntityConfiguration : IEntityTypeConfiguration<Cor>
    {
        public void Configure(EntityTypeBuilder<Cor> builder)
        {
            builder.ToTable(nameof(Cor));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property((x) => x.Codigo)
                .HasColumnName("Codigo")
                .HasColumnType("varchar")
                .HasMaxLength(7)
                .IsRequired();
        }
    }
}
