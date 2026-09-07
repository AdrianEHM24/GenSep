using Control_Escolar.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Control_Escolar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Control_Escolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CE_Controller : ControllerBase
    {
        private readonly AppDbContext conCE;

        public CE_Controller(AppDbContext context) { 
            conCE = context;
        }

        [HttpGet]
        public ActionResult Get() {
            return Ok(conCE.tblAlumnos.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult Get([FromRoute]int id) {
            var Alumno = conCE.tblAlumnos.FirstOrDefault(a => a.Matricula == id);
            if (Alumno == null)
            {
                return NotFound();
            }
            return Ok(Alumno);
        }

        [HttpPost]
        public ActionResult Post(tblAlumnos tblAlumnos) {
            try
            {
                conCE.tblAlumnos.Add(tblAlumnos);
                conCE.SaveChanges();
                return Ok(tblAlumnos);
            }
            catch (Exception ex) { 
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody]tblAlumnos tblAlumnos) {
            if (id != tblAlumnos.Matricula)
            {
                return BadRequest();
            }
            conCE.Entry(tblAlumnos).State  = EntityState.Modified;
            conCE.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id:int}")]
        public ActionResult Patch(int id, [FromBody] tblAlumnos tblAlumnos)
        {
            var Alumno = conCE.tblAlumnos.FirstOrDefault(a => a.Matricula == id);
            if (Alumno == null)
            {
                return BadRequest();
            }

            Alumno.Nombre = tblAlumnos.Nombre;
            Alumno.Direccion = tblAlumnos.Direccion;
            Alumno.Apellido_Paterno = tblAlumnos.Apellido_Paterno;
            Alumno.Apellido_Materno = tblAlumnos.Apellido_Materno;
            Alumno.Correo = tblAlumnos.Correo;
            Alumno.Telefono = tblAlumnos.Telefono;

            conCE.Entry(Alumno).State = EntityState.Modified;
            conCE.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute]int id) {
            var Alumno = conCE.tblAlumnos.FirstOrDefault(a => a.Matricula == id);
            if (Alumno == null)
            {
                return BadRequest();
            }
            conCE.tblAlumnos.Remove(Alumno);
            conCE.SaveChanges();
            return Ok();
        }
    }
}
