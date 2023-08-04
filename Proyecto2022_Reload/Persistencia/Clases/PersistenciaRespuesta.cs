using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Persistencia.Clases
{
    internal class PersistenciaRespuesta
    {
        //singleton
        private static PersistenciaRespuesta _instancia;
        private PersistenciaRespuesta() { }
        public static PersistenciaRespuesta GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaRespuesta();

            return _instancia;
        }

        internal void Alta(EntidadesCompartidas.Respuesta pRespuesta, string pCodigoPregunta, SqlTransaction _pTransaccion)
        {
            int verdadero;
            if (pRespuesta.Correcta == true)
                verdadero = 0;
            else
                verdadero = 1;
            SqlCommand _comando = new SqlCommand("AltaRespuesta", _pTransaccion.Connection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoPregunta", pCodigoPregunta);
            _comando.Parameters.AddWithValue("@Texto", pRespuesta.Texto);
            _comando.Parameters.AddWithValue("@Correcta", verdadero);
            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                //determino que debo trabajar con la misma transaccion
                _comando.Transaction = _pTransaccion;
                //ejecuto comando
                _comando.ExecuteNonQuery();
                //verifico si hay errores
                int retorno = Convert.ToInt32(_ParmRetorno.Value);
                if (retorno == -1)
                    throw new Exception("error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//fin alta

        internal List<EntidadesCompartidas.Respuesta> ListarRespuestas(string pCodigoPregunta)
        {
            List<EntidadesCompartidas.Respuesta> _lista = new List<EntidadesCompartidas.Respuesta>();

            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);

            SqlCommand _comando = new SqlCommand("ListarRespuestas", _cnn);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@CodigoPregunta", pCodigoPregunta);

            try
            {
                //me conecto
                _cnn.Open();
                //ejecuto consulta
                SqlDataReader _lector = _comando.ExecuteReader();
                //verifico si hay telefonos
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _lista.Add(new EntidadesCompartidas.Respuesta((string)_lector["Texto"], (bool)_lector["Correcta"]));
                    }
                }

                _lector.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _cnn.Close();
            }

            return _lista;
        }
    }
}

