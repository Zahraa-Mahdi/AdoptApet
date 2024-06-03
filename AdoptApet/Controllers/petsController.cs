using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using AdoptApet.Models;
namespace PetsAdoption.Controllers
{
    public class petsController : Controller
    {
        private static List<pet> pets = new(){
            new()
            {
                Id = 1,
                Name = "Scooby",
                Age = 3,
                Breed = "Labrador Retriever",
                Description = "Friendly and playful dog looking for a loving home.",
                ImageUrl = "https://images.unsplash.com/photo-1554456854-55a089fd4cb2?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            },
            new()
            {
                Id = 2,
                Name = "Max",
                Age = 4,
                Breed = "Golden Retriever",
                Description =  "Loyal companion with a gentle nature." ,
                ImageUrl = "https://images.unsplash.com/photo-1612774412771-005ed8e861d2?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8R29sZGVuJTIwUmV0cmlldmVyfGVufDB8fDB8fHww",
            },

        };
        public IActionResult Details(int id)
        {
            var pet = pets.FirstOrDefault(p => p.Id == id);
            if (pet == null)
            { return NotFound(); }
            return View(pet);
        }

        private readonly ILogger<petsController> _logger;

        public petsController(ILogger<petsController> logger)
        {
            _logger = logger;
        }

        // GET: /pets/
        public ActionResult pet()
        {
            return View(pets);
        }
        public IActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Add(pet pet)
        {
            pets.Add(pet);
            return RedirectToAction("Index");
        }


    }
}