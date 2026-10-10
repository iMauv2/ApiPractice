using ApiPractice.DTOs;
using ApiPractice.Models;

namespace ApiPractice.Interfaces
{
    public interface IRepositoryiClients
    {
        void AddClient(Clients client);

        void DeleteClient(int id);

        void ModifyClient(int id);

        Clients GetClient(int id);

        List<Clients> GetAll();
    }
}
