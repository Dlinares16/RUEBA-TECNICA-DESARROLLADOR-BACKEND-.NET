using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using PruebaTecnica.Core.Business.Contracts;
using PruebaTecnica.Core.Domain;

namespace API_PRUEBA_TECNICA_DESARROLLADOR_BACKEND.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IProveedorBusiness _ProveedorBusiness;
        public ProveedorController(IProveedorBusiness proveedorBusiness)
        {
            _ProveedorBusiness = proveedorBusiness;
        }

        [HttpGet]
        //[Authorize]
        [Route("ListarProveedores")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<ProveedoresCollection>>> ListarProveedor()
        {
            return await _ProveedorBusiness.ListarProveedor();
        }

        [HttpPost]
        //[Authorize]
        [Route("InsertarProveedor")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> InsertarProveedor([FromBody] ProveedoresCollection proveedor)
        {
            if (proveedor == null)
                return BadRequest();
            await _ProveedorBusiness.InsertarProveedor(proveedor);
            return Created("Created", true);
        }

        [HttpPost]
        //[Authorize]
        [Route("ActualizarProveedor")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> ActualizarProveedor([FromBody] ProveedoresCollection proveedor, string id)
        {
            if (proveedor == null)
                return BadRequest();
            proveedor.Id = new MongoDB.Bson.ObjectId(id);
            await _ProveedorBusiness.ActualizarProveedor(proveedor);
            return Created("Created", true);
        }

        [HttpPost]
        //[Authorize]
        [Route("DetalleProveedor")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DetalleProveedor(string id)
        {
            return Ok(await _ProveedorBusiness.DetalleProveedor(id));
        }

        [HttpDelete]
        //[Authorize]
        [Route("EliminarProveedor")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> EliminarProveedor(string id)
        {
            await _ProveedorBusiness.EliminarProveedor(id);
            return NoContent();
        }
    }
}
