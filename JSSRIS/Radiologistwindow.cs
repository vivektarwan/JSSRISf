using System;
using System.IO;
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
    public partial class Radiologistwindow : Form
    {
        SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
        public Radiologistwindow()
        {
            InitializeComponent();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM ReportTypeFormat", cn);
            StartTimer();
            cn.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                comboBox1.Items.Add(sqlReader["ReportType"].ToString());

            }

            sqlReader.Close();

            cn.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM ReportTypeFormat where ReportType='" + comboBox1.Text + "'", cn);
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                textBox1.Text = sqlReader["ReportFormat"].ToString();
            }

            sqlReader.Close();
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Flag = 1;
            if (textBox2.Text != "")
            {
                if (textBox3.Text != "")
                {
                    if (textBox4.Text != "")
                    {
                        Flag = 2;
                    }
                }
            }
            else
            {
                MessageBox.Show("Provide all data!!!");
            }

            if (Flag == 2)
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.CommandText = "sp_ReportTypeFormat";
                cmd.Connection = cn;


                SqlParameter p = new SqlParameter("@ReportType", SqlDbType.VarChar, 1024);
                p.Value = textBox2.Text;
                cmd.Parameters.Add(p);

                SqlParameter p1 = new SqlParameter("@ReportFormat", SqlDbType.VarChar, 2147483647);
                p1.Value = textBox4.Text;
                cmd.Parameters.Add(p1);

                cmd.ExecuteNonQuery();

                MessageBox.Show("New Report Format Added!!!");


                SqlCommand sqlCmd = new SqlCommand("SELECT * FROM ReportTypeFormat", cn);
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    comboBox1.Items.Add(sqlReader["ReportType"].ToString());
                }

                sqlReader.Close();
                cn.Close();


                textBox2.Text = "";
                textBox3.Text = "";


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                textBox3.Text = file;
                using (FileStream fileStream = File.OpenRead(file))
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string fileContent = streamReader.ReadToEnd();

                    textBox4.Text = fileContent;
                }

            }

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Radiologistwindow_Load(object sender, EventArgs e)
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

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;


            string s1, s2, s3, s4 = "";
            if (textBox8.Text != "")
            {
                if (comboBox2.Text != "")
                {
                    try
                    {
                        cn.Open();
                        s1 = textBox8.Text;
                        int rid = 0;
                        rid = Convert.ToInt32(new SqlCommand("select  jsshospitalid from Orderinfor where orderuniqueid='" + s1 + "'", cn).ExecuteScalar().ToString());
                        label12.Text = rid.ToString();
                        int pid = 0;
                        pid = Convert.ToInt32(new SqlCommand("select reportuniqueid from Reportinfo order by 1 desc", cn).ExecuteScalar().ToString()) + 1;
                        label15.Text = pid.ToString();
                        label28.Text = label15.Text;
                        s2 = label12.Text;
                        label14.Text = Convert.ToString(new SqlCommand("select patientname from patientinfo where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                        label5.Text = Convert.ToString(new SqlCommand("select age from patientinfo where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                        label8.Text = Convert.ToString(new SqlCommand("select sex from patientinfo where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                        s3 = Convert.ToString(new SqlCommand("select OP from Orderinfor where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                        label13.Text = Convert.ToString(new SqlCommand("select name from Doctorinfo where loginid='" + s3 + "'", cn).ExecuteScalar().ToString());
                        label17.Text = Convert.ToString(new SqlCommand("select RODT from Orderinfor where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                        label20.Text = Convert.ToString(new SqlCommand("select ImagingTest from Orderinfor where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                        s4 = comboBox2.Text;
                        label22.Text = Convert.ToString(new SqlCommand("select name from Radiologistinfo where loginid='" + s4 + "'", cn).ExecuteScalar().ToString());
                        textBox5.Text = textBox1.Text;
                        label33.Text = textBox8.Text;
                        label25.Text = label20.Text;
                        label30.Text = label13.Text;
                        label34.Text = label17.Text;
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
                else
                {
                    MessageBox.Show("Please fill all Details!!");
                }
            }
            else
            {
                MessageBox.Show("Please fill all Details!!");
            }
        }
        private void StartTimer()
        {
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 100;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Enabled = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            label36.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
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
                string qry1 = "select count(jsshospitalid) AS TotalNumberOfOrdersrequestedToday from Orderinfor where RODT like '" + ssi + "%'";
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

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCmd1 = new SqlCommand("SELECT * FROM Radiologistinfo", cn);
            cn.Open();
            SqlDataReader sqlReader1 = sqlCmd1.ExecuteReader();

            while (sqlReader1.Read())
            {

                comboBox2.Items.Add(sqlReader1["loginid"].ToString());
            }
            sqlReader1.Close();
            cn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int flag1 = 1;
            SqlDataReader dr;
            SqlConnection cnn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
            cnn.Open();
            string qry1;
            textBox6.Text = textBox6.Text + "RR";
            qry1 = "select * from Radiologistinfo where loginid='" + textBox7.Text + "' and password='" + textBox6.Text + "'";
            SqlCommand cmd1 = new SqlCommand(qry1, cnn);
            dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                flag1 = 2;
                cnn.Close();
            }
            else
            {
                MessageBox.Show("Please Enter the correct password!!!");
                textBox7.Text = "";
                textBox6.Text = "";
                cnn.Close();

            }
            if (flag1 == 2)
            {
                cn.Open();


                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Reportinfo";
                cmd.Connection = cn;
                SqlParameter p0 = new SqlParameter("@reportuniqueid", SqlDbType.VarChar, 20);
                p0.Value = label28.Text;
                cmd.Parameters.Add(p0);


                SqlParameter p = new SqlParameter("@jsshospitalid", SqlDbType.VarChar, 20);
                p.Value = label12.Text;
                cmd.Parameters.Add(p);

                SqlParameter p1 = new SqlParameter("@orderuniqueid", SqlDbType.VarChar, 24);
                p1.Value = label33.Text;
                cmd.Parameters.Add(p1);

                SqlParameter p2 = new SqlParameter("@reportgenon", SqlDbType.Date);
                p2.Value = dateTimePicker1.Value;
                cmd.Parameters.Add(p2);


                SqlParameter p3 = new SqlParameter("@OP", SqlDbType.VarChar, 20);

                p3.Value = label30.Text;

                cmd.Parameters.Add(p3);

                SqlParameter p4 = new SqlParameter("@ImagingTest", SqlDbType.VarChar, 20);
                p4.Value = label25.Text;
                cmd.Parameters.Add(p4);

                SqlParameter p5 = new SqlParameter("@ReportFormat", SqlDbType.VarChar, 2147483647);
                p5.Value = textBox5.Text;
                cmd.Parameters.Add(p5);

                SqlParameter p6 = new SqlParameter("@Radiologistusername", SqlDbType.VarChar, 20);
                p6.Value = textBox7.Text;
                cmd.Parameters.Add(p6);

                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Report submitted successfully!!!");
                Updateorderinfo();
                label14.Text = "__________________";
                label5.Text = "__________________";
                label8.Text = "__________________";
                label12.Text = "__________________";
                label13.Text = "__________________";
                label17.Text = "__________________";
                label15.Text = "__________________";
                label20.Text = "__________________";
                label22.Text = "__________________";
                label33.Text = "__________________";
                label25.Text = "__________________";
                label28.Text = "__________________";
                label30.Text = "__________________";
                label34.Text = "__________________";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
               
                tabControl1.SelectedTab = tabPage1;
            }
        }
        private void Updateorderinfo()
        {
            try
            {

                SqlDataReader reader;
                SqlConnection connect = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
                connect.Open();



                string sqlquery = "UPDATE Orderinfor SET Radiologistusername='" + textBox7.Text + "',Status='Report_Generated',Reportid='" + label28.Text + "' where orderuniqueid='" + label33.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlquery, connect);


                    cmd.Connection = connect;
                    cmd.ExecuteNonQuery();
                    SqlCommand cd7 = new SqlCommand(sqlquery, connect);
                    reader = cd7.ExecuteReader();
                    if (reader.Read())
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
            catch (System.Exception sql)
            {


                MessageBox.Show("No Search Results!!" + sql.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4 = "";
            if (textBox21.Text != "")
            {
                try
                {
                    cn.Open();
                    s1 = textBox8.Text;
                    int rid = 0;
                    rid = Convert.ToInt32(new SqlCommand("select  jsshospitalid from Orderinfor where orderuniqueid='" + s1 + "'", cn).ExecuteScalar().ToString());
                    label12.Text = rid.ToString();
                    int pid = 0;
                    pid = Convert.ToInt32(new SqlCommand("select reportuniqueid from Reportinfo order by 1 desc", cn).ExecuteScalar().ToString()) + 1;
                    label15.Text = pid.ToString();
                    label28.Text = label15.Text;
                    s2 = label12.Text;
                    label14.Text = Convert.ToString(new SqlCommand("select patientname from patientinfo where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                    label5.Text = Convert.ToString(new SqlCommand("select age from patientinfo where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                    label8.Text = Convert.ToString(new SqlCommand("select sex from patientinfo where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                    s3 = Convert.ToString(new SqlCommand("select OP from Orderinfor where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                    label13.Text = Convert.ToString(new SqlCommand("select name from Doctorinfo where loginid='" + s3 + "'", cn).ExecuteScalar().ToString());
                    label17.Text = Convert.ToString(new SqlCommand("select RODT from Orderinfor where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                    label20.Text = Convert.ToString(new SqlCommand("select ImagingTest from Orderinfor where jsshospitalid='" + s2 + "'", cn).ExecuteScalar().ToString());
                    s4 = comboBox2.Text;
                    label22.Text = Convert.ToString(new SqlCommand("select name from Radiologistinfo where loginid='" + s4 + "'", cn).ExecuteScalar().ToString());
                    textBox5.Text = textBox1.Text;
                    label33.Text = textBox8.Text;
                    label25.Text = label20.Text;
                    label30.Text = label13.Text;
                    label34.Text = label17.Text;
                    cn.Close();
                }
                catch
                {
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where ImagingTest='" + comboBox3.Text + "' order by RODT";
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

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where Status='Order_Performed' order by RODT";
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

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where jsshospitalid='" + textBox10.Text + "' order by RODT";
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

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {

                string qry1 = "select jsshospitalid,orderuniqueid,priority,OP,RODT,ImagingTest,Status from Orderinfor where OP='" + textBox9.Text + "' order by RODT";
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
