﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Interfaces
{
    public interface ILogicaJugada
    {
        void AltaJugada(EntidadesCompartidas.Jugada pJugada);
        List<EntidadesCompartidas.Jugada> ListadeJugadas();
    }
}
