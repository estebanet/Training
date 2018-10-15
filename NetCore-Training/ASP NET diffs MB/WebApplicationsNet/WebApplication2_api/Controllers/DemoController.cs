using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2_api.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [HttpPost]
        public IHttpActionResult GetSomething(Shared.DTOs.Product product, [FromUri]Shared.DTOs.User user,
            int id = 25)
        {
            return Ok(new { id, product, user });
        }

        //public IHttpActionResult GetSome()
        //{
        //    return Ok("Ok");
        //}
    }
}
