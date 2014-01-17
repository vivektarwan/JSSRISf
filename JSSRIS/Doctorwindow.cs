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
    public partial class Doctorwindow : Form
    {
        int flag=1;
        SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
        public Doctorwindow()
        {
            InitializeComponent();
            
                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM Doctorinfo", cn);
                cn.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox6.Items.Add(sqlReader["loginid"].ToString());
                }

                sqlReader.Close();
            cn.Close();
            
        }
        private void StartTimer()
        {
            //tmr = new System.Windows.Forms.Timer();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            label52.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
           
            
            string s1 = "";
            if (textBox1.Text != "")
            {
                 try
            {
                cn.Open();
                s1 = textBox1.Text;
                int pid = 0;
                pid = Convert.ToInt32(new SqlCommand("select jsshospitalid from patientinfo where jsshospitalid='" + s1 + "'", cn).ExecuteScalar().ToString());
                label12.Text = pid.ToString();
                label3.Text = Convert.ToString(new SqlCommand("select patientname from patientinfo where jsshospitalid='" + s1 + "'", cn).ExecuteScalar().ToString());
                label5.Text = Convert.ToString(new SqlCommand("select age from patientinfo where jsshospitalid='" + s1 + "'", cn).ExecuteScalar().ToString());
                label8.Text = Convert.ToString(new SqlCommand("select sex from patientinfo where jsshospitalid='" + s1 + "'", cn).ExecuteScalar().ToString());
                label10.Text = Convert.ToString(new SqlCommand("select patientaddress from patientinfo where jsshospitalid='" + s1 + "'", cn).ExecuteScalar().ToString());
                tabControl2.Visible = true;
                StartTimer();
                cn.Close();
            }

                 catch (System.Exception sql)
                 {
                     textBox1.Text = "";
                     panel1.Visible = false;
                     MessageBox.Show("Please Check unique Id!!" + sql.Message,
                         "UniqueID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     cn.Close();


                 }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Appwindow().Show();
            this.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag = 1;
            if (label12.Text == "")
            {
                label56.Text = "N/A";
            }
            else
            {
                label56.Text = label12.Text;
            }
            if (label13.Text == "")
            {
                label65.Text = "N/A";
            }
            else
            {
                label65.Text = label3.Text;
            }
            if (label15.Text == "")
            {
                label63.Text = "N/A";
            }
            else
            {
                label63.Text = label5.Text;
            }
            if (label18.Text == "")
            {
                label60.Text = "N/A";
            }
            else
            {
                label60.Text = label8.Text;
            }
            if (textBox2.Text == "")
            {
                label87.Text = "N/A";
            }
            else
            {
                label87.Text = textBox2.Text + label22.Text;
            }
            if (textBox2.Text == "")
            {
                label88.Text = "N/A";
            }
            else
            {
                label88.Text = textBox3.Text + label23.Text;
            }
            if (textBox4.Text == "")
            {
                label89.Text = "N/A";
            }
            else
            {
                label89.Text = textBox4.Text + comboBox1.Text;
            }
            if (textBox5.Text == "")
            {
                label90.Text = "N/A";
            }
            else
            {
                label90.Text = textBox5.Text;
            }
            if (textBox6.Text == "")
            {
                label91.Text = "N/A";
            }
            else
            {
                label91.Text = textBox6.Text;
            }
            if (textBox7.Text == "")
            {
                label92.Text = "N/A";
            }
            else
            {
                label92.Text = textBox7.Text + label17.Text;
            }
            if (textBox8.Text == "")
            {
                label93.Text = "N/A";
            }
            else
            {
                label93.Text = textBox8.Text;
            }
            if (textBox10.Text == "")
            {
                label94.Text = "N/A";
            }
            else
            {
                label94.Text = textBox10.Text;
            }
            if (textBox11.Text == "")
            {
                label95.Text = "N/A";
            }
            else
            {
                label95.Text = textBox11.Text;
            } 
            if (textBox12.Text == "")
            {
                label96.Text = "N/A";
            }
            else
            {
                label96.Text = textBox12.Text;
            }
            
            
            
            if (comboBox3.Text == "")
            {
                label97.Text = "N/A";
            }
            else
            {
                label97.Text = comboBox3.Text;
            }
            if (textBox9.Text == "")
            {
                label98.Text = "N/A";
            }
            else
            {
                label98.Text = textBox9.Text;
            }
            

            dateTimePicker4.Value = dateTimePicker1.Value;
            dateTimePicker4.MaxDate  = dateTimePicker1.Value;
            dateTimePicker4.MinDate  = dateTimePicker1.Value;

            if (comboBox2.Text == "")
            {
                label100.Text = "N/A";
            }
            else
            {
                label100.Text = comboBox2.Text;
            }
            if (textBox13.Text == "")
            {
                label101.Text = "N/A";
            }
            else
            {
                label101.Text = textBox13.Text;
            }
            if (textBox14.Text == "")
            {
                label102.Text = "N/A";
            }
            else
            {
                label102.Text = textBox14.Text;
            }
            if (textBox26.Text == "")
            {
                label103.Text = "N/A";
            }
            else
            {
                label103.Text = textBox26.Text;
            }
            
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Select Priority!!!");
                flag = 0;
            }
            else
            {
                label105.Text = comboBox5.Text;
            }
            if (comboBox6.Text == "")
            {
                MessageBox.Show("Select Ordering Practitioner!!!");
                flag = 0;
            }
            else
            {
                label106.Text = comboBox6.Text;
            }
            if (label52.Text == "")
            {
                label107.Text = "N/A";
            }
            else
            {
                label107.Text = label52.Text;
            }
           
            if (flag == 1)
            {
                tabControl1.SelectedTab = tabPage9;
                flag = 2;
            }
            else
            {
                
                tabControl1.SelectedTab = tabPage1;
            }


        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void label87_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            tabControl2.SelectedTab = tabPage6;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                string qry1 = "select * from Labtestinfo where jsshospitalid =" + label56.Text + "";
                
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Labtestinfo");
                dataGridView1.DataSource = Ds1.Tables[0];
                // dataGridView1.DataMember();
                cn.Close();
            }
            catch (System.Exception sql)
            {
                textBox7.Text = "";

                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (flag == 2)
            {
                SqlDataReader dr;
                cn.Open();
                string qry1;
                textBox25.Text = textBox25.Text + "DD";
                qry1 = "select * from Doctorinfo where loginid='" + comboBox6.Text + "' and password='" + textBox25.Text + "'";
                SqlCommand cmd1 = new SqlCommand(qry1, cn);
                dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    flag = 3;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter the correct password!!!");
                    textBox25.Text = "";
                    cn.Close();

                }

                if (flag == 3)
                {
                    try 
                    {   
                    cn.Open();


                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_Orderinfor";
                    cmd.Connection = cn;
                    
                    SqlParameter p0 = new SqlParameter("@jsshospitalid", SqlDbType.VarChar, 20);

                   p0.Value = label12.Text;
                    cmd.Parameters.Add(p0);

                    int oid = 0;
                    oid = Convert.ToInt32(new SqlCommand("select orderuniqueid from Orderinfor order by 1 desc", cn).ExecuteScalar().ToString()) + 1;
                    SqlParameter p = new SqlParameter("@orderuniqueid", SqlDbType.VarChar, 20);
                    p.Value = oid.ToString(); 
                    cmd.Parameters.Add(p);

                    SqlParameter p1 = new SqlParameter("@height", SqlDbType.VarChar, 20);
                    p1.Value = textBox2.Text+label22.Text;
                    cmd.Parameters.Add(p1);

                    SqlParameter p2 = new SqlParameter("@weight", SqlDbType.VarChar, 20);
                    p2.Value = textBox3.Text + label23.Text;
                    cmd.Parameters.Add(p2);
                    SqlParameter p3 = new SqlParameter("@BGL", SqlDbType.VarChar, 20);
                    if (comboBox1.Text == "")
                    {
                        comboBox1.Text = "mmol/L";
                    }
                    p3.Value = textBox4.Text + comboBox1.Text;
                    cmd.Parameters.Add(p3);

                  
                    SqlParameter p4 = new SqlParameter("@BP", SqlDbType.VarChar, 20);
                    p4.Value = textBox5.Text;
                    cmd.Parameters.Add(p4);

                    SqlParameter p5 = new SqlParameter("@HR", SqlDbType.VarChar, 20);
                    p5.Value = textBox6.Text;
                    cmd.Parameters.Add(p5);

                    SqlParameter p6 = new SqlParameter("@Temp", SqlDbType.VarChar, 20);
                    p6.Value = textBox7.Text+label17.Text ;
                    cmd.Parameters.Add(p6);

                    SqlParameter p7 = new SqlParameter("@BSA", SqlDbType.VarChar, 20);
                    p7.Value = textBox8.Text;
                    cmd.Parameters.Add(p7);

                    SqlParameter p8 = new SqlParameter("@Allergies", SqlDbType.VarChar, 1024);
                    p8.Value = textBox10.Text;
                    cmd.Parameters.Add(p8);
                    SqlParameter p9 = new SqlParameter("@IPD", SqlDbType.VarChar, 20);
                    p9.Value = textBox11.Text;
                    cmd.Parameters.Add(p9);

                    SqlParameter p10 = new SqlParameter("@HRD", SqlDbType.VarChar, 20);
                    p10.Value = textBox12.Text + "\n Has Renal Dialysis-->"+comboBox3.Text;
                    cmd.Parameters.Add(p10);

                    SqlParameter p11 = new SqlParameter("@PTP", SqlDbType.VarChar, 20);
                    if (comboBox2.Text == "")
                    {
                        comboBox2.Text = "N/A";
                    }
                    p11.Value = comboBox2.Text;
                    cmd.Parameters.Add(p11);
                    SqlParameter p19 = new SqlParameter("@LMP", SqlDbType.DateTime);
                    p19.Value = dateTimePicker1.Value;
                    cmd.Parameters.Add(p19);
                    SqlParameter p12 = new SqlParameter("@PGR", SqlDbType.VarChar, 20);
                    if (textBox9.Text == "")
                    {
                        textBox9.Text = "N/A";
                    }
                    p12.Value = textBox9.Text;
                    cmd.Parameters.Add(p12);

                   
                    SqlParameter p13 = new SqlParameter("@CC", SqlDbType.VarChar, 20);
                    if (textBox13.Text == "")
                    {
                        textBox13.Text = "mmol/L";
                    }
                    p13.Value = textBox13.Text;
                    cmd.Parameters.Add(p13);


                    SqlParameter p14 = new SqlParameter("@CM", SqlDbType.VarChar, 20);
                    if (textBox14.Text == "")
                    {
                        textBox14.Text = "mmol/L";
                    }
                    p14.Value = textBox14.Text;
                    cmd.Parameters.Add(p14);

                    SqlParameter p15 = new SqlParameter("@priority", SqlDbType.VarChar, 20);
                    p15.Value = comboBox5.Text;
                    cmd.Parameters.Add(p15);

                    SqlParameter p16 = new SqlParameter("@OP", SqlDbType.VarChar, 20);
                    p16.Value = comboBox6.Text;
                    cmd.Parameters.Add(p16);

                    SqlParameter p17 = new SqlParameter("@RODT", SqlDbType.VarChar, 20);
                    p17.Value = label52.Text;
                    cmd.Parameters.Add(p17);
                    SqlParameter p20 = new SqlParameter("@ImagingTest", SqlDbType.VarChar, 20);
                    p20.Value = comboBox7.Text;
                    cmd.Parameters.Add(p20);
                    SqlParameter p18 = new SqlParameter("@Notes", SqlDbType.VarChar, 1024);
                    p18.Value = textBox26.Text;
                    cmd.Parameters.Add(p18);

                    
                    SqlParameter p21 = new SqlParameter("@Status", SqlDbType.VarChar, 20);
                    p21.Value = "Order_Placed";
                    cmd.Parameters.Add(p21);
                    SqlParameter p22 = new SqlParameter("@Technicianusername", SqlDbType.VarChar, 20);
                    p22.Value = "Not_Assigned";
                    cmd.Parameters.Add(p22);
                    SqlParameter p23 = new SqlParameter("@Radiologistusername", SqlDbType.VarChar, 20);
                    p23.Value = "Not_Assigned";
                    cmd.Parameters.Add(p23);
                    SqlParameter p24 = new SqlParameter("@Reportid", SqlDbType.VarChar, 20);
                    p24.Value = "Report_Not_Generated";
                    cmd.Parameters.Add(p24);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Order placed successfully!!!");
                }
                    
                   catch (System.Exception sql)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("System Error Report:" + sql.Message,
                    "LoginID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            } 
            
         
                }
            }
            else
            {
                MessageBox.Show("Please Check the Order!!!");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status,Technicianusername,Radiologistusername,Reportid from Orderinfor where priority='" + comboBox4.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView6.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status,Technicianusername,Radiologistusername,Reportid from Orderinfor where ImagingTest='" + comboBox8.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView6.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status,Technicianusername,Radiologistusername,Reportid from Orderinfor where Status='Order_Placed' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView6.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status,Technicianusername,Radiologistusername,Reportid from Orderinfor where jsshospitalid='" + textBox24.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView6.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }
        private void StartTimer2()
        {
            //tmr = new System.Windows.Forms.Timer();
            timer2.Interval = 100;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Enabled = true;
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select OP,Status,Reportid from Orderinfor where orderuniqueid='" + textBox28.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView2.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }

        }
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status,Technicianusername,Radiologistusername,Reportid from Orderinfor where OP='" + textBox27.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView6.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            StartTimer2();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
    }
}
