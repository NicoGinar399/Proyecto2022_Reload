using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
    public class Pregunta
    {
        private string _codigoPregunta;
        private int _puntaje;
        private string _texto;
        private List<Respuesta> _listaRespuesta;
        private CategoriaPregunta codigoCategoria;//_categoriaPregunta;

        public string CodigoPregunta
        {
            get { return _codigoPregunta; }
            set
            {
                _codigoPregunta = value;
            }
            //    if (value.Length <= 5 && value.All(char.IsLetter) == true)
            //        _codigoPregunta = value;
            //    else
            //        throw new Exception("El codigo pregunta deben ser solo letras y un total de 5");
            //}
        }
        public int Puntaje
        {
            get { return _puntaje; }
            set
            {
                if (value >= 1 || value <= 10)
                    _puntaje = value;
                else
                    throw new Exception("El valor del puntaje debe ser entre 1 y 10");
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
                    throw new Exception("El valor no puede ser vacio");
            }
        }
        public List<Respuesta> ListaRespuesta
        {
            get { return _listaRespuesta; }
            set { _listaRespuesta = value; }
        }
        public CategoriaPregunta CodigoCategoria
        {
            get { return codigoCategoria; }
            set { codigoCategoria = value; }
        }
        public string codCategoria
        {
            get { return CodigoCategoria.CodigoCategoria; }
        }
        public Pregunta(string pCodigoPregunta, int pPuntaje, string pTexto, List<Respuesta> pListaRespuesta, CategoriaPregunta pCategoriaPregunta)
        {
            CodigoPregunta = pCodigoPregunta;
            Puntaje = pPuntaje;
            Texto = pTexto;
            ListaRespuesta = pListaRespuesta;
            CodigoCategoria = pCategoriaPregunta;
        }
    }
}
