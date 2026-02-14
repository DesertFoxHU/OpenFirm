using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFirm.API
{
    public class Trade
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Symbol { get; set; }
        public string Direction { get; set; }
        public decimal LotSize { get; set; }
        public decimal Profit { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
