using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;         

namespace pryFranco_Base_de_Datos
{
    public partial class Form1 : Form
    {
        OleDbConnection miConexionBD;
        OleDbCommand miComandoBD;
        OleDbDataReader miLectorBD;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            
            try
            {
                miConexionBD = new OleDbConnection();
                miConexionBD.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=VERDULEROS.mdb";
                miConexionBD.Open();

                btnConectar.Text = "conexion establecida";
                btnConectar.BackColor = Color.Green;
            }
            catch (Exception ex)
            {
                btnConectar.Text = "Error";
                label1.Visible = true;
                label1.Text = ex.Message;
                btnConectar.BackColor = Color.Red;

                //throw;
            }

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                miComandoBD = new OleDbCommand();

                miComandoBD.Connection = miConexionBD;
                miComandoBD.CommandType = CommandType.TableDirect;
                miComandoBD.CommandText = "productos";

                btnMostrar.Text = "Tabla obtenida";
                btnMostrar.BackColor = Color.Green;

                miLectorBD = miComandoBD.ExecuteReader();

                while (miLectorBD.Read())
                {
                    decimal precio = decimal.Parse(miLectorBD[3].ToString());
                    if (precio > decimal.Parse(txtPrecio.Text))
                    {
                        dgv.Rows.Add(miLectorBD[0], miLectorBD[1], miLectorBD[2], miLectorBD[3]);
                    }
                       
                }

            }
            catch (Exception ex)
            {
                btnMostrar.Text = "Error";
                label1.Visible = true;
                label1.Text = ex.Message;
                btnMostrar.BackColor = Color.Red;

                
            }
        }
    }
}
