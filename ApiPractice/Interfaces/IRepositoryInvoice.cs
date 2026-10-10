using ApiPractice.Models;

namespace ApiPractice.Interfaces
{
    public interface IRepositoryInvoice
    {
        void AddInvoice(Invoices invoice);

        void DeleteInvoice(int id);

        void ModifyInvoice(int id);

        Invoices GetInvoice(int id);

        List<Invoices> GetAll();
    }
}
