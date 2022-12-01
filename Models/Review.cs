using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Review
    {
        public Review()
        {

        }
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Il nome non più superare i 30 caratteri")]
        public string? UserName { get; set; }
        
        [Required(ErrorMessage = "Il testo del messaggio è obbligatorio")]
        [StringLength(500, ErrorMessage = "La descrizione non più superare i 500 caratteri")]
        [Column(TypeName = "nvarchar(max)")]
        public string Message { get; set; }
        public int? PizzaId { get; set; }
        public Pizza? Pizza { get; set; }
        public void CheckName()
        {
            if (UserName == "")
            {
                UserName = "Anonimo";
            }
        }
    }
}
