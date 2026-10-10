using ApiPractice.Models;

namespace ApiPractice.Interfaces
{
    public interface IInvoiceService
    {
        List<Invoices> GetFacturasCliente(int idCliente);

        decimal GetMontoFacturadoTotalPorCliente(int idCliente);

        void ModificarFactura(int idFactura);

        void GenerarFactura(int idCliente);

        void EliminarTodasFacturasCliente(int idCliente);
    }
}
