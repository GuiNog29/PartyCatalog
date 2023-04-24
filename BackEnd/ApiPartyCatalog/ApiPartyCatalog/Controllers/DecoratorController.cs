using ApiPartyCatalog.Context;
using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPartyCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DecoratorController : Controller
    {
        private readonly ApiPartyCatalogContext _context;

        public DecoratorController(ApiPartyCatalogContext context)
        {
            _context = context;
        }

        [Route("GetDecorators"), HttpGet]
        public async Task<ActionResult<IEnumerable<Decorator>>> GetDecorators()
        {
            try
            {
                var decorators = await _context.Decorators.ToListAsync();

                if (decorators.Count == 0 || decorators is null)
                    return NotFound("Não foi encontrado nenhum decorador");

                return Ok(decorators);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método GetDecorators");
            }
        }

        [Route("GetDecoratorWithDecorations"), HttpGet]
        public async Task<ActionResult<IEnumerable<Decorator>>> GetDecoratorWithDecorations()
        {
            try
            {
                var decorators = await _context.Decorators.Include(d => d.Decorations).ToListAsync();

                if (decorators.Count == 0 || decorators == null)
                    return NotFound("Não foi encontrado nenhum decorador!");

                return Ok(decorators);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Ocorreu um erro ao realizar uma requisição no método GetDecoratorWithDecorations");
            }
        }

        [Route("GetDecoratorByName"), HttpGet]
        public async Task<ActionResult<IEnumerable<Decorator>>> GetDecoratorByName(string name)
        {
            try
            {
                var decorator = await _context.Decorators.Where(x => x.NameDecorator.Contains(name)).ToListAsync();

                if (decorator.Count == 0 || decorator == null)
                    return NotFound("Não foi encontrado um decorador com o nome informado!");

                return Ok(decorator);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método GetDecoratorByName");
            }
        }

        [Route("AddingDecorator"), HttpPost]
        public async Task<ActionResult<Decorator>> AddingDecorator(Decorator decorator)
        {
            try
            {
                if (decorator is null)
                    return BadRequest("Decorador está nulo!");

                await _context.Decorators.AddAsync(decorator);
                _context.SaveChanges();

                return Ok(decorator);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método AddingDecorator");
            }
        }

        [Route("EditDecorator"), HttpPut]
        public async Task<ActionResult<Decorator>> EditDecorator(int idDecorator, Decorator decorator)
        {
            try
            {
                if (idDecorator != decorator.DecoratorId)
                    return BadRequest("O ID do decorador está incorreto!");

                _context.Entry(decorator).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(decorator);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método EditDecorator");
            }
        }

        [Route("DeleteDecorator"), HttpDelete]
        public async Task<ActionResult<Decorator>> DeleteDecorator(int idDecorator)
        {
            try
            {
                var decorator = _context.Decorators.FirstOrDefault(x => x.DecoratorId == idDecorator);

                if (decorator is null)
                    return BadRequest("Decorador não encontrado!");

                _context.Decorators.Remove(decorator);
                await _context.SaveChangesAsync();

                return Ok(decorator);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método DeleteDecorator");
            }
        }
    }
}
