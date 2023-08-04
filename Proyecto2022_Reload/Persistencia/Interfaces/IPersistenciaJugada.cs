using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaces
{
    public interface IPersistenciaJugada
    {
        void AltaJugada(EntidadesCompartidas.Jugada pJugada);

        List<EntidadesCompartidas.Jugada> ListadeJugadas();
    }
}
