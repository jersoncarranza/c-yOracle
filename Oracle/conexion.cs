using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace Oracle
{
    public class conexion
    {
        private static String cConexion="USER ID=virginia; Password=123; unicode=true";

        public static String CadenaString
        {
            get { return conexion.cConexion; }
        }
    }
}
