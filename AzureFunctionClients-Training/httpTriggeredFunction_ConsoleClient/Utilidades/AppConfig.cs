using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httpTriggeredFunction_ConsoleClient.Utilidades
{
    static class AppConfig
    {
        public static string ClientTestKey { get { return ConfigurationManager.AppSettings["ClientTestKey"]; } }
        public static string RequestURI { get { return ConfigurationManager.AppSettings["RequestURI"]; } }
        public static string BaseAddress { get { return ConfigurationManager.AppSettings["BaseAddress"]; } }
    }
}
