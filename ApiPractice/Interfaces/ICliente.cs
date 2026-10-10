namespace ApiPractice.Interfaces
{
    public interface ICliente
    {
        string Name { get; set; }
        string BusinessName { get; set; }
        string CUIT { get; set; }
        bool IsActive { get; set; }
        DateTime ActivationDate { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Province { get; set; }
    }
}
