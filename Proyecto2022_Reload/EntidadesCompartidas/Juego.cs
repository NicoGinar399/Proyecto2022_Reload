using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Juego
    {
        private int _codigoJuego;
        private DateTime _fecha;
        private string _dificultad;
        private Administrador _administrador;

        public int CodigoJuego
        {
            get { return _codigoJuego; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                if (value != null)
                    _fecha = value;
                else
                    throw new Exception("la fecha no puede ser vacio");
            }
        }
        public string Dificultad
        {
            get { return _dificultad; }
            set
            {
                if (value == "facil" || value == "medio" || value == "dificil")
                    _dificultad = value;
                else
                    throw new Exception("las opciones son facil, medio o dificil");
            }
        }
        public Administrador Administrador
        {
            get { return _administrador; }
            set { _administrador = value; }
        }
        public string usuLogueo
        {
            get { return Administrador.UsuarioLogueo; }
        }

        public Juego(int pCodigoJuego, DateTime pFecha, string pDificultad, Administrador pAdministrador)
        {
            _codigoJuego = pCodigoJuego;
            Fecha = pFecha;
            Dificultad = pDificultad;
            Administrador = pAdministrador;
        }
    }
}
