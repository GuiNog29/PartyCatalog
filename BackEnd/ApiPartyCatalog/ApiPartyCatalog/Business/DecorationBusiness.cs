using ApiPartyCatalog.Business.Interface;
using ApiPartyCatalog.Context;
using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPartyCatalog.Business
{
    public class DecorationBusiness : IDecorationBusiness
    {
        private readonly ApiPartyCatalogContext _context;
        public DecorationBusiness(ApiPartyCatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<Decoration> GetAllDecorationFromDecorator(int idDecorator)
        {
            var decorations = _context.Decorations.Where(x => x.DecoratorId == idDecorator).ToList();

            if (decorations.Count() == 0)
                throw new Exception("Não foi encontrado nenhuma decoração deste decorador...");

            return decorations;
        }
    }
}
