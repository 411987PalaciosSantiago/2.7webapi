using _2._7Back.Data.Models;
using _2._7Back.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _2._7Ap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {

        private readonly IServiceServicio _servicio;

        public ServiciosController(IServiceServicio servicio)
        {
            _servicio = servicio;
        }


        // GET: api/<ServiciosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _servicio.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var devuelto = await _servicio.GetById(id);

                if (devuelto != null)
                {
                    return Ok(devuelto);
                }
                return NotFound("Sin Service");

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                _servicio.Add(servicio);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TServicio service)
        {
          
            try
            {
               await _servicio.Update(service);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500);
            }
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _servicio.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
