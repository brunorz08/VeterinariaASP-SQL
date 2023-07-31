using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Veterinaria.Context;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly VeterinariaContext context;
        

        public MedicoController(VeterinariaContext context)
        {
            this.context = context;
        }

        public ActionResult <IEnumerable<Medico>> GetMedicos()
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Otras opciones que puedas necesitar
            };

            var medicoss = context.Medicos.Include(m => m.Especialidad).ToList();


            return new JsonResult(medicoss, options);
        }

        //INSERTAR MEDICO
        [HttpPost]
        public ActionResult InsertarMedico([FromBody] Medico p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Medicos.Add(p);
            context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult ModificarMedico(int id, [FromBody] Medico me)
        {
            var medico = (from e in context.Medicos
                          where e.id == id
                          select e).FirstOrDefault();

            if (medico == null)
            {
                return BadRequest();
            }

            medico.Nombre = me.Nombre;
            medico.Matricula = me.Matricula;
            medico.Especialidad = me.Especialidad;

            context.SaveChanges();
            return Ok();


        }
    }

}
