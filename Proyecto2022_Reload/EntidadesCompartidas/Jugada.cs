using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Jugada
    {
        //agregar controles y revisar si no falta un atributo mas
        private DateTime _fecha;
        private string _nombreJugador;
        private int _puntajeObtenido;
        private Juego _juego;

        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                if (value != null)
                    _fecha = value;
                else
                    throw new Exception("las opciones son facil, medio o dificil");
            }
        }
        public string NombreJugador
        {
            get { return _nombreJugador; }
            set
            {
                if (value.Length > 0 || value.Length <= 50)
                    _nombreJugador = value;
                else
                    throw new Exception("El nombre debe tener menos de 50 caracteres");
            }
        }
        public int PuntajeObtenido
        {
            get { return _puntajeObtenido; }
            set
            {
                if (value > 0)
                    _puntajeObtenido = value;
                else
                    throw new Exception("El puntaje tiene que ser positivo y mayor a 0");
            }
        }
        public Juego Juego
        {
            get { return _juego; }
            set { _juego = value; }
        }

        public Jugada(DateTime pFecha, string pNombreJugador, int pPuntajeObtenido, Juego pJuego)
        {
            Fecha = pFecha;
            NombreJugador = pNombreJugador;
            PuntajeObtenido = pPuntajeObtenido;
            Juego = pJuego;
        }
    }
}
