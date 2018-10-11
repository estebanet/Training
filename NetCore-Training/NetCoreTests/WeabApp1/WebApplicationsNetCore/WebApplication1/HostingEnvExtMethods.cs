using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1
{
    static class HostingEnvExtMethods
    {
        public static bool IsPreProduccion(this Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            return env.IsEnvironment("prepro");
        }
    }
}
