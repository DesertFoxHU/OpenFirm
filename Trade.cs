using System.ComponentModel.DataAnnotations.Schema;

namespace OpenFirm
{
    public class Trade
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Symbol { get; set; }
        public string Direction { get; set; }
        public double LotSize { get; set; }
        public double Profit { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
