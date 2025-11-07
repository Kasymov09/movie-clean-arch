using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(movie => movie.Id);
        
        builder.Property(movie => movie.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(movie => movie.Title)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(movie => movie.ReleaseDate)
            .IsRequired();
        
        builder.Property(movie => movie.Genre)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(movie => movie.Duration)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(movie => movie.Director)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(movie => movie.Actors)
            .IsRequired();
        
        builder.Property(movie => movie.Description)
            .IsRequired(false)
            .HasMaxLength(500);
    }
}