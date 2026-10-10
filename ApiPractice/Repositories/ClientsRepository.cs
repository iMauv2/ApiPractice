using ApiPractice.Data;
using ApiPractice.DTOs;
using ApiPractice.Interfaces;
using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPractice.Repositories
{
    public class ClientsRepository : IRepositoryiClients
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryInvoice _repositoryInvoiceService;

        public ClientsRepository(ApplicationDbContext dbContext, IRepositoryInvoice repositoryInvoice)
        {
            _context = dbContext;
            _repositoryInvoiceService = repositoryInvoice;

        }

        public void AddClient(Clients client)
        {
            _context.clients.Add(client);
            _context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            Clients client = _context.clients.FirstOrDefault(p => p.Id == id);
            if (client != null)
            {
                _context.clients.Remove(client);
            }
        }

        public Clients GetClient(int id)
        {
            return _context.clients.FirstOrDefault(p => p.Id == id);
        }

        public void ModifyClient(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clients> GetAll()
        {
            return _context.clients.ToList();
        }
    }
}
