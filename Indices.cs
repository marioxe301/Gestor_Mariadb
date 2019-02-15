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
    public partial class Indices : Form
    {
        Fun_Proyecto funct;
        public Indices(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = fun;
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
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

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            Fun_Proyecto.ListarTabla(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox1);
            Fun_Proyecto.ListarTabla(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox4);
            Fun_Proyecto.ListarTabla(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox6);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.AgregarPK(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox1.Text, comboBox2.Text);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.AgregarFK(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox4.Text,comboBox6.Text, comboBox3.Text, comboBox5.Text,textBox1.Text);
            textBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            Fun_Proyecto.ListarColumnas(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox1.Text,comboBox2);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            Fun_Proyecto.ListarColumnas(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox4.Text, comboBox3);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            Fun_Proyecto.ListarColumnas(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox6.Text, comboBox5);
        }
    }
}
