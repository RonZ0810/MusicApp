using Microsoft.AspNetCore.Mvc;

namespace MusicApp.Web.Controllers.Api;
[Route("callback")]
public class SpotifyCallbackController : Controller {

    public IActionResult Callback([FromQuery] string code) {
        return Redirect("/?code=" + code);
    }
}
