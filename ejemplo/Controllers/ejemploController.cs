﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemplo.Controllers
{
    public class ejemploController : Controller
    {
        // GET: ejemplo
        public ActionResult Index()
        {
            return View();
        }
    }
}