
namespace Airport.MVC.Models.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum PlaceClass
    {
        [Display(Name = "Business")]
        Business,
        [Display(Name = "Economy")]
        Economy
    }
}
