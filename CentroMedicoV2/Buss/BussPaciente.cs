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
    public class BussPaciente
    {
        static BaseDatos db = new BaseDatos();
		
        public static DataTable Listar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_paciente";
            return db.ejecutarConsulta(cmd);
        }

        public static List<PacienteModel> Listar02()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_paciente";
            DataTable dt = db.ejecutarConsulta(cmd);
            List<PacienteModel> lista = new List<PacienteModel>();
            PacienteModel obj;
            foreach (DataRow row in dt.Rows)
            {
                obj = new PacienteModel();
                obj.Idpaciente = int.Parse(row["idpaciente"].ToString());
                obj.Nombres = row["nombres"].ToString();
                obj.Apellidos = row["apellidos"].ToString();
                obj.Email = row["email"].ToString();
                obj.Telefono = int.Parse(row["telefono"].ToString());
                obj.Genero = char.Parse(row["genero"].ToString());
                obj.Edad = int.Parse(row["edad"].ToString());
                lista.Add(obj);
            }
            return lista;
        }

        public static PacienteModel Buscar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_buscar_paciente";
            cmd.Parameters.Add("@idpaciente", SqlDbType.Int).Value = id;
            DataTable dt = db.ejecutarConsulta(cmd);
            PacienteModel obj = new PacienteModel();
            if (dt != null && dt.Rows.Count > 0)
            {
                obj.Idpaciente = int.Parse(dt.Rows[0]["idpaciente"].ToString());
                obj.Nombres = dt.Rows[0]["nombres"].ToString();
                obj.Apellidos = dt.Rows[0]["apellidos"].ToString();
                obj.Email = dt.Rows[0]["email"].ToString();
                obj.Telefono = int.Parse(dt.Rows[0]["telefono"].ToString());
                obj.Genero = char.Parse(dt.Rows[0]["genero"].ToString());
                obj.Edad = int.Parse(dt.Rows[0]["edad"].ToString());
            }
            return obj;
        }

        public static bool Insert(PacienteModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert_paciente";
            cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = obj.Nombres;
            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 50).Value = obj.Apellidos;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = obj.Email;
            cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = obj.Telefono;
            cmd.Parameters.Add("@genero", SqlDbType.Char, 1).Value = obj.Genero;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = obj.Edad;
            return db.ejecutarAccion(cmd);
        }

        public static bool Update(PacienteModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_update_paciente";
            cmd.Parameters.Add("@idpaciente", SqlDbType.Int).Value = obj.Idpaciente;
            cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value = obj.Nombres;
            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 50).Value = obj.Apellidos;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = obj.Email;
            cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = obj.Telefono;
            cmd.Parameters.Add("@genero", SqlDbType.Char, 1).Value = obj.Genero;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = obj.Edad;
            return db.ejecutarAccion(cmd);
        }

        public static bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_delete_paciente";
            cmd.Parameters.Add("@idpaciente", SqlDbType.Int).Value = id;
            return db.ejecutarAccion(cmd);
        }

    }
}