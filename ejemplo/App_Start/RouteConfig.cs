using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ejemplo
{
    public class GestorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ejemplo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ejemplo",
                "ejemplo/{controller}/{action}/{id}",
                new { controller= "ejemplo", action = "Index", id = UrlParameter.Optional },
               new string[] { "ejemplo.Controllers" }
            );
        }
    }
}