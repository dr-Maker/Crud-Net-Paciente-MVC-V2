using Buss;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CentroMedicoV2.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Msg = "";
            ViewBag.Display = "none";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            UsuarioModel obj = new UsuarioModel();
            obj.Usuario = frm["usuario"].ToString();
            obj.Clave = frm["clave"].ToString();
            DataTable dt = BussUsuario.ValidarPaciente(obj);
            if (dt != null && dt.Rows.Count > 0)
            {
                Session["login"] = "N3T4CC3SS";
                Session["idusuario"] = dt.Rows[0]["idusuario"].ToString();
                Session["usuario"] = dt.Rows[0]["usuario"].ToString();
                Session["email"] = dt.Rows[0]["email"].ToString();
                Session["perfil"] = dt.Rows[0]["perfil"].ToString();
                return RedirectToAction("Index", "Reserva");
            }
            else
            {
                ViewBag.Msg = "Usuario y/o clave incorrecta!";
                ViewBag.Display = "block";
                return View();
            }
        }
    }
}