using ApiPartyCatalog.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPartyCatalog.Business.Interface
{
    public interface IDecorationBusiness
    {
        IEnumerable<Decoration> GetAllDecorationFromDecorator(int idDecorator);
    }
}
