using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.OracleClient;
using System.Data;

namespace Oracle
{
    public class Ejecutar
    {

        public static Boolean Guardar(Cliente cli)
        {
            Console.WriteLine(cli);
            OracleCommand com = Metodo.CrearProcedimiento("Virginia.insertarCliente");
            com.Parameters.Add("codigo", OracleType.VarChar).Value = cli.codigo;
            com.Parameters.Add("nombre", OracleType.VarChar).Value = cli.nombre;
            com.Parameters.Add("edad", OracleType.VarChar).Value = cli.edad;
            Console.WriteLine(cli);
            return Metodo.EjecutarProcedimiento(com);
        }

        public static DataSet Listar()
        {
            DataSet tabla = new DataSet();
            string cConexion1 = "USER ID=virginia; Password=123; unicode=true";
            string cmdtex = "SELECT * from CLIENTE";

            OracleConnection conn = new OracleConnection(cConexion1);
            OracleCommand cmd = new OracleCommand(cmdtex, conn);
            conn.Open();

            OracleDataAdapter ada = new OracleDataAdapter(cmd);
            ada.SelectCommand = cmd;
            ada.Fill(tabla);

            return tabla;
            conn.Dispose();
            conn.Close();
        }

        
        public static Boolean ElimnarP(string cod)
        {
            string cConexion1 = "USER ID=virginia; Password=123; unicode=true";
            string cmdtex = "Delete from CLIENTE where CODIGO= :ID";

            OracleConnection conn = new OracleConnection(cConexion1);
            OracleCommand cmd = new OracleCommand(cmdtex, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("ID", cod);
      

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            conn.Dispose();
            conn.Close();
        }

        public static Boolean Actualizar(Cliente cli)
        {
            string cConexion1 = "USER ID=virginia; Password=123; unicode=true";
            string cmdtex = "UPDATE CLIENTE SET Nombre = :N, Edad= :E WHERE Codigo = :C";

            OracleConnection conn = new OracleConnection(cConexion1);
            OracleCommand cmd = new OracleCommand(cmdtex, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("N", cli.nombre);
            cmd.Parameters.AddWithValue("E", cli.edad);
            cmd.Parameters.AddWithValue("C", cli.codigo);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            conn.Dispose();
            conn.Close();
        }
    }
}
