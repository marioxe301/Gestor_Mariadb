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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            Fun_Proyecto.ListarUsuarios(dataGridView1);
            
        }
        //void Bind()
        //{

        //    //insert into contactos(numero) values (12)
        //    MySqlConnection con = new MySqlConnection("port=1234;server=127.0.0.1;user id=root;database=test;password=1234567890");
        //    con.Open();
        //    MySqlCommand cmd1 = new MySqlCommand("show create table contactos", con);
        //    MySqlDataAdapter adp1 = new MySqlDataAdapter(cmd1);
        //    DataTable ds1 = new DataTable();
        //    adp1.Fill(ds1);
        //    //MySqlCommand cmd = new MySqlCommand("insert into contactos(numero) values (34);select * from contactos;", con);
        //    //MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
        //    //DataSet ds = new DataSet();
        //    //ds.Tables.Add("hola");
        //    //adp.Fill(ds, "hola");
            
        //    foreach(DataRow dr in ds1.Rows)
        //    {
        //        Console.Write(dr["Create Table"].ToString());
        //    }

        //    // dataGridView1.DataSource = ds;
        //    //dataGridView1.DataMember = "hola";


        //    cmd1.Dispose();
        //    con.Close();

        //}

        //void holis()
        //{

        //    int i = 0;
        //    int cont = 0;
        //    for (int m = 0; m <= 14; m++)
        //    {

        //        if (m == 12)
        //        {
        //            Console.Write("\n");
        //            cont++;
        //            i++;
        //            m = 0;
        //        }
        //        else if (cont == 11)
        //        {
        //            m = 15;
        //        }
        //        Console.Write(i+" x "+m+" = " + i * m + "\t");

        //    }
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fun_Proyecto.CrearUsuarios(textBox1.Text, textBox2.Text);

            textBox1.Text = "";
            textBox2.Text = "";
            Fun_Proyecto.ListarUsuarios(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0 || textBox1.Text.Length != 0)
            {
                if (Fun_Proyecto.VerificarUsuario(textBox1.Text, textBox2.Text))
                {
                    Fun_Proyecto fun = new Fun_Proyecto(textBox1.Text, textBox2.Text);
                    MainFrame a = new MainFrame(fun);
                    this.Hide();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Usuario invalido, verifique bien");
                }

            }
            else
            {
                MessageBox.Show("Campos vacios");
            }
        }
    }

    
}
