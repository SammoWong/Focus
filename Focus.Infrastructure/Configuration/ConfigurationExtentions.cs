using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Focus.Infrastructure.Configuration
{
    public static class ConfigurationExtentions
    {
        public static string Get(this IConfiguration configuration, string key, string defaultValue = null)
        {
            return configuration[key] ?? defaultValue;
        }
    }
}
