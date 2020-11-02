using Data;
using Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buss
{
    public class BussEspecialidad
    {
        static BaseDatos db = new BaseDatos();
        public static DataTable Listar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_especialidad";
            return db.ejecutarConsulta(cmd);
        }

        public static List<EspecialidadModel> Listar02()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_especialidad";
            DataTable dt = db.ejecutarConsulta(cmd);
            List<EspecialidadModel> lista = new List<EspecialidadModel>();
            EspecialidadModel obj;
            foreach (DataRow row in dt.Rows)
            {
                obj = new EspecialidadModel();
                obj.Idespecialidad = int.Parse(row["idespecialidad"].ToString());
                obj.Descripcion = row["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static EspecialidadModel Buscar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_buscar_especialidad";
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int).Value = id;
            DataTable dt = db.ejecutarConsulta(cmd);
            EspecialidadModel obj = new EspecialidadModel();
            if (dt != null && dt.Rows.Count > 0)
            {
                obj.Idespecialidad = int.Parse(dt.Rows[0]["idespecialidad"].ToString());
                obj.Descripcion = dt.Rows[0]["descripcion"].ToString();
            }
            return obj;
        }

        public static bool Insert(EspecialidadModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert_especialidad";
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int).Value = obj.Idespecialidad;
            cmd.Parameters.Add("@descripcion", SqlDbType.Int).Value = obj.Descripcion;
            return db.ejecutarAccion(cmd);
        }

        public static bool Update(EspecialidadModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_update_especialidad";
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int).Value = obj.Idespecialidad;
            cmd.Parameters.Add("@descripcion", SqlDbType.Int).Value = obj.Descripcion;
            return db.ejecutarAccion(cmd);
        }

        public static bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_delete_especialidad";
            cmd.Parameters.Add("@idespecialidad", SqlDbType.Int).Value = id;
            return db.ejecutarAccion(cmd);
        }
    }
}

