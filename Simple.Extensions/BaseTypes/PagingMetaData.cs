using System.Text.Json.Serialization;

namespace Simple.Extensions.BaseTypes
{
    public class PagingMetaData
    {
        [JsonPropertyName("has_previous")]
        public bool Previous { get; set; }

        [JsonPropertyName("has_next")]
        public bool Next { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_records")]
        public long TotalRecords { get; set; }

        [JsonPropertyName("page_index")]
        public int PageIndex { get; set; }
    }
}
