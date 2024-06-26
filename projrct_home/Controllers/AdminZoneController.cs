using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projrct_home.Models;

namespace projrct_home.Controllers
{
    
    public class AdminZoneController : Controller
    {
        //
        // GET: /AdminZone/
        JabbaEntities db = new JabbaEntities();

        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult ContactMGMT()
        {
           
            List<TBL_Contact> lst=null;
            lst=db.TBL_Contact.ToList();
            return View(lst);
        }
       
        public ActionResult Registered()
        {
           
            List<Register_Table> lst = null;
            lst = db.Register_Table.ToList();
            return View(lst);
        }
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string NewPass, string OldPass, string ConfirmPass)
        {
            if (NewPass == ConfirmPass)
            {
               //string Email = Session["aid"].ToString();
                TBL_Login lg = db.TBL_Login.Where(x => x.Password == OldPass && x.Email == x.Email).SingleOrDefault();
                lg.Password = NewPass;
                db.SaveChanges();
                Response.Write("<script>alert('Your Password Changed  !').window.location.href='/Home/Login'</script>");
            }
            else
            {
                Response.Write("<script>alert('Please Enter Confirm Password !')</script>");
            }
            return View();
        }
        public ActionResult PlanMGMT()
        {
          
            List<Register_Table> lst = null;
            lst = db.Register_Table.ToList();
            return View(lst);
            
        }
     
        public void LogOut()
        {
          
            Session.Abandon();
            Response.Write("<script>alert('LogOut');window.location.href='/Home/LogIn'</script>");
        }
        public void Delete()
        {
            try
            {
                string m = Request.QueryString["m"];
                Register_Table tbl = db.Register_Table.SingleOrDefault(x => x.Email == m);
                db.Register_Table.Remove(tbl);
                db.SaveChanges();
                Response.Write("<script>alert('Deleted successfully !');window.location.href='/AdminZone/Registered'</script>");
            }
            catch  (Exception ex)
            {
                Response.Write("<script>alert('Deletion Failed !');window.location.href='/AdminZone/Registered'</script>");
            
            }      
            
            
            }
        [HttpGet]
        public ActionResult UpdateRecord()                  //update get method
        {
            string aid = Request.QueryString["U"];
           Register_Table reg = db.Register_Table.SingleOrDefault(a => a.Email == aid);
            return View(reg);
        }
        [HttpPost]
        public void UpdateRecord(Register_Table reg, string email)
        {
            Register_Table rg = db.Register_Table.SingleOrDefault(a => a.Email == email);
            try
            {
                HttpPostedFileBase file = Request.Files["Profile"];
                if (file.FileName != "")
                {
                    rg.Name = reg.Name;
                    rg.Mobile = reg.Mobile;
                    rg.Gender = reg.Gender;
                    rg.DOB = reg.DOB;
                    rg.Street = reg.Street;
                    rg.City = reg.City;
                    rg.State = reg.State;
                    rg.CPlan = reg.CPlan;
                    rg.CW = reg.CW;
                    rg.DW = reg.DW;
                    rg.Trainer = reg.Trainer;
                    rg.Before = reg.Before;
                    rg.Profile = file.FileName;
                    rg.RegDate = DateTime.Now.ToString();
                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("~/Content/IMG/" + file.FileName));
                    Response.Write("<script>alert('Updated Successfully !');window.location.href='/AdminZone/Registered'</script>");
                }
                else
                {
                    Register_Table dd = db.Register_Table.SingleOrDefault(x => x.Email == email);
                    dd.Name = reg.Name;
                    dd.Mobile = reg.Mobile;
                    dd.Gender = reg.Gender;
                    dd.DOB = reg.DOB;
                    dd.Street = reg.Street;
                    dd.City = reg.City;
                    dd.State = reg.State;
                    dd.CPlan = reg.CPlan;
                    dd.CW = reg.CW;
                    dd.DW = reg.DW;
                    dd.Trainer = reg.Trainer;
                    dd.Before = reg.Before;
                   // dd.Profile = file.FileName;
                    dd.RegDate = DateTime.Now.ToString();
                    db.SaveChanges();
                   // file.SaveAs(Server.MapPath("~/Content/IMG/" + file.FileName));
                    Response.Write("<script>alert('Updated Successfully without profile!');window.location.href='/AdminZone/Registered'</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('Updation Failed !');window.location.href='/AdminZone/Registered'</script>");
            }
        }
       
    }
}
