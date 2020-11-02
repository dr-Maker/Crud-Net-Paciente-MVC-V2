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
    public class BussEstado
    {
        static BaseDatos db = new BaseDatos();
        public static DataTable Listar()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_estado";
            return db.ejecutarConsulta(cmd);
        }

        public static List<EstadoModel> Listar02()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_listar_estado";
            DataTable dt = db.ejecutarConsulta(cmd);
            List<EstadoModel> lista = new List<EstadoModel>();
            EstadoModel obj;
            foreach (DataRow row in dt.Rows)
            {
                obj = new EstadoModel();
                obj.Idestado = int.Parse(row["idestado"].ToString());
                obj.Descripcion = row["descripcion"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static EstadoModel Buscar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_buscar_estado";
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = id;
            DataTable dt = db.ejecutarConsulta(cmd);
            EstadoModel obj = new EstadoModel();
            if (dt != null && dt.Rows.Count > 0)
            {
                obj.Idestado = int.Parse(dt.Rows[0]["idestado"].ToString());
                obj.Descripcion = dt.Rows[0]["descripcion"].ToString();
            }
            return obj;
        }

        public static bool Insert(EstadoModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert_estado";
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = obj.Idestado;
            cmd.Parameters.Add("@descripcion", SqlDbType.Int).Value = obj.Descripcion;
            return db.ejecutarAccion(cmd);
        }

        public static bool Update(EstadoModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_update_estado";
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = obj.Idestado;
            cmd.Parameters.Add("@descripcion", SqlDbType.Int).Value = obj.Descripcion;
            return db.ejecutarAccion(cmd);
        }

        public static bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_delete_estado";
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = id;
            return db.ejecutarAccion(cmd);
        }
    }
}

