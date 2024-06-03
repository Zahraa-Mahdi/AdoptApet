using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AdoptApet.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger)
        {
            _logger = logger;
        }

        
        public ActionResult service()
        {
            return View();
        }
    }
}
