using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OsherProject
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            timer1.Start();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = ColorTranslator.FromHtml("#6464FA");
            textBox1.Font = new Font("Tahoma", 15);
            textBox2.Font = new Font("Tahoma", 15);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 15);
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 1;
            button1.ForeColor = Color.White;
            button1.Height = 40;
            Sets.SetName(textBox1);
            Sets.SetPass(textBox2);
            //textBox2.PasswordChar = '\u25CF';
            textBox2.PasswordChar = '☻';

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = OsherProject.Properties.Resources.minus7775;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = OsherProject.Properties.Resources.minus75;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = OsherProject.Properties.Resources.close777;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = OsherProject.Properties.Resources.close7;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = Design.DayOfTheWeek(DateTime.Now.DayOfWeek + "") + ", " + DateTime.Now + "";
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            //textBox2.PasswordChar = '\u25CF';
            textBox2.PasswordChar = '☻';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Name='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                textBox2.ForeColor = Color.Green;
            else
                textBox2.ForeColor = Color.Red;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Name='" + textBox1.Text + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                textBox1.ForeColor = Color.Green;
            else
                textBox1.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Name='" + textBox1.Text + "' AND Password='" + textBox2.Text + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                UserLogIn.per = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql).Rows[0]["Permission"].ToString();
                UserLogIn.name = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("פרטי המשתמש אינם נכונים");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UserLogIn.per = "3";
            UserLogIn.name = "מנהל";
            this.Close();
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UserLogIn.name == "")
                System.Windows.Forms.Application.Exit();
        }
    }
}
