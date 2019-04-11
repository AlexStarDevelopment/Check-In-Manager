using CheckInManager.PL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CheckInManager.BL
{
    public class CEmployees
    {
        #region Props
        //props
        public int EmployeeID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Birthday")]
        public DateTime DOB { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [DisplayName("Username")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        [DisplayName("Role")]
        public int RoleID { get; set; }
        [DisplayName("Employee is Active")]
        public bool isActive { get; set; }
        #endregion

        #region Cpnstructors
        public CEmployees() { }

        //add an employee
        public CEmployees(int employeeid, string firstname, string lastname, DateTime dob, string street, string city, string state, string zipcode, string phone, string email, string username, string password, string key, int roleid)
        {
            EmployeeID = employeeid;
            FirstName = firstname;
            LastName = lastname;
            DOB = dob;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipcode;
            Phone = phone;
            Email = email;
            UserName = username;
            Password = password;
            Key = key;
            RoleID = roleid;
        } 
        #endregion

        #region LoginLogic
        //Login Logic
        public CEmployees(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public bool Login()
        {
            try
            {
                if (UserName != string.Empty && Password != string.Empty) //finds an employee with the username passed in
                {
                    LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                    tblEmployee user = oDc.tblEmployees.FirstOrDefault(p => p.UserName == this.UserName && p.IsActive == true);

                    if (user != null)
                    {

                        tblEmployee user2 = oDc.tblEmployees.FirstOrDefault(p => p.Password == this.Password); //checks the password with the username 

                        if (user.Password == GetHash())
                        {
                            //This code runs if the username and password are a match

                            //sets the employee
                            FirstName = user.FirstName;
                            LastName = user.LastName;
                            Password = user.Password;
                            DOB = (DateTime)user.DOB;
                            Street = user.Street;
                            City = user.City;
                            State = user.State;
                            ZipCode = user.ZipCode;
                            Phone = user.Phone;
                            UserName = user.UserName;
                            Key = user.Key;
                            Password = user.Password;
                            Email = user.Email;
                            EmployeeID = user.EmployeeID;
                            RoleID = (int)user.RoleID;

                            //set the login class to the employee so we can identify who is logged in - this may not be needed so ignore this for now.
                            // CLogin.set(EmployeeID);

                            //login is a success 
                            oDc = null;
                            return true;
                        }
                        else
                        {
                            oDc = null;
                            //throw new Exception("Credentials are incorrect");
                            return false;
                        }
                    }
                    else
                    {

                        oDc = null;
                        //throw new Exception("User ID: " + UserName + " could not be found");
                        return false;
                    }

                }
                else
                {

                    //throw new Exception("User ID and Password cannot be blank. Try again");
                    return false;
                }


            }
            catch (Exception ex)
            {
                //error logging stuff
                //CErrorLog err = new CErrorLog();
                //err.LogError(ex.Message);
                throw ex;
            }
        }
        #endregion


        #region CRUD Logic
        //methods
        public void Insert()
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();
                tblEmployee tblEmployee = new tblEmployee();
                tblEmployee.EmployeeID = 1;
                // automatically calculate the new EmployeeID
                if (oDc.tblEmployees.Any())
                    tblEmployee.EmployeeID = oDc.tblEmployees.Max(p => p.EmployeeID) + 1;

                // fill in the data
                this.EmployeeID = tblEmployee.EmployeeID;
                tblEmployee.FirstName = this.FirstName;
                tblEmployee.LastName = this.LastName;
                tblEmployee.DOB = this.DOB;
                tblEmployee.Street = this.Street;
                tblEmployee.City = this.City;
                tblEmployee.State = this.State;
                tblEmployee.ZipCode = this.ZipCode;
                tblEmployee.Phone = this.Phone;
                tblEmployee.Email = this.Email;
                tblEmployee.UserName = this.UserName;
                tblEmployee.Password = this.Password;
                tblEmployee.Password = this.GetHash();
                tblEmployee.Key = this.Key;
                tblEmployee.RoleID = this.RoleID;
                tblEmployee.IsActive = true;
               

                oDc.tblEmployees.Add(tblEmployee);
                oDc.SaveChanges();
                oDc = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(int id)
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var item = (from p in oDc.tblEmployees
                            where p.EmployeeID == id
                            select p).FirstOrDefault();

                if (item != null)
                {
                    if(this.Password != item.Password)
                    {
                        this.Password = this.GetHash();
                    }

                    this.EmployeeID = this.EmployeeID;
                    item.FirstName = this.FirstName;
                    item.LastName = this.LastName;
                    item.Street = this.Street;
                    item.City = this.City;
                    item.State = this.State;
                    item.ZipCode = this.ZipCode;
                    item.Phone = this.Phone;
                    item.Email = this.Email;
                    item.UserName = this.UserName;
                    item.Password = this.Password;
                    item.Key = this.Key;
                    item.RoleID = this.RoleID;
                    item.IsActive = this.isActive;
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                var item = (from p in oDc.tblEmployees
                            where p.EmployeeID == id
                            select p).FirstOrDefault();

                if (item != null)
                {
                    item.IsActive = false;
                    oDc.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Add an update to "delete" make employee's not active


        public void LoadById(int id)
        {
            LFGuestSystemEntities db = new LFGuestSystemEntities();

            var d = (from p in db.tblEmployees
                     where p.EmployeeID == id && p.IsActive == true
                     orderby p.EmployeeID
                     select new
                     {
                         p.EmployeeID,
                         p.FirstName,
                         p.LastName,
                         p.Phone,
                         p.Street,
                         p.City,
                         p.State,
                         p.DOB,
                         p.ZipCode,
                         p.Email,
                         p.UserName,
                         p.Password,
                         p.Key,
                         p.RoleID
                     }).FirstOrDefault();

            this.EmployeeID = d.EmployeeID;
            this.FirstName = d.FirstName;
            this.LastName = d.LastName;
            this.DOB = (DateTime)d.DOB;
            this.Phone = d.Phone;
            this.Street = d.Street;
            this.City = d.City;
            this.State = d.State;
            this.ZipCode = d.ZipCode;
            this.Email = d.Email;
            this.UserName = d.UserName;
            this.Password = d.Password;
            this.Key = d.Key;
            
        }
        #endregion

        //password hashing
        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }
        public void Seed()
        {
            // First User Created
            //CUser newuser = new CUser("akrahn", "alex", "krahn", "maple");

            CEmployees newuser = new CEmployees();
            newuser.Password = newuser.GetHash();
            tblEmployee otblUser1 = new tblEmployee();
            newuser.Map(otblUser1);
            newuser.Insert();

        }

        public void Seed(string uname, string first, string last, string pass, string street, string city, string state, string zip, string email, string phone, int roll, DateTime dob)
        {
            // First User Created
            //CUser newuser = new CUser("akrahn", "alex", "krahn", "maple");
            CEmployees newuser = new CEmployees();
            newuser.UserName = uname;
            newuser.FirstName = first;
            newuser.LastName = last;
            newuser.Password = pass;
            newuser.Password = newuser.GetHash();
            newuser.Street = street;
            newuser.City = city;
            newuser.State = state;
            newuser.ZipCode = zip;
            newuser.Email = email;
            newuser.Phone = phone;
            newuser.RoleID = RoleID;
            newuser.DOB = dob;
            tblEmployee otblUser1 = new tblEmployee();
            newuser.Map(otblUser1);
            newuser.Insert();

        }

        public void Map(tblEmployee emp)
        {
            emp.EmployeeID = this.EmployeeID;
            emp.FirstName = this.FirstName;
            emp.LastName = this.LastName;
            emp.Street = this.Street;
            emp.City = this.City;
            emp.State = this.State;
            emp.ZipCode = this.ZipCode;
            emp.Phone = this.Phone;
            emp.Email = this.Email;
            emp.UserName = this.UserName;
            emp.Password = this.Password;
            emp.Key = this.Key;
            emp.RoleID = this.RoleID;
            emp.IsActive = this.isActive;
        }
        
       

    }
    public class CEmployeesList : List<CEmployees>
    {
        public void Load()
        {
            LFGuestSystemEntities oDc = new LFGuestSystemEntities();

            var Employees = from p in oDc.tblEmployees
                            where p.IsActive == true
                            orderby p.LastName
                            select p;

            foreach (var s in Employees)
            {
                CEmployees e = new CEmployees();
                e.City = s.City;
                e.DOB = (DateTime)s.DOB;
                e.Email = s.Email;
                e.EmployeeID = s.EmployeeID;
                e.FirstName = s.FirstName;
                e.Key = s.Key;
                e.LastName = s.LastName;
                e.Password = s.Password;
                e.Phone = s.Phone;
                e.RoleID = (int)s.RoleID;
                e.State = s.State;
                e.Street = s.Street;
                e.UserName = s.UserName;
                e.ZipCode = s.ZipCode;

                this.Add(e);
            }
        }
    }
    public class EmployeeWebLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public EmployeeWebLogin() { }
        public EmployeeWebLogin(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        //password hashing
        private string GetHash()
        {
            using (var hash = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hash.ComputeHash(hashbytes));
            }
        }
        public bool Login()
            {
                try
                {
                    if (UserName != string.Empty && Password != string.Empty)
                    {
                        LFGuestSystemEntities oDc = new LFGuestSystemEntities();

                        tblEmployee user = oDc.tblEmployees.FirstOrDefault(p => p.UserName == this.UserName);

                        if (user != null)
                        {
                            if (user.Password == GetHash())
                            {
                            oDc = null;
                            return true;
                            }
                            else
                            {
                                oDc = null;
                                return false;
                            }
                        }
                        else
                        {

                            oDc = null;
                            return false;
                        }

                    }
                    else
                    {
                        return true;
                    }


                }
                catch
                {
                return false;
            }

        }
    }
}
