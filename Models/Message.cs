using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il nome non più superare i 30 caratteri")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il cognome non più superare i 30 caratteri")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [StringLength(50, ErrorMessage = "L'email non più superare i 50 caratteri")]
        [EmailAddress(ErrorMessage = "Devi inserire una mail")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Il testo è obbligatorio")]
        [StringLength(500, ErrorMessage = "Il testo non più superare i 500 caratteri")]
        [Column(TypeName = "text")]
        public string Text { get; set; }
    }
}
