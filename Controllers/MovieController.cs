using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        public MovieService _context;
        public MovieController(MovieService context)
        {
            _context = context;
        }
       
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            try
            {
                var result = _context.List();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de dados falhou");
            }
        }
        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                ResponseModel model = _context.Add(movie);
                switch (model.StatusCode)
                {
                    case 200: return Ok(model);
                    default: return Conflict(model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de dados falhou");
            }
            return BadRequest();
        }
        [HttpDelete("{MovieId}")]
        [Route("delete/{MovieId}")]
        public async Task<IActionResult> Delete(int MovieId)
        {
            try
            {
                ResponseModel model = _context.Delete(MovieId);
                switch (model.StatusCode)
                {
                    case 200: return Ok(model);
                    default: return NotFound(model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "O Banco de dados falhou");
            }
            return BadRequest();
        }
    }
}

