using System.ComponentModel.DataAnnotations;

namespace Conference.Models
{

    public class Registration
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Company/Organization")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Please select a track")]
        [Display(Name = "Primary Interest Track")]
        public string Track { get; set; }

        [Display(Name = "Workshop Preferences")]
        public List<string> Workshops { get; set; }

        [Display(Name = "Dietary Preference")]
        public string DietaryPreference { get; set; }

        [Display(Name = "Additional Comments")]
        public string Comments { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
