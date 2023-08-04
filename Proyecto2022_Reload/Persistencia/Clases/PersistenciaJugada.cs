using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Persistencia.Clases
{
    internal class PersistenciaJugada: Interfaces.IPersistenciaJugada
    {
        //singleton
        private static PersistenciaJugada _instancia;
        private PersistenciaJugada() { }
        public static PersistenciaJugada GetInstance()
        {
            if (_instancia == null)
                _instancia = new PersistenciaJugada();
            return _instancia;
        }
        public void AltaJugada(EntidadesCompartidas.Jugada pJugada)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin); //aca deberia pasar el usuario logueado

            //defino sp
            SqlCommand _comando;
            _comando = new SqlCommand("AltaJugada", _cnn);

            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@NombreJugador", pJugada.NombreJugador);
            _comando.Parameters.AddWithValue("@PuntajeObtenido", pJugada.PuntajeObtenido);
            _comando.Parameters.AddWithValue("@CodigoJuego", pJugada.Juego.CodigoJuego);


            SqlParameter _ParmRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _ParmRetorno.Direction = ParameterDirection.ReturnValue;
            _comando.Parameters.Add(_ParmRetorno);

            try
            {
                //conecto a la bd
                _cnn.Open();

                //ejecuto comando de creacion de usuario SQLserver
                _comando.ExecuteNonQuery();

                //verifico si hay errores
                int _codJugada = Convert.ToInt32(_ParmRetorno.Value);
                if (_codJugada == -1)
                    throw new Exception("Error numero 1");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }
        public List<EntidadesCompartidas.Jugada> ListadeJugadas()
        {
            SqlConnection _cnn = new SqlConnection(Conexion.CnnLogin);
            EntidadesCompartidas.Jugada _UnaJugada = null;
            List<EntidadesCompartidas.Jugada> _lista = new List<EntidadesCompartidas.Jugada>();

            SqlCommand _comando = new SqlCommand("ListadeJugadas", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    while (_lector.Read())
                    {
                        _UnaJugada = new EntidadesCompartidas.Jugada((DateTime)_lector["FechayHora"], (string)_lector["NombreJugador"], (int)_lector["PuntajeObtenido"], (EntidadesCompartidas.Juego)_lector["CodigoJuego"]);
                        _lista.Add(_UnaJugada);
                    }
                }
                _lector.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _lista;
        }
    }
}
