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
    public partial class DeleteSupplier : Form
    {
        public DeleteSupplier()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        public DeleteSupplier(string id)
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה למחוק", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                ShowOrder f = new ShowOrder("d", comboBox1.Text);
                this.Close();

                //מחיקה
                //string delete = "DELETE FROM Suppliers WHERE SupplierNumber='" + ID + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteSupplier f = new DeleteSupplier();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            string sql1 = "SELECT * FROM Suppliers WHERE SupplierNumber='" + ID + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql4 = "SELECT * FROM Cities WHERE ID='" + dt.Rows[i]["SupplierCity"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                    string sql5 = "SELECT * FROM PreTelephone WHERE Number='" + dt.Rows[i]["SupplierPreTelephone"].ToString() + "'";
                    DataTable dt5 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                    string sql6 = "SELECT * FROM PrePhone WHERE Number='" + dt.Rows[i]["ContactPrePhone"].ToString() + "'";
                    DataTable dt6 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql6);

                    textBox10.Text = dt.Rows[i]["SupplierName"].ToString();
                    textBox1.Text = dt.Rows[i]["ContactFName"].ToString();
                    textBox2.Text = dt.Rows[i]["ContactLName"].ToString();
                    textBox3.Text = dt4.Rows[0]["Name"].ToString();
                    textBox4.Text = dt.Rows[i]["SupplierStreet"].ToString();
                    textBox5.Text = dt.Rows[i]["SupplierHNumber"].ToString();
                    textBox6.Text = dt.Rows[i]["SupplierZipCode"].ToString();
                    label12.Text = dt5.Rows[0]["Pre"].ToString();
                    textBox7.Text = dt.Rows[i]["SupplierTelephone"].ToString();
                    label13.Text = dt6.Rows[0]["Pre"].ToString();
                    textBox8.Text = dt.Rows[i]["ContactPhone"].ToString();
                    textBox9.Text = dt.Rows[i]["SupplierEmail"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }
    }
}
