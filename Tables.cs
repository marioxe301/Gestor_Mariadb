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
    public partial class Tables : Form
    {
        Fun_Proyecto funct;
        List<object> parametros;
        List<string> nombres;
        DataTable dt;
        public Tables(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = fun;
            Fun_Proyecto.LlenarTipoDato(comboBox1);
            dt = new DataTable();
            parametros = new List<object>();
            nombres = new List<string>();
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Parametro", typeof(string)));
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
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
            else if (treeView1.SelectedNode.Parent.Text == "Funciones")
            {
                Fun_Proyecto.Funciones = treeView1.SelectedNode.Text;
                MessageBox.Show("Funcion seleccionada: " + Fun_Proyecto.Funciones);


            }
            else if (treeView1.SelectedNode.Parent.Text == "Tablas")
            {
                Fun_Proyecto.Tabla = treeView1.SelectedNode.Text;
                MessageBox.Show("Tabla seleccionada: " + Fun_Proyecto.Tabla);


            }
            else if (treeView1.SelectedNode.Parent.Text == "Triggers")
            {
                Fun_Proyecto.Trigger = treeView1.SelectedNode.Text;
                MessageBox.Show("Trigger seleccionado: " + Fun_Proyecto.Trigger);


            }
            else if (treeView1.SelectedNode.Parent.Text == "Vistas")
            {
                Fun_Proyecto.Vista = treeView1.SelectedNode.Text;
                MessageBox.Show("Vista seleccionada: " + Fun_Proyecto.Vista);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "INT":
                    parametros.Add(1);
                    nombres.Add(textBox3.Text);
                    dt.Rows.Add(textBox3.Text, comboBox1.Text);
                    break;
                case "TEXT":
                    StringBuilder st = new StringBuilder("hola");
                    parametros.Add(st);
                    nombres.Add(textBox3.Text);
                    dt.Rows.Add(textBox3.Text, comboBox1.Text);
                    break;
                case "BOOL":
                    parametros.Add(true);
                    nombres.Add(textBox3.Text);
                    dt.Rows.Add(textBox3.Text, comboBox1.Text);
                    break;
                case "DOUBLE":
                    parametros.Add(1.567);
                    nombres.Add(textBox3.Text);
                    dt.Rows.Add(textBox3.Text, comboBox1.Text);
                    break;
                case "VARCHAR":
                    parametros.Add("hola");
                    nombres.Add(textBox3.Text);
                    dt.Rows.Add(textBox3.Text, comboBox1.Text);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Fun_Proyecto.BorrarTablas(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Tabla);
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            Fun_Proyecto.CrearTabla(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, textBox2.Text, Fun_Proyecto.Esquema, parametros, nombres);
            textBox2.Text = "";
            textBox3.Text = "";
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.ListarColumnasDT(Fun_Proyecto.Usuario,Fun_Proyecto.Contraseña,Fun_Proyecto.Esquema,Fun_Proyecto.Tabla,dataGridView2);
        }

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void esquemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esquemas esl = new Esquemas(funct);
            this.Hide();
            esl.Show();
        }

        private void funcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones fn = new Funciones(funct);
            this.Hide();
            fn.Show();
        }

        private void procedimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procedimientos pr = new Procedimientos(funct);
            this.Hide();
            pr.Show();

        }

        private void vistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vistas vst = new Vistas(funct);
            this.Hide();
            vst.Show();
        }

        private void indicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indices ind = new Indices(funct);
            this.Hide();
            ind.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Triggers tr = new Triggers(funct);
            this.Hide();
            tr.Show();
        }

        private void dDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodosDDL dll = new TodosDDL(funct);
            this.Hide();
            dll.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainFrame mn = new MainFrame(funct);
            this.Hide();
            mn.Show();
        }
    }
}
