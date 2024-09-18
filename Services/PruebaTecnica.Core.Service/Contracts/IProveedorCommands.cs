using PruebaTecnica.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Core.Service.Contracts
{
    public interface IProveedorCommands
    {
        Task InsertarProveedor(ProveedoresCollection proveedor);
        Task ActualizarProveedor(ProveedoresCollection proveedor);
        Task EliminarProveedor(string id);
    }
}
