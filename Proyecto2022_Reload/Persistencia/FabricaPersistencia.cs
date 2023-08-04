using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static Interfaces.IPersistenciaAdministrador getPAdministrador()
        {
            return Clases.PersistenciaAdministrador.GetInstance();
        }
        public static Interfaces.IPersistenciaCategoriaPreguntas getPCategoriaPreguntas()
        {
            return Clases.PersistenciaCategoriaPregunta.GetInstance();
        }
        public static Interfaces.IPersistenciaJuego GetPJuego()
        {
            return Clases.PersistenciaJuego.GetInstance();
        }
        public static Interfaces.IPersistenciaJugada getPJugada()
        {
            return Clases.PersistenciaJugada.GetInstance();
        }
        public static Interfaces.IPersistenciaPregunta getPPregunta()
        {
            return Clases.PersistenciaPregunta.GetInstance();
        }
    }
}
