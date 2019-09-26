using FBM.Data.API;
using FBM.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using FBM.Data.Entity.Players;

namespace FBM.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            base.CheckMobile();
            return View();
        }
    }
}