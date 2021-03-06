﻿using System;
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
    public partial class TodosDDL : Form
    {
        Fun_Proyecto funct;
        public TodosDDL(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = fun;
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLdb(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Esquema);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLFunciones(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Funciones);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLTriggers(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Trigger);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLViews(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Vista);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLTablas(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Tabla);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLProcedimientos(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Procedimiento);
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

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tables tb = new Tables(funct);
            this.Hide();
            tb.Show();
        }

        private void esquemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esquemas esq = new Esquemas(funct);
            this.Hide();
            esq.Show();
        
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

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainFrame mn = new MainFrame(funct);
            this.Hide();
            mn.Show();
        }
    }
}
