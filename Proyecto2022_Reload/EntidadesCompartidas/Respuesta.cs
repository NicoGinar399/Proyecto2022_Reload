using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Respuesta
    {
        private String _codigoPregunta;
        private String _texto;
        private bool _correcta;

        public string CodigoPregunta
        {
            get { return _codigoPregunta; }
            set
            {
                //if(value > 0)
                _codigoPregunta = value;
                //else
                //    throw new Exception("El codigo Respuesta tiene que ser mayor a 0");
            }
        }

        public string Texto
        {
            get { return _texto; }
            set
            {
                if (value.Length > 0)
                    _texto = value;
                else
                    throw new Exception("El texto no puede ser vacio");
            }
        }
        public bool Correcta
        {
            get { return _correcta; }
            set { _correcta = value; }
        }

        public Respuesta(string pTexto, bool pCorrecta)
        {
            Texto = pTexto;
            Correcta = pCorrecta;
        }
    }
}
