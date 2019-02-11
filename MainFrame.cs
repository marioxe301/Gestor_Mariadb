using MySql.Data.MySqlClient;
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
        Fun_Proyecto funct = new Fun_Proyecto("root","1234567890");
        
        public MainFrame()
        {
            InitializeComponent();
            Fun_Proyecto.LlenarTree(Fun_Proyecto.Usuario, Fun_Proyecto.Contraseña, treeView1);
            
            
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

