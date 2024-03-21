using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiAppDemo.Controllers
{
    public class TestApiController : ApiController
    {
        [HttpGet]
        public string Name()
        {
            return "Hello, This is my first API";
        }

        [HttpGet]
        public string AddNames(string id)
        {
            string name = "yagnesh,ruchi,pruthvi";
            name = name + "," + id;
            return name;
        }
    }
}
