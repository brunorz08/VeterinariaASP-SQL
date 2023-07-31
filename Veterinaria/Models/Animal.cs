using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Veterinaria.Models;

namespace Veterinaria
{
    public class Animal
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string nombre { get; set; }
        public string tipoAnimal { get; set; }
        public int edad { get; set; }

        [ForeignKey("Medico")]
        public int? MedicoId { get; set; }
        public Medico? Medico { get; set; } 

            
    }
}
