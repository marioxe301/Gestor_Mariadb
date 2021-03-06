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
    public partial class Funciones : Form
    {
        Fun_Proyecto funct;
        List<object> parametros;
        List<string> nombres;
        DataTable dt;
        public Funciones(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = fun;
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
            dt = new DataTable();
            parametros = new List<object>();
            nombres = new List<string>();
            dt.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dt.Columns.Add(new DataColumn("Parametro", typeof(string)));

            dataGridView1.DataSource = dt;
            Fun_Proyecto.LlenarTipoDato(comboBox1);
            Fun_Proyecto.LlenarTipoDato(comboBox2);
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

        private void button6_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.DDLFunciones(richTextBox1, Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Funciones);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "INT":
                    parametros.Add(1);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox2.Text);
                    break;
                case "TEXT":
                    StringBuilder st = new StringBuilder("hola");
                    parametros.Add(st);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox2.Text);
                    break;
                case "BOOL":
                    parametros.Add(true);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox2.Text);
                    break;
                case "DOUBLE":
                    parametros.Add(1.567);
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox2.Text);
                    break;
                case "VARCHAR":
                    parametros.Add("hola");
                    nombres.Add(textBox2.Text);
                    dt.Rows.Add(textBox2.Text, comboBox2.Text);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.AgregarFunciones(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, comboBox1.Text, richTextBox1.Text, parametros, nombres, textBox1.Text);
            dt.Rows.Clear();
            parametros.Clear();
            nombres.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            treeView1.Nodes.Clear();
            richTextBox1.Text = "";
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.BorrarFunciones(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, Fun_Proyecto.Funciones);
            richTextBox1.Text = "";
        }

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tables tb = new Tables(funct);
            this.Hide();
            tb.Show();
        }

        private void esquemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esquemas sq = new Esquemas(funct);
            this.Hide();
            sq.Show();

        }

        private void funcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
            Triggers trg = new Triggers(funct);
            this.Hide();
            trg.Show();
        }

        private void dDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodosDDL dll = new TodosDDL(funct);
            this.Hide();
            dll.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainFrame mf = new MainFrame(funct);
            this.Hide();
            mf.Show();
        }
    }
}
