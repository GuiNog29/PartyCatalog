﻿using ApiPartyCatalog.Context;
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
        [Route("GetAllDecorationFromDecorator")]
        public ActionResult<IEnumerable<Decoration>> GetAllDecorationFromDecorator(int idDecorator)
        {
            var decorations = _context.Decorations.Where(x => x.DecoratorId == idDecorator).ToList();

            if (decorations.Count == 0 || decorations is null)
                return NotFound("Não foi encontrado nenhuma decoração deste decorador...");

            return decorations;
        }

        [HttpGet]
        [Route("GetDecorationByTitle")]
        public ActionResult<IEnumerable<Decoration>> GetDecorationByTitle(string nameDecoration,int idDecorator)
        {
            var decorations = _context.Decorations.Where(x => 
                x.Title.Contains(nameDecoration) && x.DecoratorId == idDecorator).ToList();

            if (decorations.Count == 0 || decorations is null)
                return NotFound("Não foi encontrado nenhuma decoração com está descrição...");

            return decorations;
        }
    }
}
