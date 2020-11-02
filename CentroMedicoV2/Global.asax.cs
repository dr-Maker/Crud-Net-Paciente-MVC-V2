using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CentroMedicoV2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["login"] = "";
            Session["idusuario"] = "0";
            Session["usuario"] = "";
            Session["email"] = "";
            Session["perfil"] = "2";
            Session["fechahoy"] = DateTime.Today.ToString("dd/MM/yyyy");

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session["login"] = "";
            Session["idusuario"] = "0";
            Session["usuario"] = "";
            Session["email"] = "";
            Session["perfil"] = "2";
            Session["fechahoy"] = DateTime.Today.ToString("dd/MM/yyyy");
        }

    }
   
}
