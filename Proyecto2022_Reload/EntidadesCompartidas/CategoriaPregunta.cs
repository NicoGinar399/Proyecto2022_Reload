using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class CategoriaPregunta
    {
        private string _codigoCategoria;
        private string _nombre;

        public string CodigoCategoria
        {
            get { return _codigoCategoria; }
            set
            {
                if (value.Length == 4 && value.All(char.IsLetter) == true)
                    _codigoCategoria = value;

                else
                    throw new Exception("La cantidad de caracteres deber ser 4 y contener");
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Length > 0 && value.Length <= 100)
                    _nombre = value;
                else
                    throw new Exception("La cantidad de caracteres deber ser mayor a 0 o menor igual a 100");
            }
        }

        public CategoriaPregunta(string pCodigoCategoria, string pNombre)
        {
            CodigoCategoria = pCodigoCategoria;
            Nombre = pNombre;
        }
    }
}
