
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookStore_Web_Application.Core.Entities;

public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
{
    public void Configure(EntityTypeBuilder<Campaign> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.Property(x => x.DiscountRate)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();
    }
}