using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class HorasDisponiblesModel
    {

        public int idhora { get; set; }

        public DateTime fecha { get; set; }

        public TimeSpan horaminuto { get; set; }

        public int idmedico { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string email { get; set; }

        public int telefono { get; set; }

        public int idespecialidad { get; set; }

        public string nom_especialidad { get; set; }

        public int idestado { get; set; }

        public string nom_estado { get; set; }


        public string NomApeMedico
        {
            get
            {
                return nombres + " " + apellidos;
            }
        }

        public string ApeNomMedico
        {
            get
            {
                return apellidos + " " + nombres;
            }
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

        public string HoraminutoTxt
        {
            get
            {
                string hora = right(horaminuto.Hours.ToString(), 2);
                string minuto = right(horaminuto.Minutes.ToString(), 2);
                return hora + ":" + minuto;
            }
        }

        public string right(string cadena, int largo)
        {
            cadena = "0000000000" + cadena;
            return cadena.Substring(cadena.Length - largo);
        }
    }
}