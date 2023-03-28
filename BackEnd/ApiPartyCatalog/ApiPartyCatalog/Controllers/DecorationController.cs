using ApiPartyCatalog.Context;
using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPartyCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DecorationController : Controller
    {
        private readonly ApiPartyCatalogContext _context;

        public DecorationController(ApiPartyCatalogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Decoration>> GetAllDecorationFromDecorator(int idDecorator)
        {
            var decorations = _context.Decorations.Where(x => x.DecoratorId == idDecorator).ToList();

            if (decorations is null)
                return NotFound("Não foi encontrado nenhuma decoração deste decorador...");

            return decorations;
        }
    }
}
