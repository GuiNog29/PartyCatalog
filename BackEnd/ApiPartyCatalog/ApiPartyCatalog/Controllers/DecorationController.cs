using ApiPartyCatalog.Context;
using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("GetAllDecorations"), HttpGet]
        public ActionResult<IEnumerable<Decoration>> GetAllDecorations()
        {
            try
            {
                var decorations = _context.Decorations.ToList();

                if (decorations.Count == 0 || decorations is null)
                    return NotFound("Não foi encontrado nenhuma decoracao...");

                return Ok(decorations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método GetAllDecorations");
            }

        }

        [Route("GetAllDecorationFromDecorator"), HttpGet]
        public ActionResult<IEnumerable<Decoration>> GetAllDecorationFromDecorator(int idDecorator)
        {
            try
            {
                var decorations = _context.Decorations.Where(x => x.DecoratorId == idDecorator).ToList();

                if (decorations.Count == 0 || decorations is null)
                    return NotFound("Não foi encontrado nenhuma decoração deste decorador...");

                return Ok(decorations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método GetAllDecorationFromDecorator");
            }

        }

        [Route("GetDecorationByTitle"), HttpGet]
        public ActionResult<IEnumerable<Decoration>> GetDecorationByTitle(string nameDecoration, int idDecorator)
        {
            try
            {
                var decorations = _context.Decorations.Where(x =>
                x.Title.Contains(nameDecoration) && x.DecoratorId == idDecorator).ToList();

                if (decorations.Count == 0 || decorations is null)
                    return NotFound("Não foi encontrado nenhuma decoração com está descrição!");

                return Ok(decorations);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método GetDecorationByTitle");
            }

        }

        [Route("AddingDecoration"), HttpPost]
        public ActionResult AddingDecoration(Decoration decoration)
        {
            try
            {
                if (decoration is null)
                    return BadRequest("Decoração está nula!");

                _context.Decorations.Add(decoration);
                _context.SaveChanges();

                return Ok(decoration);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método AddingDecoration");
            }

        }

        [Route("EditDecoration"), HttpPut]
        public ActionResult EditDecoration(int idDecoration, Decoration decoration)
        {
            try
            {
                if (idDecoration != decoration.DecorationId)
                    return BadRequest("O ID da decoração está incorreto!");

                _context.Entry(decoration).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(decoration);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método EditDecoration");
            }

        }

        [Route("DeleteDecoration"), HttpDelete]
        public ActionResult DeleteDecoration(int idDecoration)
        {
            try
            {
                var decoration = _context.Decorations.FirstOrDefault(x => x.DecorationId == idDecoration);

                if (decoration is null)
                    return BadRequest("Decoração não localizada!");

                _context.Decorations.Remove(decoration);
                _context.SaveChanges();

                return Ok(decoration);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um erro ao realizar uma requisição no método DeleteDecoration");
            }
        }
    }
}
