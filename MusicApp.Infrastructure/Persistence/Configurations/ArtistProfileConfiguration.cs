using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Configurations;

public class ArtistProfileConfiguration : IEntityTypeConfiguration<ArtistProfile> {
    public void Configure(EntityTypeBuilder<ArtistProfile> builder) {
        builder.ToTable("ArtistProfiles");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.StageName)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(a => a.SpotifyId).HasMaxLength(100);

        // Relationships
        builder.HasOne(a => a.User)
            .WithOne()
            .HasForeignKey<ArtistProfile>("UserId")
            .OnDelete(DeleteBehavior.SetNull);
    }
}
