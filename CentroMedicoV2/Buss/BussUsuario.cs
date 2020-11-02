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

    public class BussUsuario
    {
        static BaseDatos db = new BaseDatos();

        public static DataTable ValidarUsuario(UsuarioModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_valida_usuario";
            cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = obj.Clave;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = obj.Usuario;
            return db.ejecutarConsulta(cmd);
        }

        public static DataTable ValidarPaciente(UsuarioModel obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_valida_paciente";
            cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = obj.Clave;
            cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = obj.Usuario;
            return db.ejecutarConsulta(cmd);
        }

    }
}