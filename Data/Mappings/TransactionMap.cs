using Data.Mappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings
{
    public class TransactionMap : BaseEntityMap<Transaction>
    {
        public override void Map(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.Property(c => c.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(c => c.FromCheckingAccountId).HasColumnName("FromCheckingAccountId").IsRequired();
            builder.Property(c => c.ToCheckingAccountId).HasColumnName("ToCheckingAccountId").IsRequired();

            builder.HasOne(m => m.FromCheckingAccount)
                                .WithMany(t => t.SentTransactions)
                                .HasForeignKey(m => m.FromCheckingAccountId)
                                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.ToCheckingAccount)
                                .WithMany(t => t.ReceivedTransactions)
                                .HasForeignKey(m => m.ToCheckingAccountId)
                                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}