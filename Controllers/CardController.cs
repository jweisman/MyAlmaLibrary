using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        //
        // GET: /Card/
        public ActionResult Index()
        {
            JObject user = GetUser();
            ViewBag.Message = Request.QueryString["message"];
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(UserViewModel formUser)
        {
            JObject user = GetUser();
            user["first_name"] = formUser.first_name;
            user["last_name"] = formUser.last_name;

            JObject updateduser = UpdateUser(user);
            ViewBag.Message = "Your details were updated successfully.";
            return View(updateduser);
        }

        private JObject GetUser()
        {
            var json = Utils.AlmaApiGet("/users/" + Session["email"]);
            JObject user = JsonConvert.DeserializeObject<JObject>(json);
            return user;
        }

        private JObject UpdateUser(JObject user)
        {
            var json = Utils.AlmaApiPut("/users/" + Session["email"], user.ToString());
            JObject newuser = JsonConvert.DeserializeObject<JObject>(json);
            return user;
        }
	}
}