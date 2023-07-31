using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Veterinaria.Context;
using Veterinaria.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Veterinaria.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly VeterinariaContext context;
        
            
        public AnimalController(VeterinariaContext context)
        {
            this.context = context;
      
        }

        //SELECTALL o GETALL
        [HttpGet]
        public ActionResult<IEnumerable<Animal>> GetAnimales()
        {

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Otras opciones que puedas necesitar
            };

            var animales = context.Animales.Include(m => m.Medico).ToList();

            return new JsonResult(animales, options);


        }


        //SELECTBYID

        [HttpGet("{id}")]

        public ActionResult<Animal> getAnimal(int id)
        {
            var animal = (from p in context.Animales
                          where p.Id == id
                          select p).FirstOrDefault();

            return animal;
        
        }

        [HttpPost]
        public ActionResult InsertarAnimal([FromBody] Animal a)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Add(a);
            context.SaveChanges();
            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult BorrarAnimalId(int id)
        {
            var animal = (from a in context.Animales
                           where a.Id == id
                           select a).FirstOrDefault();
            
            if (animal == null)
            {
                return BadRequest();
            }

          context.Animales.Remove(animal);
            context.SaveChanges();
            return Ok();

        }

        [HttpPut]
        public ActionResult ModificarAnimal(int id, [FromBody] Animal ani)
        {
            var animal = (from e in context.Animales
                                where e.Id == id
                                select e).FirstOrDefault();

            if (animal == null)
            {
                return BadRequest();
            }

            animal.nombre = ani.nombre;
            animal.edad = ani.edad;
            animal.tipoAnimal = ani.tipoAnimal;
            
            context.SaveChanges();
            return Ok();

            
        }



    }
}
