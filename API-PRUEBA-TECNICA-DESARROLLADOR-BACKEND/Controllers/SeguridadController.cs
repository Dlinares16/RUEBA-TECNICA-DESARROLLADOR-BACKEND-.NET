using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Core.Domain;
using PruebaTecnica.Seguridad.Business.Contracts;
using PruebaTecnica.Seguridad.Domain;

namespace API_PRUEBA_TECNICA_DESARROLLADOR_BACKEND.Controllers
{
    public class SeguridadController : Controller
    {
        private readonly IAutorizacionBusiness _AutorizacionBusiness;
        public SeguridadController(IAutorizacionBusiness autorizacionBusiness)
        {
            _AutorizacionBusiness = autorizacionBusiness;
        }

        [HttpGet]
        [Route("Token")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<AutorizacionE>> Token()
        {
            return await _AutorizacionBusiness.Token();
        }
    }
}
