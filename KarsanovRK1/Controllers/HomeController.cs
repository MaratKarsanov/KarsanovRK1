using KarsanovRK1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KarsanovRK1.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Tour> tourRepository;
        public HomeController(IRepository<Tour> tourRepository)
        {
            this.tourRepository = tourRepository;
            if (tourRepository.Count() == 0)
                tourRepository.Add(new Tour()
                {
                    Guide = "Карсанов Марат",
                    Route = "Владикавказ-Фиагдон",
                    RegistrationIsOpen = true,
                    Difficulty = TourDifficulty.Hard,
                    DepartureDate = DateTime.Now,
                    GatheringPlace = "Кирова 38"
                });
        }

        public IActionResult Index()
        {
            return View(tourRepository);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
