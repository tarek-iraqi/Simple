using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Simple.Extensions.BaseTypes
{
    public class PaginatedResult<T>
    {
        [JsonPropertyName("meta")]
        public PagingMetaData Meta { get; private set; }

        [JsonPropertyName("data")]
        public IEnumerable<T> Data { get; private set; }

        public PaginatedResult() { }

        public PaginatedResult(IEnumerable<T> data, long count, int pageNumber, int pageSize)
        {
            Data = data;
            var totalNumberOfPages = Math.Ceiling((decimal)count / pageSize);
            Meta = new PagingMetaData
            {
                Next = pageNumber < totalNumberOfPages,
                Previous = pageNumber > 1,
                TotalPages = (int)totalNumberOfPages,
                TotalRecords = count,
                PageIndex = pageNumber
            };
        }
    }
}
