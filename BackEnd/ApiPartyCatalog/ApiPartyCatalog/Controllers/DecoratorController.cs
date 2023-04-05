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
        public ActionResult<IEnumerable<Decorator>> GetDecorators() 
        {
            var decorators = _context.Decorators.ToList();

            if(decorators.Count == 0 || decorators is null)
                return NotFound("Não foi encontrado nenhum decorador");

            return Ok(decorators);
        }

        [Route("GetDecoratorByName"), HttpGet]
        public ActionResult<IEnumerable<Decorator>> GetDecoratorByName(string name)
        {
            var decorator = _context.Decorators.Where(x => x.NameDecorator.Contains(name)).ToList();

            if (decorator.Count == 0 || decorator == null)
                return NotFound("Não foi encontrado um decorador com o nome informado");

            return Ok(decorator);
        }

        [Route("AddingDecorator"), HttpPost]
        public ActionResult AddingDecorator(Decorator decorator)
        {
            if(decorator is null)
                return BadRequest("Decorador está nulo!");

            _context.Decorators.Add(decorator);
            _context.SaveChanges();

            return Ok(decorator);
        }

        [Route("EditDecorator"), HttpPut]
        public ActionResult EditDecorator(int idDecorator,  Decorator decorator)
        {
            if (idDecorator != decorator.DecoratorId)
                return BadRequest("O ID do decorador está incorreto");

            _context.Entry(decorator).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(decorator);
        }

    }
}
