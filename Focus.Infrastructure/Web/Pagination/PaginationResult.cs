using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Web.Pagination
{
    public class PaginationResult
    {
        public int Total { get; set; }

        public IEnumerable<object> Rows { get; set; }

        public PaginationResult(int total, IEnumerable<object> source)
        {
            Total = total;
            Rows = source;
        }
    }
}
