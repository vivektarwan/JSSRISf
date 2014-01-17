using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace JSSRIS
{
    
    public partial class Registrationwindow : Form
    {
        public Registrationwindow()
        {
            InitializeComponent();
            label16.Text=textBox6.Text;
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(365);
            dateTimePicker2.MaxDate = dateTimePicker1.Value.AddDays(365);
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(365);
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            
            
        }
     
        SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
     
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 100;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            label2.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
        }

       
            
        
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            
            StartTimer();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(365);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label16.Text = textBox6.Text;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }


          
 
        

        

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_patientinfo";
            cmd.Connection = cn;
            int pid = 0;
            pid = Convert.ToInt32(new SqlCommand("select jsshospitalid from patientinfo order by 1 desc", cn).ExecuteScalar().ToString()) + 1;
            SqlParameter p0 = new SqlParameter("@jsshospitalid", SqlDbType.VarChar,20);
             label18.Text = pid.ToString();
                p0.Value = pid.ToString();
                cmd.Parameters.Add(p0); 

            
            SqlParameter p = new SqlParameter("@patientname", SqlDbType.VarChar, 40);
            p.Value = textBox1.Text;
            cmd.Parameters.Add(p);

            SqlParameter p1 = new SqlParameter("@patientparentname", SqlDbType.VarChar, 40);
            p1.Value = textBox2.Text;
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter("@age", SqlDbType.VarChar, 20);
            p2.Value = textBox3.Text;
            
                cmd.Parameters.Add(p2);
           
          
            SqlParameter p3 = new SqlParameter("@sex", SqlDbType.VarChar, 20);
            if (radioButton4.Checked == true)
            {
                p3.Value = "Male";
            }
            else
            {
                p3.Value = "Female";
            }
                cmd.Parameters.Add(p3);

            SqlParameter p4 = new SqlParameter("@Income", SqlDbType.VarChar, 20);
            p4.Value = textBox4.Text;
            cmd.Parameters.Add(p4);

            SqlParameter p5 = new SqlParameter("@patientaddress", SqlDbType.VarChar,200);
            p5.Value = textBox5.Text;
            cmd.Parameters.Add(p5);

            SqlParameter p6 = new SqlParameter("@registrationdate", SqlDbType.DateTime);
            p6.Value = dateTimePicker1.Value ;
            cmd.Parameters.Add(p6);

            SqlParameter p7 = new SqlParameter("@validuptodate", SqlDbType.DateTime);
            p7.Value = dateTimePicker2.Value;
            cmd.Parameters.Add(p7);
            

            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Patient Registration successful!!!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton3.Checked = true;
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label18.Text != "")
            {
                Printpatientinfo p = new Printpatientinfo();
                p.Show();
            }
            else
            {
                MessageBox.Show("Patient Registration is not completed!!!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string  qry1,sj;
            sj = textBox7.Text;
            if (sj == "" && radioButton2.Checked != true)
            {
                MessageBox.Show("Please Enter the Details!! ", "Error!!");

            }
            else
            {

                try
                {
                    if (radioButton1.Checked == true)
                    {
                        qry1 = "select * from patientinfo where jsshospitalid=" + textBox7.Text + "";
                    }
                    else
                    {
                        qry1 = "select * from patientinfo order by patientname" + textBox7.Text + "";
                    }
                    SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                    DataSet Ds1 = new DataSet();
                    Da.Fill(Ds1, "patientinfo");
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            new Appwindow().Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        

        
        
             
        
        

       
        

        
    }
}