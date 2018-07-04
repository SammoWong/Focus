using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Focus.Infrastructure.Mvc
{
    /// <summary>
    /// 系统级错误描述
    /// </summary>
    public enum StandardCode
    {
        [Description("成功")]
        Success = 0,

        [Description("参数错误")]
        ArgumentError = 1,

        [Description("逻辑错误")]
        LogicError = 2,

        [Description("内部错误")]
        InternalError = 3,

        [Description("未授权")]
        Unauthorized = 4,
    }
}
