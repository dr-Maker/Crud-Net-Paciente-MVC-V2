using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class PacienteModel
    {
        private int idpaciente;
        private string nombres;
        private string apellidos;
        private string email;
        private int telefono;
        private char genero;
        private int edad;

        public PacienteModel()
        {
        }

        public PacienteModel(
            int idpaciente,
            string nombres,
            string apellidos,
            string email,
            int telefono,
            char genero,
            int edad)
        {
            this.idpaciente = idpaciente;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.email = email;
            this.telefono = telefono;
            this.genero = genero;
            this.edad = edad;
        }

        public int Idpaciente { get => idpaciente; set => idpaciente = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Email { get => email; set => email = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public char Genero { get => genero; set => genero = value; }
        public int Edad { get => edad; set => edad = value; }

        public string NomApePaciente
        {
            get
            {
                return nombres + " " + apellidos;
            }
        }

        public string ApeNomPaciente
        {
            get
            {
                return apellidos + " " + nombres;
            }
        }

        public string NomGenero
        {
            get
            {
                if (genero == 'F')
                {
                    return "Femenino";
                }
                else
                {
                    return "Masculino";
                }
            }
        }

    }
}