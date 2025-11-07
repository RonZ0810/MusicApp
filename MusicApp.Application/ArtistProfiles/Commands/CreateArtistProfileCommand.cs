using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.ArtistProfiles.Commands;

public record CreateArtistProfileCommand(CreateArtistProfileDto CreateArtistProfileDto) : ICommand<ArtistProfileDto>;

