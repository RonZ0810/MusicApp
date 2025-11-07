using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Configurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Songs");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(s => s.Lyrics)
            .HasColumnType("TEXT");

        builder.Property(s => s.FileUrl)
            .HasMaxLength(256);

        builder.Property(s => s.CoverImageUrl)
            .HasMaxLength(256);

        builder.Property(s => s.Genre)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(s => s.Duration);
        builder.Property(s => s.ReleaseDate);
        builder.Property(s => s.SpotifyId).HasMaxLength(100);

        // Relationships
        builder.HasMany(s => s.Artists)
            .WithMany(a => a.Songs)
            .UsingEntity(j => j.ToTable("SongArtists"));

        builder.HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
