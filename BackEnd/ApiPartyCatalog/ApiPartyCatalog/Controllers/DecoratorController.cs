﻿using ApiPartyCatalog.Context;
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
    }
}
