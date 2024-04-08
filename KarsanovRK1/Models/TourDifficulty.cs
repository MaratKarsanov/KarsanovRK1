using System.ComponentModel.DataAnnotations;

namespace KarsanovRK1.Models
{
    public enum TourDifficulty
    {
        [Display(Name = "Легкая")]
        Simple,

        [Display(Name = "Средняя")]
        Medium,

        [Display(Name = "Сложная")]
        Hard
    }
}
