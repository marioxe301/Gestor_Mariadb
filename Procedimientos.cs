using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_TB2
{
    public partial class Procedimientos : Form
    {
        Fun_Proyecto funct;
        List<object> parametros;
        List<string> nombres;
        DataTable dt;
        public Procedimientos(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = fun;
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
            Fun_Proyecto.LlenarTipoDato(comboBox1);
            dt = new DataTable();
            parametros = new List<object>();
            nombres = new List<string>();
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Parametro", typeof(string)));

            dataGridView1.DataSource = dt;
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (treeView1.SelectedNode.Parent == null)
            {
                Fun_Proyecto.Esquema = treeView1.SelectedNode.Text;
                MessageBox.Show("Esquema seleccionado: " + Fun_Proyecto.Esquema);
                
            }
           else if (treeView1.SelectedNode.Parent.Text == "Procedimientos")
            {
                Fun_Proyecto.Procedimiento = treeView1.SelectedNode.Text;
                MessageBox.Show("Procedimiento seleccionado: " + Fun_Proyecto.Procedimiento);
                

            }
             else if (treeView1.SelectedNode.Parent.Text=="Funciones")
            {
                Fun_Proyecto.Funciones = treeView1.SelectedNode.Text;
                MessageBox.Show("Funcion seleccionada: " + Fun_Proyecto.Funciones);
                

            }
            else if (treeView1.SelectedNode.Parent.Text== "Tablas")
            {
                Fun_Proyecto.Tabla = treeView1.SelectedNode.Text;
                MessageBox.Show("Tabla seleccionada: " + Fun_Proyecto.Tabla);
               

            }
             else if (treeView1.SelectedNode.Parent.Text == "Triggers")
            {
                Fun_Proyecto.Trigger = treeView1.SelectedNode.Text;
                MessageBox.Show("Trigger seleccionado: " + Fun_Proyecto.Trigger);
                

            }
           else if(treeView1.SelectedNode.Parent.Text == "Vistas")
            {
                Fun_Proyecto.Vista = treeView1.SelectedNode.Text;
                MessageBox.Show("Vista seleccionada: " + Fun_Proyecto.Vista);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.AgregarProcedimientos(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, parametros, nombres, textBox1.Text, richTextBox1.Text);
            dt.Rows.Clear();
            parametros.Clear();
            nombres.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "INT":
                    parametros.Add(1);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox1.Text);
                    break;
                case "TEXT":
                    StringBuilder st = new StringBuilder("hola");
                    parametros.Add(st);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox1.Text);
                    break;
                case "BOOL":
                    parametros.Add(true);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox1.Text);
                    break;
                case "DOUBLE":
                    parametros.Add(1.567);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox1.Text);
                    break;
                case "VARCHAR":
                    parametros.Add("hola");
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox1.Text);
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.BorrarProcedimientos(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Procedimiento);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLProcedimientos(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Procedimiento);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.BorrarProcedimientos(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Procedimiento);
            Fun_Proyecto.EjecutarQuery(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, richTextBox1.Text);
            richTextBox1.Text = "";

        }
    }
}
