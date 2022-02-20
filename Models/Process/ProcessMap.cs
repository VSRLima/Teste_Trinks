using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste_Trinks.Models;

namespace Teste_Trinks.Map
{
    public class ProcessMap : IEntityTypeConfiguration<Process>
    {

        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.HasKey(pro => pro.Id);

            builder.HasOne(c => c.Client)
                .WithMany(p => p.Process)
                .HasForeignKey(fk => fk.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
