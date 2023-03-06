

namespace BankApp.Domain.Entity
{
    public class Transaction : BaseEntity
    {
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Account_id { get; set; }
    }
}
