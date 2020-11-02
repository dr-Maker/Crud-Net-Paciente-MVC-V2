using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class MisReservasModel
    {
        public int idreserva { get; set; }

        public int idhora { get; set; }

        public DateTime fecha { get; set; }

        public TimeSpan horaminuto { get; set; }

        public int idmedico { get; set; }

        public string nombres_me { get; set; }

        public string apellidos_me { get; set; }

        public string email_me { get; set; }

        public int telefono_me { get; set; }

        public int idespecialidad { get; set; }

        public string nom_especialidad { get; set; }

        public int idpaciente { get; set; }

        public string nombres_pa { get; set; }

        public string apellidos_pa { get; set; }

        public string email_pa { get; set; }

        public int telefono_pa { get; set; }

        public string genero { get; set; }

        public int edad { get; set; }

        public string NomApeMedico
        {
            get
            {
                return nombres_me + " " + apellidos_me; 
            }
        }

        public string ApeNomMedico
        {
            get
            {
                return apellidos_me + " " + nombres_me; 
            }
        }


        public string NomApePaciente
        {
            get
            {
                return nombres_pa + " " + apellidos_pa;
            }
        }

        public string ApeNomPaciente
        {
            get
            {
                return apellidos_pa + " " + nombres_pa;
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