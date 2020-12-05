using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projectPart3.Models;
using System.Data.SqlClient;

namespace projectPart3.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-O9RLMB0;initial catalog=LT;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        }
        [HttpPost]
        public ActionResult Verify(Admin acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from admins where tai_khoan='"+acc.tai_khoan+"' and mat_khau='"+acc.mat_khau+"'";
            /*Session["tai_khoan"] = acc.tai_khoan;*/
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "SanPhams");
            }
            else
            {
                con.Close();
                return View("Error");
            }

        }
    }
}