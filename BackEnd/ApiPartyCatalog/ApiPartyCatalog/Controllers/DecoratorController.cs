using ApiPartyCatalog.Context;
using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ActionResult<IEnumerable<Decorator>> GetDecorators() 
        {
            var decorators = _context.Decorators.ToList();

            if(decorators is null)
                return NotFound("Não foi encontrado nenhum decorador");

            return decorators;
        }
    }
}
