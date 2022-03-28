using API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistance.EntityConfigurations;

public class PlaceConfiguration: IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.ToTable("place");

        builder.Property(e => e.Id)
            .HasColumnType("int(11)")
            .HasColumnName("id");

        builder.Property(e => e.Description)
            .HasColumnType("text")
            .HasColumnName("description");

        builder.Property(e => e.Latitude)
            .HasPrecision(10)
            .HasColumnName("latitude");

        builder.Property(e => e.Longitude)
            .HasPrecision(10)
            .HasColumnName("longitude");

        builder.Property(e => e.Name)
            .HasMaxLength(120)
            .HasColumnName("name");
    }
}