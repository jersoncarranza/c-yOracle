using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

namespace Oracle
{
    public class Metodo
    {
        public static OracleCommand CrearProcedimiento(string proc)
        {
            OracleConnection n = new OracleConnection(conexion.CadenaString);
            OracleCommand m = new OracleCommand(proc,n);

            m.CommandType = CommandType.StoredProcedure;
            return m;

        }

       public static Boolean EjecutarProcedimiento(OracleCommand com)
        {
            Console.WriteLine(com);
            com.Connection.Open();
            if (com.ExecuteNonQuery()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            com.Connection.Dispose();
            com.Connection.Close();
        }

        public static DataSet SelectProcedimiento(OracleCommand com)
        {
            DataSet tabla = new DataSet();
            try
            {
                com.Connection.Open();
                OracleDataAdapter ada = new OracleDataAdapter(com);
                ada.SelectCommand = com;
                ada.Fill(tabla);
            }
            catch (Exception)
            {

                com.Connection.Close();
            }
           
            return tabla;
        }
    }
}
