using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure.Web.Pagination
{
    /// <summary>
    /// 服务端分页请求参数
    /// </summary>
    public class PaginationRequest
    {
        public int Start { get; set; }

        public int Take { get; set; }
    }
}
