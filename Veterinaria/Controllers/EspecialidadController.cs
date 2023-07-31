using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Context;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private readonly VeterinariaContext context;

        public EspecialidadController(VeterinariaContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Especialidad>> GetEspecialidades()
        {
            var especialidades = context.Especialidades.ToList();
            return Ok(especialidades);

        }

        [HttpPost]
        public ActionResult InsertarEspecialidad([FromBody] Especialidad e)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Especialidades.Add(e);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult EliminarEspecialidad(int id)
        {
            var especialidad = (from e in context.Especialidades
                                where e.Id == id
                                select e).FirstOrDefault();

            if(especialidad == null)
            {
                return BadRequest();
            }

            context.Especialidades.Remove(especialidad);
            context.SaveChanges();
            return Ok();

                                
        }

        [HttpPut]
        public ActionResult ModificarEspecialidad([FromBody]Especialidad e,int id)
        {
            var especialidad = (from es in context.Especialidades
                                where es.Id == id
                                select es).FirstOrDefault();

            if (especialidad == null)
            {
                return BadRequest();
            }

            especialidad.Nombre = e.Nombre;
            context.Especialidades.Remove(especialidad);
            context.SaveChanges();
            return Ok();
        }

    }
}
