using Microsoft.AspNetCore.Mvc;
using Viajes_Saurio.Context;
using Microsoft.AspNetCore.Http;
using Viajes_Saurio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Viajes_Saurio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeApi : ControllerBase
    {
        private readonly AppDbContext conTurismo;

        public ViajeApi(AppDbContext context) {
            conTurismo = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(conTurismo.tblDestino.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult Get([FromRoute] int id)
        {
            var Viaje = conTurismo.tblDestino.FirstOrDefault(a => a.Id == id);
            if (Viaje == null)
            {
                return NotFound();
            }
            return Ok(Viaje);
        }

        [HttpPost]
        public ActionResult Post(tblDestino tblDestino)
        {
            try
            {
                conTurismo.tblDestino.Add(tblDestino);
                conTurismo.SaveChanges();
                return Ok(tblDestino);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] tblDestino tblDestino)
        {
            if (id != tblDestino.Id)
            {
                return BadRequest();
            }
            conTurismo.Entry(tblDestino).State = EntityState.Modified;
            conTurismo.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id:int}")]
        public ActionResult Patch(int id, [FromBody] tblDestino tblDestino)
        {
            var Viaje = conTurismo.tblDestino.FirstOrDefault(a => a.Id == id);
            if (Viaje == null)
            {
                return BadRequest();
            }
            
            Viaje.Nombre = tblDestino.Nombre;
            Viaje.Direccion = tblDestino.Direccion;
            Viaje.Descripcion = tblDestino.Descripcion;

            conTurismo.Entry(Viaje).State = EntityState.Modified;
            conTurismo.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var Viaje = conTurismo.tblDestino.FirstOrDefault(a => a.Id == id);
            if (Viaje == null)
            {
                return BadRequest();
            }
            conTurismo.tblDestino.Remove(Viaje);
            conTurismo.SaveChanges();
            return Ok();
        }
    }
}
