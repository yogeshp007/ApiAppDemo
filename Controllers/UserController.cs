using ApiAppDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserDetail model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress + "/demo/AddUser", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            UserDetail user = new UserDetail();

            var response = client.GetAsync(client.BaseAddress + "/demo/GetUserById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserDetail>(data);
            }

            return View("Create", user);
        }

        [HttpPost]
        public ActionResult Edit(UserDetail model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PutAsync(client.BaseAddress + "/demo/UpdateUser/" + model.Id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {            
            var response = client.DeleteAsync(client.BaseAddress + "/demo/DeleteUser/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}