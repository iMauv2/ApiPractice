using ApiPractice.Data;
using ApiPractice.Interfaces;
using ApiPractice.Models;

namespace ApiPractice.Repositories
{
    public class InvoiceRepository : IRepositoryInvoice
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public void AddInvoice(Invoices invoice)
        {
            _context.invoices.Add(invoice);
        }

        public Invoices GetInvoice(int id)
        {
            return _context.invoices.FirstOrDefault(p => p.Id == id);
        }

        public void DeleteInvoice(int id)
        {
            Invoices invoices = _context.invoices.FirstOrDefault(p => p.Id == id);
            if (invoices != null)
            {
                _context.invoices.Remove(invoices);
            }
        }

        public void ModifyInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoices> GetAll()
        {
            return _context.invoices.ToList();
        }
    }
}
