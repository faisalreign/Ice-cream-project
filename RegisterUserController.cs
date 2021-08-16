using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using ICECREAMPROJECT.Models;
using System.IO;

namespace ICECREAMPROJECT.Controllers
{
    public class RegisterUserController : Controller
    {
        ICECREAMPROJECTEntities db = new ICECREAMPROJECTEntities();

        // GET: RegisterUser
        [HttpGet]
        public ActionResult Register()
        {
            List<TBL_MEMBERSHIP> li = db.TBL_MEMBERSHIP.ToList();
            ViewBag.list = new SelectList(li, "MEM_ID", "MEM_TYPE");

            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_user u, HttpPostedFileBase imgfile)
        {
            try
            {

                List<TBL_MEMBERSHIP> li = db.TBL_MEMBERSHIP.ToList();
                ViewBag.list = new SelectList(li, "MEM_ID ", "MEM_TYPE ");
                string s = uploadimgfile(imgfile);
                if (s.Equals("-1"))
                {
                    Response.Write("<script> alert('Image uploading failed......') <script>");
                }
                else
                {
                    tbl_user ur = new tbl_user();
                    ur.u_name = u.u_name;
                    ur.u_email = u.u_email;
                    ur.u_password = u.u_password;
                    ur.u_cpassword = u.u_cpassword;
                    ur.u_image = s;
                    ur.u_contact = u.u_contact;
                    ur.u_subs = u.u_subs;
                    db.tbl_user.Add(ur);
                    db.SaveChanges();


                    return RedirectToAction("AfterSignup");

                }

            }
            catch (Exception)
            {


                //throw;
            }
            return View();
        }//Section Method End..........

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");

            //return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_user u)
        {
            tbl_user ui = db.tbl_user.Where(x => x.u_email == u.u_email && x.u_password == u.u_password).SingleOrDefault();
            if (ui != null)
            {
                Session["uid"] = ui.u_id;
                return RedirectToAction("UserPannel");
            }
            else
            {
                ViewBag.error = "Invalid Email or password..........";
            }
            return View();
        }

        [HttpGet]
        public ActionResult UserPannel()
        {
            if (Session["uid"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(tbl_feedback fed)
        {
            TempData["msg"] = null;

            try
            {
                db.tbl_feedback.Add(fed);
                db.SaveChanges();
                TempData["msg"] = "Your FeedBack is submitted successfully...";
                TempData.Keep();
                return RedirectToAction("Contact");
            }
            catch (Exception)
            {
                return RedirectToAction("Errorpage");

                //throw;
            }


            return View();
        }

        public ActionResult AfterSignup()
        {
            return View();
        }

        public ActionResult flavors()
        {
            return View(db.tbl_flavors.ToList());
        }

        public ActionResult Errorpage()
        {
            return View();
        }


        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {

                        path = Path.Combine(Server.MapPath("~/Content/img"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/img/" + random + Path.GetFileName(file.FileName);

                        //    ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Please select a file'); </script>");
                path = "-1";
            }



            return path;
        }




    }
}