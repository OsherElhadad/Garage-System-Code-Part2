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
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        public DeleteCustomer(string id)
        {
            InitializeComponent();
            Design.Designer(this);
            ID = id;
            comboBox1.Text = ID;
            comboBox1.Height = 30;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה לצאת מהפעולה", "יציאה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {
                UserLogIn.myforms[UserLogIn.myforms.Count - 1].Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה למחוק", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                ShowCar f = new ShowCar("d", comboBox1.Text, "c");
                this.Close();

                //מחיקה
                //string delete = "DELETE FROM Customers WHERE CustomerID='" + ID + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteCustomer f = new DeleteCustomer();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Customers WHERE CustomerID='" + ID + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql4 = "SELECT * FROM Cities WHERE ID='" + dt.Rows[i]["CustomerCity"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                    string sql5 = "SELECT * FROM PreTelephone WHERE Number='" + dt.Rows[i]["CustomerPreTelephone"].ToString() + "'";
                    DataTable dt5 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                    string sql6 = "SELECT * FROM PrePhone WHERE Number='" + dt.Rows[i]["CustomerPrePhone"].ToString() + "'";
                    DataTable dt6 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql6);

                    textBox1.Text = dt.Rows[i]["CustomerFName"].ToString();
                    textBox3.Text = dt.Rows[i]["CustomerLName"].ToString();
                    textBox4.Text = dt4.Rows[0]["Name"].ToString();
                    textBox5.Text = dt.Rows[i]["CustomerStreet"].ToString();
                    textBox6.Text = dt.Rows[i]["CustomerHNumber"].ToString();
                    textBox7.Text = dt.Rows[i]["CustomerZipCode"].ToString();
                    label14.Text = dt5.Rows[0]["Pre"].ToString();
                    textBox8.Text = dt.Rows[i]["CustomerTelephone"].ToString();
                    label15.Text = dt6.Rows[0]["Pre"].ToString();
                    textBox9.Text = dt.Rows[i]["CustomerPhone"].ToString();
                    label16.Text = dt.Rows[i]["CustomerBirthDate"].ToString();
                    textBox10.Text = dt.Rows[i]["CustomerEmail"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }

    }
}
