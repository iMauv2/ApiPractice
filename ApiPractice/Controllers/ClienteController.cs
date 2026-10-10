using ApiPractice.DTOs;
using ApiPractice.Interfaces;
using ApiPractice.Models;
using ApiPractice.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controllers
{
    [ApiController]
    [Route("api/v1/clientes")]
    public class ClienteController : ControllerBase
    {//Controller encargado de manejar los clientes y sus facturas
        private readonly IClientsService _clientsService;
        private readonly IInvoiceService _invoiceService;

        public ClienteController(IClientsService _clientsService, IInvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
            this._clientsService = _clientsService;
        }

        #region Post
        //Crear un nuevo cliente.
        [HttpPost]
        public void PostCliente([FromBody] ClienteDto clienteNuevo)
        {
            this._clientsService.GenerarCliente(clienteNuevo);
        }

        //Crear una nueva factura.
        [HttpPost("{idCliente}/facturas")]
        public void PostFactura([FromRoute] int idCliente)
        {
            this._invoiceService.GenerarFactura(idCliente);
        }

        #endregion

        #region Put
        //    Actualizar un cliente existente.
        [HttpPut("{idCliente}/actualizarCliente")]
        public void ModifyCliente([FromRoute] int idCliente)
        {
            this._clientsService.ModificarCliente(idCliente);
        }

        //    Marcar una factura como pagada.
        [HttpPut("{idCliente}/actualziarfactura")]
        public void ModifyFactura([FromRoute] int idCliente)
        {
            this._clientsService.ModificarCliente(idCliente);
        }

        //#endregion

        //#region Get
        //Obtener todos los clientes activos.
        [HttpGet]
        public void GetTodosClientesActivos()
        {
            this._clientsService.GetClientesActivo();
        }

        //Obtener los clientes activados en los últimos 90 días.
        [HttpGet("obtenerclientesactivos")]
        public void GetTodosClientesActivadosUltimosNoventaDias()
        {
            this._clientsService.GetClientesActivosUltimosNoventaDias();
        }

        //Obtener todas las facturas de un cliente específico(por ID).
        [HttpGet("{idCliente}/obtenertodaslasfacturasdelciente")]
        public void GetObtenerFacturasClienteEspecifico(int idCliente)
        {
            this._invoiceService.GetFacturasCliente(idCliente);

        }

        //Obtener todos los clientes con facturas impagas.
        [HttpGet("getclientesfacturasimpagas")]
        public void GetClientesFacturasImpagas()
        {
            this._clientsService.GetClientesFacturasImpagas();
        }

        //Calcular el monto total facturado para un cliente específico
        [HttpGet("{idCliente}/montototal")]
        public void GetMontoTotalFacturado(int idCliente)
        {
            this._invoiceService.GetMontoFacturadoTotalPorCliente(idCliente);
        }

        //Obtener clientes sin facturas.
        [HttpGet("getclientessinfacturas")]
        public List<Clients> GetClientesSinFacturas()
        {
            return this._clientsService.GetClientesSinFacturas();
        }

        #endregion

        #region Delete
        //Eliminar un cliente por ID.
        [HttpDelete("deletecliente")]
        public void DeleteCliente(int idCliente)
        {
            this._clientsService.EliminarCliente(idCliente);
        }

        //Eliminar todas las facturas de un cliente específico.
        [HttpDelete("deletetodasfacturascliente")]
        public void DeleteAllFacturasCliente(int idCliente)
        {
            this._invoiceService.EliminarTodasFacturasCliente(idCliente);
        }
        #endregion
    }
}
