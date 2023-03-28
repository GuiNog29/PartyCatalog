using ApiPartyCatalog.Business;
using ApiPartyCatalog.Context;
using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPartyCatalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DecorationController : Controller
    {
        private readonly DecorationBusiness _decorationBusiness;

        public DecorationController(DecorationBusiness decorationBusiness)
        {
            _decorationBusiness = decorationBusiness;
        }

        [HttpGet]
        public IEnumerable<Decoration> GetAllDecorationFromDecorator(int idDecorator)
        {
            return _decorationBusiness.GetAllDecorationFromDecorator(idDecorator);
        }
    }
}
