using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JSSRIS
{
    public partial class Adminwindow : Form
    {

       
         public Adminwindow()
       {
           InitializeComponent();

        }


    SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
    private void Page_Load(object sender, EventArgs e)
    {

    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Sign up completed");

        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox4.Text = "";
        textBox5.Text = "";
        textBox6.Text = "";
        textBox7.Text = "";
        textBox8.Text = "";
        textBox9.Text = "";
    }
    private void button3_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Sign up canceled!!");

        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox4.Text = "";
        textBox5.Text = "";
        textBox6.Text = "";
        textBox7.Text = "";
        textBox8.Text = "";
        textBox9.Text = "";
    }


        


        private void button6_Click(object sender, EventArgs e)
        {
            new Appwindow().Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;

            if (comboBox1.Text != "")
            {
                if (comboBox1.Text == "Doctor")
                {
                    cmd.CommandText = "sp_Doctorinfo";
                    textBox3.Text = "DD";
                    textBox4.Text = "DD";
                }
                else
                {
                    if (comboBox1.Text == "Radiologist")
                    {
                        cmd.CommandText = "sp_Radiologistinfo";
                        textBox3.Text = "RR";
                        textBox4.Text = "RR";
                    }
                    else
                    {
                        if (comboBox1.Text == "Technician")
                        {
                            cmd.CommandText = "sp_Technicianinfo";
                            textBox3.Text = "TT";
                            textBox4.Text = "TT";
                        }
                        else
                        {
                            if (comboBox1.Text == "Receptionist")
                            {
                                cmd.CommandText = "sp_Receptionistinfo";
                                textBox3.Text ="CC";
                                textBox4.Text = "CC";
                                
                            }
                            else
                            {
                                MessageBox.Show("Select User Type!!!");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select User Type!!!");
            }
            
            cmd.Connection = cn;


            SqlParameter p = new SqlParameter("@name", SqlDbType.VarChar, 20);
            p.Value = textBox1.Text;
            cmd.Parameters.Add(p);

            SqlParameter p1 = new SqlParameter("@loginid", SqlDbType.VarChar, 20);
            p1.Value = textBox2.Text;
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter("@password", SqlDbType.VarChar, 20);
            p2.Value = textBox3.Text;
            if (textBox3.Text == textBox4.Text)
            {
                cmd.Parameters.Add(p2);
            }
            else
            {
                label27.Text = "Incorrect";
            }
            SqlParameter p3 = new SqlParameter("@depart", SqlDbType.VarChar, 20);
            p3.Value = textBox5.Text;
            cmd.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter("@special", SqlDbType.VarChar, 20);
            p4.Value = textBox6.Text;
            cmd.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter("@phone", SqlDbType.BigInt);
            p5.Value = textBox7.Text;
            cmd.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter("@address", SqlDbType.VarChar, 200);
            p6.Value = textBox8.Text;
            cmd.Parameters.Add(p6);

            SqlParameter p7 = new SqlParameter("@email", SqlDbType.VarChar, 20);
            p7.Value = textBox9.Text;
            cmd.Parameters.Add(p7);

            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Sign up completed");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            SqlConnection connect = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
            connect.Open();
            string Username = textBox13.Text;
            string password = textBox10.Text;
            string newPassword = textBox11.Text;
            string confirmPassword = textBox12.Text;
            string sqlquery = "UPDATE Admininfo SET password='" + textBox11.Text + "' where Username='" + textBox13.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlquery, connect);

            if (newPassword == confirmPassword)
            {
                cmd.Connection = connect;
                cmd.ExecuteNonQuery();
                SqlCommand cd = new SqlCommand(sqlquery, connect);
                reader = cd.ExecuteReader();
                while (reader.Read())
                {
                    if ((textBox11.Text == reader["password"].ToString())) { }
                }
                MessageBox.Show("Password Changed Successfully!");
                connect.Close();
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox10.Text = "";
            }
            else 
            {
                MessageBox.Show("Enter New Password Again!");
                connect.Close();
                textBox11.Text="";
                textBox12.Text = "";

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string qry1="", qry2, qry3, qry4, sj,sj2="";
            sj = comboBox2.Text;
            if (sj == "")
            {
                MessageBox.Show("Please Enter the Details!! ", "Error!!");

            }
            else
            {

                try
                {
                    if (sj == "Doctor")
                    {
                        qry1 = "select name,loginid,depart,special,phone,address,email from Doctorinfo";
                        sj2 = "Doctorinfo";
                    }
                    if (sj == "Radiologist")
                    {
                        qry2 = "select name,loginid,depart,special,phone,address,email from Radiologistinfo";
                        qry1 = qry2;
                        sj2 = "Radiologistinfo";
                    }
                    if (sj == "Technician")
                    {
                        qry3 = "select name,loginid,depart,special,phone,address,email from Technicianinfo";
                        qry1 = qry3;
                        sj2 = "Technicianinfo";

                    }
                    if (sj == "Receptionist")
                    {
                        qry4 = "select name,loginid,depart,special,phone,address,email from Receptionistinfo";
                        qry1 = qry4;
                        sj2 = "Receptionistinfo";
                    }
                    SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                    DataSet Ds1 = new DataSet();
                    Da.Fill(Ds1,sj2);
                    dataGridView1.DataSource = Ds1.Tables[0];
                    // dataGridView1.DataMember();
                }
                catch (System.Exception sql)
                {
                    textBox7.Text = "";

                    MessageBox.Show("No Search Results!!" + sql.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        
        

        

       

       

        

      
    }
}
