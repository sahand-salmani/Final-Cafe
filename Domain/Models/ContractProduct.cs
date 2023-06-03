namespace Domain.Models
{
    public class ContractProduct
    {
        public int ContractId { get; set; }
        public int ProductId { get; set; }

        public Contract Contract { get; set; }
        public Product Product { get; set; }
    }
}
