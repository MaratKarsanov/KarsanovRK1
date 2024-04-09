using System.ComponentModel.DataAnnotations;

namespace KarsanovRK1.Models
{
    public class Tour : RepositoryItem
    {
        [Required(ErrorMessage = "Не указан гид")]
        public string Guide { get; set; }

        [Required(ErrorMessage = "Не указан маршрут")]
        public string Route { get; set; }
        public bool RegistrationIsOpen { get; set; }
        public TourDifficulty Difficulty { get; set; }

        [Required(ErrorMessage = "Не указана дата старта")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Не указано место отправления")]
        public string GatheringPlace { get; set; }

        public Tour()
        {
            DepartureDate = DateTime.Now;
        }
    }
}
