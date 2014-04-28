using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Controllers
{
    [AuthorizeWithSession]
    public class RequestsController : Controller
    {
        //
        // GET: /Requests/
        public ActionResult Index()
        {
            JObject requests = GetUserRequests();
            ViewBag.Message = Request.QueryString["message"];
            return View(requests);
        }

        public ActionResult Cancel (string requestId)
        {
            Utils.AlmaApiDelete("/users/" + Session["email"] + "/requests/" + requestId);
            return RedirectToAction("", new { message = "Your request was successfully cancelled." });
        }

        private JObject GetUserRequests()
        {
            var json = Utils.AlmaApiGet("/users/" + Session["email"] + "/requests");
            JObject requests = JsonConvert.DeserializeObject<JObject>(json);
            return requests;
        }
	}
}