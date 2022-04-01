namespace CapitalShipsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error() => Problem();
    }
}