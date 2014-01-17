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

    public partial class Appwindow : Form
    {
        public Appwindow()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
        SqlDataReader dr,dr1,dr2,dr3,dr4;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {




            string LoginID, Password;


            LoginID = textBox1.Text;
            Password = textBox2.Text;

            cn.Open();
            string qry, qry1, qry2, qry3, qry4;
            try
            {

                qry = "select * from Admininfo where Username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    Adminwindow Check = new Adminwindow();
                    Check.Show();
                    this.Visible = false;
                    cn.Close();
                }

                else
                {
                    dr.Close();
                    textBox2.Text = textBox2.Text + "DD";
                    qry1 = "select * from Doctorinfo where loginid='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(qry1, cn);
                    dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        Doctorwindow Check2 = new Doctorwindow();
                        Check2.Show();
                        this.Visible = false;
                        cn.Close();

                    }
                    else
                    {
                        dr1.Close();
                        textBox2.Text = Password;
                        textBox2.Text = textBox2.Text + "RR";
                        qry2 = "select * from Radiologistinfo where loginid='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                        SqlCommand cmd2 = new SqlCommand(qry2, cn);
                        dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Radiologistwindow Check2 = new Radiologistwindow();
                            Check2.Show();
                            this.Visible = false;
                            cn.Close();

                        }
                        else
                        {
                            dr2.Close();
                            textBox2.Text = Password;
                            textBox2.Text = textBox2.Text + "TT";
                            qry3 = "select * from Technicianinfo where loginid='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                            SqlCommand cmd3 = new SqlCommand(qry3, cn);
                            dr3 = cmd3.ExecuteReader();
                            if (dr3.Read())
                            {
                                Technicianwindow Check2 = new Technicianwindow();
                                Check2.Show();
                                this.Visible = false;
                                cn.Close();

                            }
                            else
                            {
                                dr3.Close();
                                textBox2.Text = Password;
                                textBox2.Text = textBox2.Text + "CC";
                                qry4 = "select * from Receptionistinfo where loginid='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                                SqlCommand cmd4 = new SqlCommand(qry4, cn);
                                dr4 = cmd4.ExecuteReader();
                                if (dr4.Read())
                                {
                                    Registrationwindow Check2 = new Registrationwindow();
                                    Check2.Show();
                                    this.Visible = false;
                                    cn.Close();

                                }
                                else
                                {
                                    MessageBox.Show("There is no such LoginID and Password present.This problem can be solve by:-\n1.Create new LoginID and Password.\n2.Enter correctly the LoginID and Password previously created", "Error!!");
                                    cn.Close();
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                }

                            }
                        }


                    }

                }
            }

            catch (System.Exception sql)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("There is no such LoginID present.This problem can be solve by:-\n1.Create new LoginID.\n2.Enter correctly the LoginID previously ceated.\n\nSystem Error Report:" + sql.Message,
                    "LoginID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
        }
       

        private void Appwindow_Load(object sender, EventArgs e)
        {

        }
    }
}
