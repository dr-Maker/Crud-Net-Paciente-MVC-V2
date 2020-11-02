

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
    public class ReservaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            int id = int.Parse(Session["idusuario"].ToString());
            List<MisReservasModel> lista = BussReserva.MisReservas(id);
            return View(lista);
        }

        [HttpGet]
        public ActionResult HorasDisponibles()
        {
            List<HorasDisponiblesModel> lista = BussReserva.HorasDisponibles();
            return View(lista);
        }

        [HttpGet]
        public ActionResult TomarHora(int idhora, int idmed)
        {
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AnularReserva(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AnularReserva(int id, FormCollection frm)
        {
            return RedirectToAction("Index");
        }

    }
}