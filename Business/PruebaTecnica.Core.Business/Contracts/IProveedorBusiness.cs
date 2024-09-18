using PruebaTecnica.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Business.Contracts
{
    public interface IProveedorBusiness
    {
        Task<List<ProveedoresCollection>> ListarProveedor();
        Task<ProveedoresCollection> DetalleProveedor(string id);
        Task InsertarProveedor(ProveedoresCollection proveedor);
        Task ActualizarProveedor(ProveedoresCollection proveedor);
        Task EliminarProveedor(string id);
    }
}
