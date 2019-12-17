using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApp.Models.Residentes
{
    public class Residente : ComponentBase
    {

        public Residente()
        {
            this.Id = string.IsNullOrEmpty(this.Id) ? Guid.NewGuid().ToString() : this.Id;
        }

        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre el requerido")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "El año de residencia debe estar entre 1 y 5")]
        [Display(Name = "Año de residencia")]
        public int YearResident { get; set; } = 1;

        [Required]
        [Display(Name = "Especialidad")]
        public int Especialidad { get; set; }
    }

    public class TipoEspecialidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        
    }

    
}
