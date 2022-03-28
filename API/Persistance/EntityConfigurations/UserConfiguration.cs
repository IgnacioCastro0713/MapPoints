using API.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Persistance.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasColumnType("int(11)")
            .HasColumnName("id");

        builder.Property(e => e.Email)
            .IsRequired()
            .HasColumnName("email");
        
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasColumnName("firstname");
        
        builder.Property(e => e.LastName)
            .IsRequired(false)
            .HasColumnName("lastname");

        builder.HasKey(user => user.Id);
        
        builder.ToTable("user");

    }
}