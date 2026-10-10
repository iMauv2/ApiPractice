using ApiPractice.DTOs;
using ApiPractice.Factory;
using ApiPractice.Interfaces;
using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Services
{
    public class ClientsServices : IClientsService
    {
        private readonly IRepositoryiClients _clientsRepository;
        private readonly IRepositoryInvoice _repositoryInvoice;

        public ClientsServices(IRepositoryiClients repositoryiClients, IRepositoryInvoice repositoryInvoice)
        {
            _clientsRepository = repositoryiClients;
            _repositoryInvoice = repositoryInvoice;
        }

        //Obtener todos los clientes activos.
        public List<Clients> GetClientesActivo()
        {
            return _clientsRepository.GetAll().Where(p => p.IsActive).ToList();
        }

        //Obtener los clientes activados en los últimos 90 días.
        public List<Clients> GetClientesActivosUltimosNoventaDias()
        {
            return _clientsRepository.GetAll().Where(p => EF.Functions.DateDiffDay(p.ActivationDate, DateTime.Now) <= 90).ToList();
        }

        //Obtener todos los clientes con facturas impagas.
        public List<Clients> GetClientesFacturasImpagas()
        {
            var query = from cliente in _clientsRepository.GetAll()
                        join invoices in _repositoryInvoice.GetAll()
                        on cliente.Id equals invoices.ClientId
                        where invoices.IsPaid == false
                        select cliente; // <--- Retornamos directamente el objeto cliente

            // Usamos .Distinct() por si un cliente tiene varias facturas y no queremos repetirlo
            return query.Distinct().ToList();
        }

        //Obtener clientes sin facturas.
        public List<Clients> GetClientesSinFacturas()
        {
            return _clientsRepository.GetAll()
                .Where(cliente => !_repositoryInvoice.GetAll()
                .Any(invoice => invoice.ClientId == cliente.Id))
                .ToList();
        }

        public void GenerarCliente(ClienteDto clienteNuevo)
        {
            Clients cliente = FactoryCliente.GetCliente(clienteNuevo);
            this._clientsRepository.AddClient(cliente);
        }

        public void EliminarCliente(int idCliente)
        {
            this._clientsRepository.DeleteClient(idCliente);
        }

        public void EliminarFacturasClienteEspecifico(int idCliente)
        {

        }

        public void ModificarCliente(int idCliente)
        {
            this._clientsRepository.ModifyClient(idCliente);
        }
    }
}
