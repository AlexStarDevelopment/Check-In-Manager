using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckInManager.WebAPI2.Models;
using CheckInManager.BL;

namespace CheckInManager.WebAPI2.Controllers
{
    public class AttemptController : ApiController
    {
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public int Get(int id)
        {
            return id;
        }

        // POST: api/Login
        public bool Post([FromBody]EmployeeWebLogin user)
        {
            //EmployeeWebLogin loginattempt = new EmployeeWebLogin
            //{
            //    UserName = user.UserName,
            //    Password = user.Password
            //};
            //bool response = loginattempt.Login();
            bool response = user.Login();
            return response;

        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
