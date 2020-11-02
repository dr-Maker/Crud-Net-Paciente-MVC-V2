using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class UsuarioModel
    {
        private int idusuario;
        private string usuario;
        private string clave;
        private string email;
        private int perfil;

        private bool std;

        public UsuarioModel()
        {
        }

        public int Idusuario { get => idusuario; set => idusuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Email { get => email; set => email = value; }
        public int Perfil { get => perfil; set => perfil = value; }

        public bool Std { get => std; set => std = value; }

    }
}