using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Buss
{
    public class BussReserva
    {
        static BaseDatos db = new BaseDatos();

        public static DataTable Listar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_reserva";
            return db.ejecutarConsulta(cmd);
        }


        public static List<MisReservasModel> MisReservas(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_mis_reservas";
            cmd.Parameters.Add("@idpaciente", SqlDbType.Int).Value = id;

            DataTable dt = db.ejecutarConsulta(cmd);

            List<MisReservasModel> lista = new List<MisReservasModel>();

            MisReservasModel obj;

            foreach (DataRow row in dt.Rows)
            {
                obj = new MisReservasModel();

                obj.idreserva = int.Parse(row["idreserva"].ToString());
                obj.fecha = DateTime.Parse(row["fecha"].ToString());
                obj.horaminuto = TimeSpan.Parse(row["horaminuto"].ToString());
                obj.nombres_me = row["nombres_me"].ToString();
                obj.apellidos_me = row["apellidos_me"].ToString();
                obj.nom_especialidad = row["nom_especialidad"].ToString();

                obj.nombres_pa = row["nombres_pa"].ToString();
                obj.apellidos_pa = row["apellidos_pa"].ToString();
                lista.Add(obj);
            }

            return lista;
        }


        public static MisReservasModel Buscar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_buscar_reserva";
            cmd.Parameters.Add("@idreserva", SqlDbType.Int).Value = id;
            DataTable dt = db.ejecutarConsulta(cmd);

            MisReservasModel obj = new MisReservasModel();

            foreach (DataRow row in dt.Rows)
            {
             
                obj.idreserva = int.Parse(row["idreserva"].ToString());
                obj.fecha = DateTime.Parse(row["fecha"].ToString());
                obj.horaminuto = TimeSpan.Parse(row["horaminuto"].ToString());
                obj.nombres_me = row["nombres_me"].ToString();
                obj.apellidos_me = row["apellidos_me"].ToString();
                obj.nom_especialidad = row["nom_especialidad"].ToString();

                obj.nombres_pa = row["nombres_pa"].ToString();
                obj.apellidos_pa = row["apellidos_pa"].ToString();              
            }

            return obj;
        }

        public static List<HorasDisponiblesModel> HorasDisponibles(ParamsHora par)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_hora_filtro";
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = par.fecha;
            cmd.Parameters.Add("@idmedico", SqlDbType.Int).Value = par.idmedico;
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int).Value = par.idespecialidad;
            DataTable dt = db.ejecutarConsulta(cmd);

            List<HorasDisponiblesModel> lista = new List<HorasDisponiblesModel>();

            HorasDisponiblesModel obj;

            foreach (DataRow row in dt.Rows)
            {
                obj = new HorasDisponiblesModel();
                obj.idhora = int.Parse(row["idhora"].ToString());
                obj.fecha = DateTime.Parse(row["fecha"].ToString());
                obj.horaminuto = TimeSpan.Parse(row["horaminuto"].ToString());
                obj.idmedico = int.Parse(row["idmedico"].ToString());
               

                obj.nombres = row["nombres"].ToString();
                obj.apellidos = row["apellidos"].ToString();
                obj.email = row["email"].ToString();

                obj.idespecialidad = int.Parse(row["idespecialidad"].ToString());
                obj.nom_especialidad = row["nom_especialidad"].ToString();


                lista.Add(obj);
            }

            return lista;
        }

        public static bool TomarHora(ReservaModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_hora_reserva";
            cmd.Parameters.Add("@idmedico", SqlDbType.Int).Value = obj.Medico.Idmedico;
            cmd.Parameters.Add("@idpaciente", SqlDbType.Int).Value = obj.Paciente.Idpaciente;
            cmd.Parameters.Add("@idhora", SqlDbType.Int).Value = obj.Hora.Idhora;

            return db.ejecutarAccion(cmd);

        }

        public static bool AnularReserva(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_anular_reserva";
            cmd.Parameters.Add("@idreserva", SqlDbType.Int).Value = id;
     
            return db.ejecutarAccion(cmd);
        }
    }
}