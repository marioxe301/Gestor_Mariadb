﻿using MySql.Data.MySqlClient;
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
    public partial class MainFrame : Form
    {
        Fun_Proyecto funct;
        List<List<string>> lista;
        public MainFrame(Fun_Proyecto fun)
        {
            InitializeComponent();
            funct = new Fun_Proyecto();
            funct = fun;
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
            lista = new List<List<string>>();
            

        }

        private void NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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

        private void funcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Funciones functio = new Funciones(funct);
            this.Hide();
            functio.Show();

        }

        private void procedimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Procedimientos proc = new Procedimientos(funct);
            this.Hide();
            proc.Show();
        }

        private void vistasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vistas vst = new Vistas(funct);
            this.Hide();
            vst.Show();
        }

        private void indicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Indices indx = new Indices(funct);
            this.Hide();
            indx.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Triggers tgr = new Triggers(funct);
            this.Hide();
            tgr.Show();
        }

        private void dDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TodosDDL dl = new TodosDDL(funct);
            this.Hide();
            dl.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void esquemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esquemas esq = new Esquemas(funct);
            this.Hide();
            esq.Show();
        }

        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tables tb = new Tables(funct);
            this.Hide();
            tb.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.EjecutarQuery(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, richTextBox1.Text);
        }

        void llenarArray(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount-1; i++)
            {
                List<string> a = new List<string>();
                for (int j = 0; j < dgv.RowCount-1; j++)
                { 
                    a.Add(dgv.Rows[i].Cells[j].Value.ToString());  
                }
                lista.Add(a);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            llenarArray(dataGridView1);
            Fun_Proyecto.AgregarDatosTablas(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Tabla, Fun_Proyecto.Esquema, lista);
            lista.Clear();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            Fun_Proyecto.EjecutarSelects(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Esquema, richTextBox1.Text, dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            llenarArray(dataGridView1);
            Fun_Proyecto.AgregarDatosTablas(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, Fun_Proyecto.Tabla, Fun_Proyecto.Esquema, lista);
            lista.Clear();
        }

        //void LlenarTree()
        //{
        //    MySqlConnection con = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;password=1234567890");
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand("show databases", con);
        //    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
        //    DataTable ds = new DataTable();

        //    adp.Fill(ds);
        //    cmd.Dispose();
        //    con.Close();

        //    MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;database=information_schema;password=1234567890");
        //    con.Open();


        //    int i = 0;
        //    foreach (DataRow dr in ds.Rows)
        //    {
        //        treeView1.Nodes.Add(dr["Database"].ToString());

        //        MySqlCommand cmd1 = new MySqlCommand("select * from "+"TABLES"+" where TABLE_SCHEMA = "+ "'"+dr["Database"].ToString()+"'", con1);
        //        MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);
        //        DataTable ds1 = new DataTable();
        //        adp1.Fill(ds1);
        //        treeView1.Nodes[i].Nodes.Add("Tablas");
        //        treeView1.Nodes[i].Nodes.Add("Funciones");
        //        treeView1.Nodes[i].Nodes.Add("Procedimientos");
        //        treeView1.Nodes[i].Nodes.Add("Triggers");
        //        treeView1.Nodes[i].Nodes.Add("Vistas");

        //        foreach (DataRow dr1 in ds1.Rows)
        //        {
        //            treeView1.Nodes[i].Nodes[0].Nodes.Add(dr1["TABLE_NAME"].ToString());

        //        }

        //        i++;

        //    }

        // dataGridView1.DataSource = ds;
        //dataGridView1.DataMember = "hola";
        //treeView1.Nodes[0].Nodes.Add("Tablas");
        //treeView1.Nodes[0].Nodes.Add("Funciones");
        //treeView1.Nodes[0].Nodes.Add("Procedimientos");
        //treeView1.Nodes[0].Nodes.Add("Triggers");
        //treeView1.Nodes[0].Nodes.Add("Procedimientos");
        //treeView1.Nodes[0].Nodes.Add("Vistas");
    }
}

