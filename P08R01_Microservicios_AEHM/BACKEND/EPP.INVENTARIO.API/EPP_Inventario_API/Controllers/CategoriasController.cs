using EPP_Inventario_API.Context;
using EPP_Inventario_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPP_Inventario_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _contextEPPInv;
        public CategoriasController(AppDbContext context)
        {
            _contextEPPInv = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _contextEPPInv.Categorias.ToListAsync();

            if (!categorias.Any())
                return NotFound("No hay registros a mostrar");

            return Ok(categorias);
        }

        //[HttpGet("{id:int}")]
        //public ActionResult Get([FromRoute] int id) {
        //    var categoria = _contextEPPInv.Categorias.FirstOrDefault(a => a.CategoriaId == id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(categoria);
        //}
        //[HttpPost]
        //public ActionResult Post([FromBody] Categoria categoria) {
        //    try
        //    {
        //        _contextEPPInv.Categorias.Add(categoria);
        //        _contextEPPInv.SaveChanges();
        //        return Ok(categoria);
        //    }
        //    catch (Exception ex) {
        //        return BadRequest(ex.ToString());
        //    }
        //}
        //[HttpPut("{id:int}")]
        //public ActionResult Put(int id, [FromBody]Categoria categoria) {
        //    if (id != categoria.CategoriaId)
        //    {
        //        return NotFound();
        //    }
        //    return Ok();
        //}

        //[HttpDelete("{id:int}")]
        //public ActionResult Delete([FromRoute]int id) {
        //    var categoria = _contextEPPInv.Categorias.FirstOrDefault(a => a.CategoriaId == id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }
        //    _contextEPPInv.Categorias.Remove(categoria);
        //    _contextEPPInv.SaveChanges();
        //    return Ok();
        //}
        [HttpGet("{CategoriaId:int}", Name = "GetCategoria")]
        public async Task<IActionResult> GetCategoria([FromRoute] int CategoriaId)
        {
            var categoria = await _contextEPPInv.Categorias.FindAsync(CategoriaId);

            if (categoria == null) { 
                return NotFound("No Existe categoria con ese id");
            }
            return Ok(categoria);
        }

        [HttpGet("GetCategoriasProductos")]
        public async Task<IActionResult> GetCategoriasProductos()
        {
            var categorias = await _contextEPPInv.Categorias.Include(cat => cat.Productos).ToListAsync();

            if (!categorias.Any()) { 
                return NotFound("No hay registros a mostrar");
            }
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest("Informacion invalida");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _contextEPPInv.Categorias.AddAsync(categoria);

            if (!(await _contextEPPInv.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return CreatedAtRoute(nameof(GetCategoria), new { CategoriaId = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{CategoriaId:int}")]
        public async Task<IActionResult> PutCategoria([FromRoute] int CategoriaId, [FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest("Informacion invalida");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            if (CategoriaId != categoria.CategoriaId)
                return BadRequest("Los id's no coinciden");

            Categoria? categoriaExistente = await _contextEPPInv.Categorias.FindAsync(CategoriaId);

            if (categoriaExistente == null)
                return NotFound("No se encontro ninguna categoria con ese id");

            categoriaExistente.Nombre = categoria.Nombre;
            categoriaExistente.Descripcion = categoria.Descripcion;
            categoriaExistente.Activo = categoria.Activo;

            if (!(await _contextEPPInv.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return Ok(categoria);
        }


        [HttpDelete("{CategoriaId:int}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int CategoriaId)
        {
            if (CategoriaId <= 0)
                return BadRequest("Id invalido");

            Categoria? categoriaExistente = await _contextEPPInv.Categorias.FindAsync(CategoriaId);

            if (categoriaExistente == null)
                return NotFound("No se encontro ninguna categoria con ese id");

            _contextEPPInv.Remove(categoriaExistente);

            if (!(await _contextEPPInv.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return NoContent();
        }
    }
}
