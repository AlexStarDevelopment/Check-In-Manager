using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckInManager.BL;
using CheckInManager.WebAPI.Models;


namespace CheckInManager.WebAPI.Controllers
{
    public class BobController : ApiController
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
        public bool Post([FromBody]Bob cust)
        {
            EmployeeWebLogin loginattempt = new EmployeeWebLogin();
            loginattempt.UserName = cust.UserName;
            loginattempt.Password = cust.Password;
            bool response = loginattempt.Login();
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
