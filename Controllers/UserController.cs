using ApiAppDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ApiAppDemo.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44302/api");
        HttpClient client;

        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // GET: User
        public ActionResult Index()
        {
            List<UserDetail> list = new List<UserDetail>();

            var response = client.GetAsync(client.BaseAddress + "/demo/getallusers").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<UserDetail>>(data);
            }

            return View(list);
        }
    }
}