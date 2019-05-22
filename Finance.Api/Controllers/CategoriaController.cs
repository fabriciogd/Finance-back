using Finance.Enums;
using Microsoft.AspNetCore.Mvc;
using Finance.Commom.Extensions;
using System.Linq;
using Finance.DTO;

namespace Finance.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorias")]
    public class CategoriaController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var result = new Categroria()
                .GetDescriptions()
                .Select(a => new DTODeCategoria() {
                    Enumerado = a.Key,
                    Descricao = a.Value
                });

            return Ok(result);
        }

    }
}
