using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdoptApet.Models;

namespace AdoptApet.Controllers;

public class ContactController : Controller {

    private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }
        public IActionResult contact()
    {
        return View();
    }
}