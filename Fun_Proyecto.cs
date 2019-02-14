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
        

        public Fun_Proyecto(string u, string c, string e, string Nc)
        {
            Usuario = u;
            Contraseña = c;
            Esquema = e;
        }//T

        public Fun_Proyecto(string u, string c)
        {
            Usuario = u;
            Contraseña = c;
        }//T

        public Fun_Proyecto() { }//T

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

                con1.Close();
                con2.Close();
        

        }//T

        internal static void CrearTabla(string usuario, string contraseña,string nombre, string db,List<object> parametros,List<string>nombres)
        {
            try{
            MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database="+db+";password="+contraseña);
            con1.Open();
            string scriptSQL = "CREATE TABLE IF NOT EXISTS"+nombre+" ( ";
            for(int i =0; i< parametros.Count;i++){
                Type t = parametros[i].GetType();
                if(t.Equals(typeof(int))){
                    scriptSQL= scriptSQL+ nombres[i] +" INT, ";
                }else if(t.Equals(typeof(StringBuilder))){
                    scriptSQL= scriptSQL+ nombres[i] +" TEXT, ";
                }else if(t.Equals(typeof(bool))){
                    scriptSQL= scriptSQL+ nombres[i] +" BOOL, ";
                }else if(t.Equals(typeof(double))){
                    scriptSQL= scriptSQL+ nombres[i] +" DOUBLE, ";
                }else if(t.Equals(typeof(string))){
                    scriptSQL= scriptSQL+ nombres[i] +" VARCHAR(50), "; //50 por default
                }
            }
            
            scriptSQL = scriptSQL.Substring(0,scriptSQL.Length-1);
            scriptSQL = scriptSQL +") engine = Innodb;"; 

            MySqlCommand cmd = new MySqlCommand(scriptSQL, con1);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Tabla Creada");
            cmd.Dispose();
            con1.Close();
            }catch(Exception e){
                MessageBox.Show("Error al crear Tablas");
            }
        }
        
        internal static void ModificarTablas()
        {

        }

        internal static void AgregarDatosTablas(string usuario, string contraseña,string nombre,string db,List<string>datos) //T
        {
            MySqlConnection conT = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database="+db+";password="+contraseña);
            conT.Open();

            MySqlCommand cmdT = new MySqlCommand("SELECT DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name= "+"'"+nombre+"'",conT);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmdT);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            string sqlQuery = "insert into "+nombre+" values (";
            int i=0;
                foreach(DataRow dr in dt.Rows){
                    if(dr["DATA_TYPE"].ToString()=="int"||dr["DATA_TYPE"].ToString()=="tinyint" || dr["DATA_TYPE"].ToString()=="double"){
                        sqlQuery = sqlQuery + datos[i].ToString() +",";
                    }else if(dr["DATA_TYPE"].ToString()=="varchar"||dr["DATA_TYPE"].ToString()=="text"){
                        sqlQuery = sqlQuery +"'"+datos[i].ToString()+"'"+",";
                    }
                    i++;
                }
            sqlQuery = sqlQuery.Substring(0,sqlQuery.Length-1)+");";

            MySqlCommand cmdC = new MySqlCommand(sqlQuery,conT);
            cmdC.ExecuteNonQuery();
            cmdC.Dispose();
            cmdT.Dispose();
            conT.Close();
            
        }

        internal static Boolean VerificarUsuario(string usuario,string contraseña) // T
        {
            MySqlConnection con = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;database=mysql;password=1234567890");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select User, Password from user where User = '"+usuario+"'"+" and Password = password('"+contraseña+"')", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable ds = new DataTable();

            adp.Fill(ds);
            cmd.Dispose();
            con.Close();

            foreach (DataRow item in ds.Rows)
            {
                if (item["User"].ToString() != "")
                {
                    
                    return true;
                }
            }

            return false;
            
        }//T

        internal static void AgregarFunciones(string usuario,string contraseña,string db, List<object>parametros,List<string>nombres,string nombre)
        {
                
        }

        internal static void BorrarFunciones(string usuario, string contraseña, string db,string nombre) // T
        {
            MySqlConnection conT = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database="+db+";password="+contraseña);
            conT.Open();

            MySqlCommand cmd = new MySqlCommand("drop function "+nombre,conT);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conT.Close();

        }

        internal static void AgregarProcedimientos(string usuario, string contraseña, string db, List<object> parametros,List<string>nombres,string nombre)
        {

        }

        internal static void BorrarProcedimientos(string usuario, string contraseña, string db, string nombre) // T
        {
            MySqlConnection conT = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database="+db+";password="+contraseña);
            conT.Open();

            MySqlCommand cmd = new MySqlCommand("drop procedure "+nombre,conT);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conT.Close();
        }

        internal static void ModificarFunciones(string usuario, string contraseña, string db, List<object> parametros,string nombre)
        {

        }

        internal static void ModificarProcedimientos(string usuario, string contraseña, string db, List<object> parametros,string nombre)
        {

        }
        
        internal static void AgregarTriggers(string usuario, string contraseña,string estado,string evento,string NTabla, string db,string nombre)
        {
            
        }

        internal static void BorrarTriggers(string usuario, string contraseña, string db, string nombre) //T
        {
            MySqlConnection conT = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database="+db+";password="+contraseña);
            conT.Open();

            MySqlCommand cmd = new MySqlCommand("drop TRIGGER "+nombre,conT);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conT.Close();
        }

        internal static void AgregarVista(string usuario, string contraseña, string db, string nombre)
        {

        }

        internal static void BorrarVista(string usuario, string contraseña, string db, string nombre) //T
        {
            MySqlConnection conT = new MySqlConnection("port=1234;server=127.0.0.1;user id="+usuario+";database="+db+";password="+contraseña);
            conT.Open();

            MySqlCommand cmd = new MySqlCommand("drop view "+nombre,conT);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conT.Close();
        }

        internal static void ModificarTrigger(string usuario, string contraseña, string db, string nombre)
        {

        }

        internal static void ModificarVista(string usuario, string contraseña, string db, string nombre)
        {

        }

        internal static void LlenarTipoDato(ComboBox cmb) //T
        {
            cmb.Items.Add("INT");
            cmb.Items.Add("VARCHAR");
            cmb.Items.Add("DOUBLE");
            cmb.Items.Add("BOOL");
            cmb.Items.Add("TEXT");
        }

        internal static void CrearUsuarios(string usuario, string contraseña) //T
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;password=1234567890");
                con1.Open();
                MySqlCommand cmd = new MySqlCommand("CREATE USER '" + usuario + "'@'127.0.0.1' IDENTIFIED BY '" + contraseña + "';", con1);
                MySqlCommand cmd1 = new MySqlCommand("GRANT ALL PRIVILEGES ON *.* TO '"+usuario+"'@'"+"127.0.0.1' IDENTIFIED BY '"+contraseña+"';", con1);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd.Dispose();
                cmd1.Dispose();
                con1.Close();
                con1.Close();
                MessageBox.Show("Usuario Creado");

            }catch(Exception e)
            {
                MessageBox.Show("Error al crear usuario"+e.StackTrace);
            }

        }

        internal static void ListarUsuarios(DataGridView dt) // T
        {
            dt.DataSource = null;
            MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;database=mysql;password=1234567890");
            con1.Open();
            MySqlCommand cmd = new MySqlCommand("select User as Usuarios from user", con1);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Usuarios");
            dt.ReadOnly = true;
            dt.DataSource = ds;
            dt.DataMember = "Usuarios";

            con1.Close();
        }

        internal static void ListarDatosTabla(string tbname,string db, DataGridView dt) //T
        {
            dt.DataSource = null;
            MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;database="+db+";password=1234567890");
            con1.Open();
            MySqlCommand cmd = new MySqlCommand("select * from " + db + "." + tbname, con1);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt1= new DataTable();
            adp.Fill(dt1);

            dt.DataSource = dt1;
            con1.Close();
            cmd.Dispose();

        }

        internal static void ListarTabla(string tbname, DataGridView dt)
        {

        }

        internal static void EjecutarQuery(string usuario, string contraseña, string db,string script) //T
        {
            try
            {
                MySqlConnection con1 = new MySqlConnection("port=1234;server=127.0.0.1;user id=" + usuario + ";database=" + db + ";password=" + contraseña);
                con1.Open();
                MySqlCommand cmd = new MySqlCommand(script, con1);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con1.Close();
                MessageBox.Show("Script Ejecutado Perfectamente");
            }catch(Exception e)
            {
                MessageBox.Show("Revise el Script");
            }
        }
    }
}
