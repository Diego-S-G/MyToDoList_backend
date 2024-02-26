using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyToDoList.Domain.Entities;

namespace MyToDoList.Infrastructure.ConfigurationMap
{
    public class TarefaEntityConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable(nameof(Tarefa));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(90)
                .IsRequired();

            builder.Property((x) => x.Finalizado)
                .HasColumnName("Finalizado")
                .HasColumnType("boolean")
                .IsRequired();
                
        }
    }
}
