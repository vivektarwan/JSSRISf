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
    public partial class Technicianwindow : Form
    {
        public Technicianwindow()
        {
            InitializeComponent();
            StartTimer();
        }
        SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
     
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where Status='Order_Placed' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView1.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {
                

                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where priority='" + comboBox5.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView1.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where ImagingTest='" + comboBox1.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView1.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where jsshospitalid='" + textBox21.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView1.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }
        private void StartTimer()
        {
            tmr1 = new System.Windows.Forms.Timer();
            tmr1.Interval = 100;
            tmr1.Tick += new EventHandler(tmr1_Tick);
            tmr1.Enabled = true;
        }

        void tmr1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {

                string qry1 = "select count(jsshospitalid) AS TotalNumberOfOrdersplaced from Orderinfor";
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
            try
            {

                string qry1 = "select count(jsshospitalid) AS RemainingOrderedTests from Orderinfor where Status='Order_Placed'";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView3.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            try
            {

                string qry1 = "select count(jsshospitalid) AS OrderedTestsPerforming from Orderinfor where Status='Order_Performing'";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView4.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            try
            {
                
                string ssi = DateTime.Now.ToString("dd/MM/yy");
                string qry1 = "select count(jsshospitalid) AS TotalNumberOfOrdersrequestedToday from Orderinfor where RODT like '"+ssi+"%'";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView5.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where OP='" + textBox1.Text + "' order by RODT";
                SqlDataAdapter Da = new SqlDataAdapter(qry1, cn);
                DataSet Ds1 = new DataSet();
                Da.Fill(Ds1, "Orderinfor");
                dataGridView1.DataSource = Ds1.Tables[0];
            }
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where orderuniqueid='" + textBox2.Text + "'";
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

        private void button8_Click(object sender, EventArgs e)
        {
            int Flag = 1;
            int flag1 = 1;
            SqlDataReader dr;
            SqlConnection cnn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
            cnn.Open();
            string qry1;
            textBox4.Text = textBox4.Text + "TT";
            qry1 = "select * from Technicianinfo where loginid='" + textBox3.Text + "' and password='" + textBox4.Text + "'";
            SqlCommand cmd1 = new SqlCommand(qry1, cnn);
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                Flag = 2;
                cnn.Close();
            }
            else
            {
                MessageBox.Show("Please Enter the correct password!!!");
                textBox3.Text = "";
                textBox4.Text = "";
                cnn.Close();

            }

            if (Flag == 2)
            {
                try
            {

                SqlDataReader reader;
                SqlConnection connect = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
                connect.Open();
                if (comboBox2.Text == "")
                {
                    flag1 = 2;
                }
                    if (textBox3.Text == "")
                {
                    flag1 = 2;
                }
                    if (textBox2.Text == "")
                {
                    flag1 = 2;
                }
                    if (flag1 == 1)
                    {
                        string status = comboBox2.Text;
                        string username = textBox3.Text;
                        string ouid = textBox2.Text;
                        string sqlquery = "UPDATE Orderinfor SET Technicianusername='" + textBox3.Text + "',Status='" + comboBox2.Text + "' where orderuniqueid='" + textBox2.Text + "'";
                        SqlCommand cmd = new SqlCommand(sqlquery, connect);


                        cmd.Connection = connect;
                        cmd.ExecuteNonQuery();
                        SqlCommand cd = new SqlCommand(sqlquery, connect);
                        reader = cd.ExecuteReader();
                        if(reader.Read())
                        {
                            connect.Close();
                        }
                        MessageBox.Show("Status Changed Successfully!");
                        connect.Close();
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        comboBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the required data!");
                    }
                    
                
                
            }
                catch (System.Exception sql)
                {


                    MessageBox.Show("No Search Results!!" + sql.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



                }
            }
        }
    }
}
