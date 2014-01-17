using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;
namespace JSSRIS
{
    public partial class Printpatientinfo : Form
    {
        SqlConnection cn = new SqlConnection("server=VIVEK_MISHRA-PC\\SQLEXPRESS;user id=sa;password=vmaaji;database=JSSRIS");
        public Printpatientinfo()
        {
            InitializeComponent();
            cn.Open();
            int pid = 0;
            pid = Convert.ToInt32(new SqlCommand("select jsshospitalid from patientinfo order by 1 desc", cn).ExecuteScalar().ToString());
            label1.Text = Convert.ToString(new SqlCommand("select patientname from patientinfo order by 1 desc", cn).ExecuteScalar().ToString());
            label6.Text = Convert.ToString(new SqlCommand("select age from patientinfo order by 1 desc", cn).ExecuteScalar().ToString());
            label8.Text = Convert.ToString(new SqlCommand("select sex from patientinfo order by 1 desc", cn).ExecuteScalar().ToString());
            label11.Text = Convert.ToString(new SqlCommand("select registrationdate from patientinfo order by 1 desc", cn).ExecuteScalar().ToString());
            label13.Text = Convert.ToString(new SqlCommand("select validuptodate from patientinfo order by 1 desc", cn).ExecuteScalar().ToString());
            label3.Text=pid.ToString();
            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                
                

                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPage;
                pd.Print();
                this.Close();
            
            
        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {  
         try
            {
            button1.Visible = false;
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;

            int width = this.Width;
            int height = this.Height;


            Rectangle bounds = new Rectangle(x, y, width, height);



            Bitmap img = new Bitmap(width, height);



            this.DrawToBitmap(img, bounds);
            string date = DateTime.Now.ToString("yyyyMMddhhmmss");

            //img.Save(date + ".bmp");
            //Point loc = new Point(100, 100);
            e.Graphics.DrawImage(img, bounds);
             }
         catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            
        }
    }
}
