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
    public partial class Esquemas : Form
    {
        Fun_Proyecto funct;
        public Esquemas(Fun_Proyecto fun)
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
            Fun_Proyecto.CrearEsquema(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, textBox1.Text);
            textBox1.Text = "";
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.BorrarEsquema(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema);
            treeView1.Nodes.Clear();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tables tb = new Tables(funct);
            this.Hide();
            tb.Show();
        }

        private void esquemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
            Triggers tgp = new Triggers(funct);
            this.Hide();
            tgp.Show();
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
