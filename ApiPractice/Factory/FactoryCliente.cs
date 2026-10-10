using ApiPractice.DTOs;
using ApiPractice.Interfaces;
using ApiPractice.Models;

namespace ApiPractice.Factory
{
    public static class FactoryCliente
    {
        public static Clients GetCliente(ICliente clienteNuevo)
        {
            return new()
            {
                Name = clienteNuevo.Name,
                BusinessName = clienteNuevo.BusinessName,
                CUIT = clienteNuevo.CUIT,
                IsActive = clienteNuevo.IsActive,
                ActivationDate = clienteNuevo.ActivationDate,
                Email = clienteNuevo.Email,
                Phone = clienteNuevo.Phone,
                Address = clienteNuevo.Address,
                City = clienteNuevo.City,
                Province = clienteNuevo.Province,
            };
        }
    }
}
