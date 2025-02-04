using System;
using System.ComponentModel.DataAnnotations;
namespace dt191g_moment2.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Namn är obligatoriskt")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "E-post är obligatoriskt")]
        [EmailAddress(ErrorMessage = "Ange en giltig e-postadress")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Datum är obligatoriskt")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Hur många gäster är obligatoriskt")]
        public int? Guests { get; set; }

        [Required(ErrorMessage = "Betalningsplats är obligatoriskt")]
        public string? Payment { get; set; }
    }
}
