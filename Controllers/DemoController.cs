using ApiAppDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiAppDemo.Controllers
{
    public class DemoController : ApiController
    {
        private DbEntities db = new DbEntities();

        /// <summary>
        /// returns all user details - api/demo/getalluser
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserDetail> GetAllUsers()
        {
            return db.UserDetails.ToList();
        }

        /// <summary>
        /// get userdetail by id - api/demo/getuserbyid/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public UserDetail GetUserById(int id)
        {
            return db.UserDetails.Find(id);
        }

        [HttpPost]
        public string AddUser(UserDetail user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Uname) && !string.IsNullOrEmpty(user.Ucity))
            {
                db.UserDetails.Add(user);
                db.SaveChanges();
                return "user details added succesfully";
            }
            else
            {
                return "please enter proper details";
            }
        }


        [HttpPut]
        public string UpdateUser(int id, UserDetail user)
        {
            if (id > 0 
                && user != null 
                && !string.IsNullOrEmpty(user.Uname) 
                && !string.IsNullOrEmpty(user.Ucity))
            {
                UserDetail udetail = db.UserDetails.Find(id);
                udetail.Uname = user.Uname;
                udetail.Ucity = user.Ucity;
                db.SaveChanges();
                return "user details updated succesfully";
            }
            else
            {
                return "please enter proper details";
            }
        }

        [HttpDelete]
        public string DeleteUser(int id)
        {
            if (id > 0)
            {
                UserDetail udetail = db.UserDetails.Find(id);
                db.UserDetails.Remove(udetail);
                db.SaveChanges();
                return "user details removed succesfully";
            }
            else
            {
                return "please enter proper user id";
            }
        }

    }
}
