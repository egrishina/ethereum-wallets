namespace EthereumWallets.Domain.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public string? Address { get; set; }

        public decimal Balance { get; set; }
    }
}
