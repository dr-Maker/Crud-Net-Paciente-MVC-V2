﻿

using Buss;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers
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

            if (!Session["login"].ToString().Equals("N3T4CC3SS"))
            {
                return RedirectToAction("Index", "Usuario");
            }

            ViewBag.Medicos = BussMedico.Listar02();
            ViewBag.Especialidades = BussEspecialidad.Listar02();

            ViewBag.Params = new ParamsHora();
            List<HorasDisponiblesModel> lista = BussReserva.HorasDisponibles(ViewBag.Params);
            return View(lista);
        }


        [HttpPost]
        public ActionResult HorasDisponibles(FormCollection frm)
        {
            if (!Session["login"].ToString().Equals("N3T4CC3SS"))
            {
                return RedirectToAction("Index", "Usuario");
            }

            ViewBag.Medicos = BussMedico.Listar02();
            ViewBag.Especialidades = BussEspecialidad.Listar02();

            ViewBag.Params = new ParamsHora();

            if (!frm["fecha"].ToString().Equals(""))
            { 
            ViewBag.Params.fecha = DateTime.Parse(frm["fecha"].ToString());
            }
            ViewBag.Params.idmedico = int.Parse(frm["idmedico"].ToString());
            ViewBag.Params.idespecialidad = int.Parse(frm["idespecialidad"].ToString());

            List<HorasDisponiblesModel> lista = BussReserva.HorasDisponibles(ViewBag.Params);
            return View(lista);
        }

        [HttpGet]
        public ActionResult TomarHora(int id)
        {
            HoraModel obj = BussHora.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult TomarHora(FormCollection frm)
        {
            int idpac = int.Parse(Session["idusuario"].ToString());
            ReservaModel obj = new ReservaModel();
            

            obj.Medico = new MedicoModel();
            obj.Medico.Idmedico = int.Parse(frm["idmedico"].ToString());  ;

            obj.Paciente = new PacienteModel();
            obj.Paciente.Idpaciente = idpac;

            obj.Hora = new HoraModel();
            obj.Hora.Idhora = int.Parse(frm["idhora"].ToString());

            BussReserva.TomarHora(obj);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AnularReserva(int id)
        {

            MisReservasModel obj = BussReserva.Buscar(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult AnularReserva(int id, FormCollection frm)
        {
            BussReserva.AnularReserva(id);
            return RedirectToAction("Index");
        }


    }
}