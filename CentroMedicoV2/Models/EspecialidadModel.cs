using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class EspecialidadModel
    {
        private int idespecialidad;
        private string descripcion;

        public EspecialidadModel()
        {
        }

        public EspecialidadModel(int idespecialidad, string descripcion)
        {
            this.idespecialidad = idespecialidad;
            this.descripcion = descripcion;
        }

        public int Idespecialidad { get => idespecialidad; set => idespecialidad = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}