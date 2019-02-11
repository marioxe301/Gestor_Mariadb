using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_TB2
{

    public class Fun_Proyecto
    {
        public static string Usuario { get; set; }
        public static string Contraseña { get; set; }
        public static string Esquema { get; set; }
        public static string NConeccion { get; set; }

        public Fun_Proyecto(string u, string c, string e, string Nc)
        {
            Usuario = u;
            Contraseña = c;
            Esquema = e;
            NConeccion = Nc;
        }

        public Fun_Proyecto(string u, string c)
        {
            Usuario = u;
            Contraseña = c;
        }

        internal static void LlenarTree(string usuario, string contraseña, TreeView treeView1)
        {
            MySqlConnection con = new MySqlConnection("port=1234;server=127.0.0.1;user id=" + usuario + ";password=" + contraseña);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("show databases", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable ds = new DataTable();

            adp.Fill(ds);
            cmd.Dispose();
            con.Close();

            MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database=information_schema;password="+contraseña);
            con1.Open();

            MySqlConnection con2 = new MySqlConnection("port=1234;server=127.0.0.1;user id=" + usuario + ";database=mysql;password=" + contraseña);
            con2.Open();


            

            int i = 0;
            foreach (DataRow dr in ds.Rows)
            {

                treeView1.Nodes.Add(dr["Database"].ToString());

                //TABLAS
                treeView1.Nodes[i].Nodes.Add("Tablas");
                MySqlCommand cmd1 = new MySqlCommand("select TABLE_NAME from " + "TABLES" + " where TABLE_SCHEMA = " + "'" + dr["Database"].ToString() + "'", con1);
                MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);
                DataTable ds1 = new DataTable();
                adp1.Fill(ds1);

                //FUNCIONES
                treeView1.Nodes[i].Nodes.Add("Funciones");
                MySqlCommand cmd2 = new MySqlCommand("select proc.name from proc "+"where proc.type = "+"'"+"FUNCTION"+"' and proc.db = '"+dr["Database"].ToString()+ "'", con2);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(cmd2);
                DataTable ds2 = new DataTable();
                adp2.Fill(ds2);


                
                treeView1.Nodes[i].Nodes.Add("Procedimientos");
                MySqlCommand cmd3 = new MySqlCommand("select proc.name from proc " + "where proc.type = " + "'" + "PROCEDURE" + "' and proc.db = '" + dr["Database"].ToString() + "'", con2);
                MySqlDataAdapter adp3 = new MySqlDataAdapter(cmd3);
                DataTable ds3 = new DataTable();
                adp3.Fill(ds3);


                treeView1.Nodes[i].Nodes.Add("Triggers");
                MySqlCommand cmd4 = new MySqlCommand("select trigger_name from TRIGGERS where trigger_schema = '"+ dr["Database"].ToString()+"'", con1);
                MySqlDataAdapter adp4 = new MySqlDataAdapter(cmd4);
                DataTable ds4 = new DataTable();
                adp4.Fill(ds4);


                treeView1.Nodes[i].Nodes.Add("Vistas");
                MySqlCommand cmd5 = new MySqlCommand("select TABLE_NAME from VIEWS where TABLE_SCHEMA = '"+ dr["Database"].ToString()+"'", con1);
                MySqlDataAdapter adp5 = new MySqlDataAdapter(cmd5);
                DataTable ds5 = new DataTable();
                adp5.Fill(ds5);

                foreach (DataRow dr1 in ds1.Rows)
                {
                    treeView1.Nodes[i].Nodes[0].Nodes.Add(dr1["TABLE_NAME"].ToString());
                }

                foreach ( DataRow dr2 in ds2.Rows)
                {
                    treeView1.Nodes[i].Nodes[1].Nodes.Add(dr2["name"].ToString());
                }

                foreach (DataRow dr3 in ds3.Rows)
                {
                    treeView1.Nodes[i].Nodes[2].Nodes.Add(dr3["name"].ToString());
                }

                foreach (DataRow dr4 in ds4.Rows)
                {
                    treeView1.Nodes[i].Nodes[3].Nodes.Add(dr4["trigger_name"].ToString());
                }

                foreach (DataRow dr5 in ds5.Rows)
                {
                    treeView1.Nodes[i].Nodes[4].Nodes.Add(dr5["TABLE_NAME"].ToString());
                }

                i++;
            }




        }

        internal static void CrearTabla(string nombre, List<object> parametros)
        {

        }
        
        internal static void ModificarTablas()
        {

        }

        internal static void AgregarDatosTablas()
        {

        }

        internal static Boolean VerificarUsuario(string usuario,string contraseña)
        {
            return true;
        }

        internal static void AgregarFunciones()
        {

        }

        internal static void BorrarFunciones()
        {

        }

        internal static void AgregarProcedimientos()
        {

        }

        internal static void BorrarProcedimientos()
        {

        }

        internal static void ModificarFunciones()
        {

        }

        internal static void ModificarProcedimientos()
        {

        }
        
        internal static void AgregarTriggers()
        {

        }

        internal static void BorrarTriggers()
        {

        }

        internal static void AgregarVista()
        {

        }

        internal static void BorrarVista()
        {

        }

        internal static void ModificarTrigger()
        {

        }

        internal static void ModificarVista()
        {

        }
    }
}
