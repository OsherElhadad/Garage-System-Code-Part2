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
    public partial class DeleteAccount : Form
    {
        public DeleteAccount()
        {
            InitializeComponent();
            comboBox1.Height = 21;
        }
        string ID="";
        string row1;
        public DeleteAccount(string id, string row)
        {
            InitializeComponent();
            row1 = row;
            ID = id;
            comboBox1.Text = ID;
            comboBox1.Height = 21;
            textBox10.Text = row;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה למחוק", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string delete = "UPDATE Accounts SET Active='" + false + "' WHERE AccountNumber='" + comboBox1.Text + "' AND RowNumber='" + row1 + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                MessageBox.Show("מחיקה בוצעה");
                this.Close();

                //מחיקה
                //string delete = "DELETE FROM Accounts WHERE AccountNumber='" + comboBox1.Text + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteAccount f = new DeleteAccount();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Accounts WHERE AccountNumber='" + ID + "' AND RowNumber='" + row1 + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    textBox10.Text = dt.Rows[i]["RowNumber"].ToString();
                    textBox1.Text = dt.Rows[i]["SaleNumber"].ToString();
                    textBox2.Text = dt.Rows[i]["PaymentMethod"].ToString();
                    textBox3.Text = dt.Rows[i]["ItemNumber"].ToString();
                    textBox4.Text = dt.Rows[i]["Amount"].ToString();
                    textBox5.Text = dt.Rows[i]["TotalPrice"].ToString();
                    if (dt.Rows[i]["GarageNumber"].ToString() != "")
                    {
                        label8.Text = "מספר מוסך";
                        textBox6.Text = dt.Rows[i]["GarageNumber"].ToString();
                    }
                    else
                    {
                        label8.Text = "ת.ז לקוח";
                        textBox6.Text = dt.Rows[i]["CustomerID"].ToString();
                    }
                    textBox7.Text = dt.Rows[i]["CarNumber"].ToString();
                    textBox8.Text = dt.Rows[i]["Discount"].ToString();
                    label13.Text = dt.Rows[i]["Date"].ToString();
                    textBox9.Text = dt.Rows[i]["Description"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }
    }
}
