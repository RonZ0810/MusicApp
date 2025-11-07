using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Configurations;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("Albums");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(a => a.CoverImageUrl)
            .HasMaxLength(512);

        builder.Property(a => a.ReleaseDate).IsRequired();
        builder.Property(a => a.SpotifyId).HasMaxLength(100);

        builder.HasMany(a => a.Artists)
            .WithMany(ap => ap.Albums)
            .UsingEntity(j => j.ToTable("AlbumArtists"));

        builder.HasMany(a => a.Songs)
            .WithOne(s => s.Album)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
