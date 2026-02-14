using System.Text.Json.Serialization;

namespace OpenFirm.BackOffice.Data
{
    public class QueryResult<T>
    {
        [JsonPropertyName("data")]
        public required List<T> Data { get; set; }
        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }
    }
}
