using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Web.Pagination
{
    public class PaginationRequest
    {
        public int Start { get; set; }

        public int Take { get; set; }
    }
}
