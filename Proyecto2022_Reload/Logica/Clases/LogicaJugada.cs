using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    internal class LogicaJugada: Interfaces.ILogicaJugada
    {
        //singleton
        private static LogicaJugada _instancia;
        private LogicaJugada() { }
        public static LogicaJugada GetInstance()
        {
            if (_instancia == null)
                _instancia = new LogicaJugada();
            return _instancia;
        }
        public void AltaJugada(EntidadesCompartidas.Jugada pJugada)
        {
            Persistencia.FabricaPersistencia.getPJugada().AltaJugada(pJugada);
        }
        public List<EntidadesCompartidas.Jugada> ListadeJugadas()
        {
            return (Persistencia.FabricaPersistencia.getPJugada().ListadeJugadas());
        }
    }
}
