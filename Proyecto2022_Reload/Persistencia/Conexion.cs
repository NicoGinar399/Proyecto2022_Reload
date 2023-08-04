using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        internal static string Cnn(EntidadesCompartidas.Administrador pAdmin = null)
        {
            if (pAdmin == null)
                return "Data Source=DESKTOP-BSGB4GC\\SQLEXPRESS; Initial Catalog = ProyectoFinalSegundo2022; Integrated Security = true";
            else
                return "Data Source=DESKTOP-BSGB4GC\\SQLEXPRESS; Initial Catalog = ProyectoFinalSegundo2022; User=" + pAdmin.UsuarioLogueo + "; Password='" + pAdmin.Contrasenia + "'";
        }
        private static string _cnn = "Data Source=DESKTOP-BSGB4GC\\SQLEXPRESS; Initial Catalog = ProyectoFinalSegundo2022; Integrated Security = true";
        internal static string CnnLogin
        {
            get { return _cnn; }
        }
    }
}
