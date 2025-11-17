using Microsoft.AspNetCore.Mvc;

[Route("spotify/authentication")]
public class AuthController : Controller {
    private const string SpotifyClientIdEnvVarName = "SPOTIFY_CLIENT_ID";
    private readonly string redirectUri = "https://localhost:5096/callback";

    public IActionResult Spotify() {
        var clientId = Environment.GetEnvironmentVariable(SpotifyClientIdEnvVarName);

        if (string.IsNullOrWhiteSpace(clientId)) {
            return StatusCode(500, $"Environment variable '{SpotifyClientIdEnvVarName}' is not set.");
        }

        var scope = "user-read-email user-read-private playlist-read-private playlist-modify-public playlist-modify-private user-read-recently-played";
        var spotifyAuthUrl = $"https://accounts.spotify.com/authorize" +
                             $"?client_id={clientId}" +
                             $"&response_type=code" +
                             $"&redirect_uri={Uri.EscapeDataString(redirectUri)}" +
                             $"&scope={Uri.EscapeDataString(scope)}";

        return Redirect(spotifyAuthUrl);
    }

/*
    public IActionResult SpotifyCallback(string code) {
        return Content("Authorization code: " + code);
    }*/
}
