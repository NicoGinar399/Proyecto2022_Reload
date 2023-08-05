using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static Interfaces.ILogicaAdministrador GetAdministrador()
        {
            return Clases.LogicaAdministrador.GetInstance();
        }
        public static Interfaces.ILogicaCategoriaPregunta GetCategoriaPregunta()
        {
            return Clases.LogicaCategoriaPregunta.GetInstance();
        }
        public static Interfaces.ILogicaJuego GetJuego()
        {
            return Clases.LogicaJuego.GetInstance();
        }
        public static Interfaces.ILogicaJugada GetJugada()
        {
            return Clases.LogicaJugada.GetInstance();
        }
        public static Interfaces.ILogicaPregunta GetPregunta()
        {
            return Clases.LogicaPregunta.GetInstance();
        }
    }
}
