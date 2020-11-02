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

        public static List<HorasDisponiblesModel> HorasDisponibles()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_hora_filtro";
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = 1;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = "1-1-1";
            cmd.Parameters.Add("@idmedico", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int).Value = 0;
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
    }
}