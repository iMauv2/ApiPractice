using ApiPractice.Interfaces;
using ApiPractice.Models;

namespace ApiPractice.Services
{
    public class InvoiceServices : IInvoiceService
    {
        private readonly IRepositoryInvoice _repositoryInvoice;

        public InvoiceServices(IRepositoryInvoice repositoryInvoice)
        {
            this._repositoryInvoice = repositoryInvoice;
        }

        //Obtener todas las facturas de un cliente específico(por ID).
        public List<Invoices> GetFacturasCliente(int idCliente)
        {
            return [.. _repositoryInvoice.GetAll().Where(p => p.ClientId == idCliente)];
        }

        //Calcular el monto total facturado para un cliente específico.
        public decimal GetMontoFacturadoTotalPorCliente(int idCliente)
        {
            return _repositoryInvoice.GetAll().Where(p => p.Id == idCliente).Sum(p => p.TotalAmount);
        }

        public void GenerarFactura(int idCliente)
        {//Tal vez seria necesario agregar una validacion de si existe el usuario
            //ToDo: Pasar esta instancia a un factory
            Invoices factura = new()
            {
                ClientId = idCliente,
                Date = DateTime.Now,
                TotalAmount = 1000.0m,//consultar por que aclarar con m
            };

            this._repositoryInvoice.AddInvoice(factura);
        }

        public void ModificarFactura(int idFactura)
        {//Todo: Marcar una factura como pagada. Refactorizar esta logica
            Invoices factura = this._repositoryInvoice.GetInvoice(idFactura);

            factura.IsPaid = true;
        }

        public void EliminarTodasFacturasCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        //public void EliminarFacturasSegunCliente(int idCliente)
        //{ //ToDo: Buscar como eliminar en una transaccion todas las facturas a la vez.
        //    try
        //    {
        //        // 1. Buscar los registros relacionados (hijos) asociados al ID principal
        //        var registrosRelacionados = this._repositoryInvoice
        //            .GetAll().Where(h => h.ClientId == idCliente)
        //            .ToList();

        //        // 2. Eliminar la colección usando RemoveRange
        //        this._repositoryInvoice.Hijos.RemoveRange(registrosRelacionados);

        //        // Opcional: Si también quieres eliminar el registro principal
        //        // var principal = context.Padres.Find(idPrincipal);
        //        // if (principal != null) context.Padres.Remove(principal);

        //        // 3. Guardar cambios (esto ejecuta el DELETE masivo)
        //        context.SaveChanges();

        //        // 4. Confirmar la transacción
        //        transaction.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //                // Si ocurre un error, se revierte todo automáticamente
        //                transaction.Rollback();
        //                // Manejar el error...
        //    }
        //}
    }
}
