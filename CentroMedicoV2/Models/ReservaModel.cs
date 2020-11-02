using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ReservaModel
    {
        private int idreserva;
        private MedicoModel medico;
        private PacienteModel paciente;
        private HoraModel hora;

        public ReservaModel()
        {
        }

        public ReservaModel(
            int idreserva, 
            MedicoModel medico, 
            PacienteModel paciente, 
            HoraModel hora)
        {
            this.idreserva = idreserva;
            this.medico = medico;
            this.paciente = paciente;
            this.hora = hora;
        }

        public int Idreserva { get => idreserva; set => idreserva = value; }
        public MedicoModel Medico { get => medico; set => medico = value; }
        public PacienteModel Paciente { get => paciente; set => paciente = value; }
        public HoraModel Hora { get => hora; set => hora = value; }
    }
}