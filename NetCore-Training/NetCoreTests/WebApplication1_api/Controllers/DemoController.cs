using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_api.Controllers
{
    public class DemoController: Controller
    {
        [HttpPost("api/garo/demo/{id:int?}")]
        public IActionResult Demo(int id, Models.User user, [FromBody]Models.Product product)
        {
            return Ok(new { id, user, product });
        }
    }
}
