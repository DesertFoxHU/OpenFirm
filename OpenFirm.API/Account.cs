namespace OpenFirm.API
{
    public class Account
    {
        public int Id { get; set; }
        public string TraderName { get; set; }
        public decimal Balance { get; set; }
        public decimal InitialBalance { get; set; }
        public AccountStatus Status { get; set; } = AccountStatus.Evaulation;
    }
}
