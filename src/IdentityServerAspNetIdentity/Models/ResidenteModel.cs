using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerAspNetIdentity.Models
{
    public class ResidenteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "El año de residencia debe estar entre 1 y 5")]
        [Display(Name = "Año de residencia")]
        public int YearResident { get; set; }

        [Required]
        [Display(Name = "Especialidad")]
        public int Especialidad { get; set; }
    }
}
