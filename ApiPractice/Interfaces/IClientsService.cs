using ApiPractice.DTOs;
using ApiPractice.Models;

namespace ApiPractice.Interfaces
{
    public interface IClientsService
    {
        List<Clients> GetClientesActivo();

        List<Clients> GetClientesActivosUltimosNoventaDias();

        List<Clients> GetClientesFacturasImpagas();

        List<Clients> GetClientesSinFacturas();

        void GenerarCliente(ClienteDto clienteNuevo);

        void EliminarCliente(int idCliente);

        void EliminarFacturasClienteEspecifico(int idCliente);

        void ModificarCliente(int idCliente);
    }
}
