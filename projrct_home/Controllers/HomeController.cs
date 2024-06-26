using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projrct_home.Models;

namespace projrct_home.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        JabbaEntities db = new JabbaEntities();

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Video(Tbl_Feedback fee)
        //{
        //    try
        //    {
        //        db.Tbl_Feedback.Add(fee);
        //        db.SaveChanges();
        //        Response.Write("<script>alert('Saved')</script>");
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write("<script>alert('not Saved')</script>");
        //    }
        //    return View();
        //}
        public ActionResult SignUP()
        {
        return View();
        }
        public ActionResult Register()
        {
        return View();
        }

        [HttpPost]
        public ActionResult Register(Register_Table reg,string hdn1,string ct1)
        {
            try
            {
                if (hdn1 == ct1)
                {
                    //start code of file
                    HttpPostedFileBase file = Request.Files["Profile"];
                    reg.Profile = file.FileName;
                    //End code for file
                    reg.RegDate = DateTime.Now.ToString();                              //Used for date and time
                    file.SaveAs(Server.MapPath("~/Content/IMG/)" + file.FileName));
                    db.Register_Table.Add(reg);                                       //Record insert 
                    db.SaveChanges();                                                   //Save values permanently
                    Response.Write("<script>alert('Record saved successfully !')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Captcha code !')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Record not saved')</script>");
            }
            return View();
        }
        public ActionResult Contact()   //get action for contact
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(TBL_Contact con)   //post action for contact 
        {
            try
            {
                con.Contactdate = DateTime.Now.ToString();
                db.TBL_Contact.Add(con);
                db.SaveChanges();
                Response.Write("<script>alert('Record Saved Successfully !')</script>");
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('Record not saved !')</script>");
            }
            return View();
        }
     
        public ActionResult Registration()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();    //login get method
        }
        [HttpPost]
        public ActionResult LogIn(TBL_Login lg)
        {
            try
            {
                TBL_Login t1 = db.TBL_Login.Where(x => x.Email == lg.Email && x.Password == lg.Password).SingleOrDefault();
                if (t1 != null)
                {
                    Session["aid"] = lg.Email;          //set of session
                    Response.Write("<script>alert('Welcome !');window.location.href='/AdminZone/Index'</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid UserId or Password !')</script>");
                }
            }
            catch(Exception ex) 
            {
                Response.Write("<script>alert('Invalid !')</script>");

            }
            return View();    //login post method
        }
        public ActionResult Image()
        {
            return View();
        }
        public ActionResult Video()
        {
            return View();
        }

    }
}


































































































































































































