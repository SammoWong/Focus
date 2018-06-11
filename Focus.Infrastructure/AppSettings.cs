using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Infrastructure
{
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            ApiUrl = configuration["appSettings:apiUrl"];
        }
        public static string ApiUrl { get; set; }

    }
}
