using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.ArtistProfiles.Queries;

public record GetArtistProfileQuery(Guid Id) : IQuery<ArtistProfileDto?>;

