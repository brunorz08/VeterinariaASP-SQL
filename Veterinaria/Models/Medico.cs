using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinaria.Models;

namespace Veterinaria
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? Nombre { get; set; }

        [RegularExpression("^([A-Za-z]{3}[0-9]{3})$",ErrorMessage = "La matricula debe empezar con 3 letras y terminar con 3 números.")]
        public string? Matricula {get; set; }
        public List<Animal>? Animales { get; set; } // Propiedad de navegación para representar los animales asociados al médico
        public int EspecialidadId { get; set; }

        [ForeignKey("EspecialidadId")]
        public virtual Especialidad? Especialidad { get; set; }
    }
}
