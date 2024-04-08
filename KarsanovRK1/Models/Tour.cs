namespace KarsanovRK1.Models
{
    public class Tour : RepositoryItem
    {
        public string Guide { get; set; }
        public string Route { get; set; }
        public bool RegistrationIsOpen { get; set; }
        public TourDifficulty Difficulty { get; set; }
        public DateTime DepartureDate { get; set; }
        public string GatheringPlace { get; set; }

        public Tour()
        {
            DepartureDate = DateTime.Now;
        }
    }
}
