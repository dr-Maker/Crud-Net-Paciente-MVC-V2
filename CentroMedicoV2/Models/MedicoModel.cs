using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class MedicoModel
    {
        private int idmedico;
        private string nombres;
        private string apellidos;
        private string email;
        private int telefono;
        private EspecialidadModel especialidad;

        public MedicoModel()
        {
        }

        public MedicoModel(
            int idmedico, 
            string nombres, 
            string apellidos, 
            string email, 
            int telefono, 
            EspecialidadModel especialidad)
        {
            this.idmedico = idmedico;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.email = email;
            this.telefono = telefono;
            this.especialidad = especialidad;
        }

        public int Idmedico { get => idmedico; set => idmedico = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Email { get => email; set => email = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public EspecialidadModel Especialidad { get => especialidad; set => especialidad = value; }


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

        public string NomEspecialidad
        {
            get
            {
                return especialidad.Descripcion;
            }
        }
    }
}