using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ParamsHora
    {

        public DateTime fecha { get; set; }
        public int  idmedico { get; set; }
        public int idespecialidad { get; set; }

        public ParamsHora()
        {
            fecha = DateTime.Parse("1-1-1");
            idmedico = 0;
            idespecialidad = 0;
        }


        public string FechaTxt
        {
            get
            {
                if (fecha != null)
                {
                    string dia = right(fecha.Day.ToString(), 2);
                    string mes = right(fecha.Month.ToString(), 2);
                    string anno = right(fecha.Year.ToString(), 4);
                    return dia + "-" + mes + "-" + anno;
                }
                else
                {
                    return "-";
                }
            }
        }


        public string right(string cadena, int largo)
        {
            cadena = "0000000000" + cadena;
            return cadena.Substring(cadena.Length - largo);
        }
    }
}