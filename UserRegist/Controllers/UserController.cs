using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegist.Models;

namespace UserRegist.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Edit(int id=0)
        {
            User user = new User();

            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            using(DBModels db=new DBModels())
            {
                if (db.Users.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "User Name Already Exist ";
                    return View("Edit", user);
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration SuccessFull";
            return View("Edit",new User());
        }
    }
}