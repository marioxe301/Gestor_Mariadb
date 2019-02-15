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
    public partial class Triggers : Form
    {
        Fun_Proyecto funct;
        public Triggers(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = fun;
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
            BindData(comboBox2, comboBox1);

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

        void BindData(ComboBox c1,ComboBox c2)
        {
            c1.Items.Add("BEFORE");
            c1.Items.Add("AFTER");
            c2.Items.Add("INSERT");
            c2.Items.Add("DELETE");
            c2.Items.Add("UPDATE");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.ListarTabla(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLTriggers(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Trigger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.AgregarTriggers(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, comboBox2.Text, comboBox1.Text, Fun_Proyecto.Tabla, Fun_Proyecto.Esquema, textBox1.Text, richTextBox1.Text);
            richTextBox1.Text = "";
            textBox1.Text = "";
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.BorrarTriggers(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Trigger);
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.BorrarTriggers(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Trigger);
            Fun_Proyecto.EjecutarQuery(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, richTextBox1.Text);
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }
    }
}
