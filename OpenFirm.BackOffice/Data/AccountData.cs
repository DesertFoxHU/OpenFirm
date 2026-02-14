using System.Text.Json.Serialization;

namespace OpenFirm.BackOffice.Data
{
    public class AccountData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("traderName")]
        public required string TraderName { get; set; }
        [JsonPropertyName("balance")]
        public decimal Balance { get; set; }
        [JsonPropertyName("initialBalance")]
        public decimal InitialBalance { get; set; }
        [JsonPropertyName("status")]
        public required string Status { get; set; }
    }
}
