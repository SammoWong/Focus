using Focus.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure
{
    public static class AppSettings
    {
        //public static string ApiUrl => "http://localhost:8001";
        public static string ApiUrl { get; set; }

        public static string WebUrl { get; set; }

        public static string AuthUrl { get; set; }
    }
}
