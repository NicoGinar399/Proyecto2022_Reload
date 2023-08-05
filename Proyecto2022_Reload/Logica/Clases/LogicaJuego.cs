using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    internal class LogicaJuego: Interfaces.ILogicaJuego
    {
        //singleton
        private static LogicaJuego _instancia;
        private LogicaJuego() { }
        public static LogicaJuego GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaJuego();
            return _instancia;
        }

        public void AltaJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.GetPJuego().AltaJuego(pJuego, pLogueo);
        }
        public void BajaJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.GetPJuego().BajaJuego(pJuego, pLogueo);
        }
        public void ModificarJuego(EntidadesCompartidas.Juego pJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            Persistencia.FabricaPersistencia.GetPJuego().ModificarJuego(pJuego, pLogueo);
        }
        public EntidadesCompartidas.Juego BuscarJuego(int pCodigoJuego, EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.GetPJuego().BuscarJuego(pCodigoJuego, pLogueo));
        }
        public List<EntidadesCompartidas.Juego> ListadeJuegosConPreguntas()
        {
            return (Persistencia.FabricaPersistencia.GetPJuego().ListadeJuegosConPreguntas());
        }
        public List<EntidadesCompartidas.Juego> ListadoDeJuegosVacios(EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.GetPJuego().ListadoDeJuegosVacios(pLogueo));
        }
        public List<EntidadesCompartidas.Juego> ListadoDeJuegosNuncaUsados(EntidadesCompartidas.Administrador pLogueo)
        {
            return (Persistencia.FabricaPersistencia.GetPJuego().ListadoDeJuegosNuncaUsados(pLogueo));
        }
    }
}
