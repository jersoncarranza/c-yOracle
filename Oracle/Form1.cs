using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace Oracle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           dtgv.DataSource = Ejecutar.Listar();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.codigo = txtCodigo.Text;
            cli.nombre = txtNombre.Text;
            cli.edad = txtEdad.Text;
            Ejecutar.Guardar(cli);

            /*
            OracleConnection ora = new OracleConnection("USER ID = virginia; PASSWORD=123; unicode= true");
            ora.Open();
            MessageBox.Show("CONECTADO");
            ora.Close();
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = Ejecutar.Listar();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            Ejecutar.ElimnarP(txtEliminar.Text);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();
            cli.codigo = txtCodigo.Text;
            cli.nombre = txtNombre.Text;
            cli.edad = txtEdad.Text;
            Ejecutar.Actualizar(cli);
        }
    }
}
