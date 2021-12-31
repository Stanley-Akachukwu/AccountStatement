namespace SoleDealerAccountStatement
{
    public class AccountStatement
    {
        public int Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? TransactionType { get; set; }
        public string? SourceAccount { get; set; }
        public string? DestinationAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? TransactionDetails { get; set; }
    }
}
