namespace ApiPractice.Models
{
    public class Invoices
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }

        // Propiedad de navegación hacia el cliente
        //public Client Client { get; set; } = null!;
    }
}
