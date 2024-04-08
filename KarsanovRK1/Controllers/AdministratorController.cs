using KarsanovRK1.Models;
using Microsoft.AspNetCore.Mvc;

namespace KarsanovRK1.Controllers
{
    public class AdministratorController : Controller
    {
        private IRepository<Tour> tourRepository;
        public AdministratorController(IRepository<Tour> tourRepository)
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
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CloseRegistration(Guid tourId)
        {
            var tour = tourRepository.TryGetElementById(tourId);
            tour.RegistrationIsOpen = false;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult OpenRegistration(Guid tourId)
        {
            var tour = tourRepository.TryGetElementById(tourId);
            tour.RegistrationIsOpen = true;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AddTour()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTour(Tour newTour)
        {
            if (!ModelState.IsValid)
                return View();
            tourRepository.Add(newTour);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTour(Guid tourId)
        {
            var tour = tourRepository.TryGetElementById(tourId);
            return View(tour);
        }

        [HttpPost]
        public IActionResult EditTour(Guid tourId, Tour newTour)
        {
            if (!ModelState.IsValid)
                return View();
            var tour = tourRepository.TryGetElementById(tourId);
            foreach(var p in typeof(Tour).GetProperties())
            {
                p.SetValue(tour, p.GetValue(newTour));
            }
            tourRepository.Add(tour);
            return RedirectToAction("Index");
        }
    }
}
