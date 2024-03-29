﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FizyoterapiSite.Controllers
{
    public class ErrorPageController : Controller
    {
        [AllowAnonymous]
        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
        [AllowAnonymous]
        public ActionResult PageDefault()
        {
            return View();
        }
    }
}