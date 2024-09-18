using PruebaTecnica.Core.Business.Contracts;
using PruebaTecnica.Core.Domain;
using PruebaTecnica.Core.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Business.Code
{
    public class ProveedorBusiness : IProveedorBusiness
    {
        private readonly IProveedorQueries _ProveedorQueries;
        private readonly IProveedorCommands _ProveedorCommands;
        public ProveedorBusiness(
            IProveedorQueries proveedorQueries,
            IProveedorCommands proveedorCommands)
        {
            _ProveedorQueries = proveedorQueries;
            _ProveedorCommands = proveedorCommands;
        }

        public async Task ActualizarProveedor(ProveedoresCollection proveedor)
        {
            try
            {
                await _ProveedorCommands.ActualizarProveedor(proveedor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<ProveedoresCollection> DetalleProveedor(string id)
        {
            try
            {
                return await _ProveedorQueries.DetalleProveedor(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task EliminarProveedor(string id)
        {
            try
            {
                await _ProveedorCommands.EliminarProveedor(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task InsertarProveedor(ProveedoresCollection proveedor)
        {
            try
            {
                await _ProveedorCommands.InsertarProveedor(proveedor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ProveedoresCollection>> ListarProveedor()
        {
            try
            {
                return await _ProveedorQueries.ListarProveedor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
