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
    public partial class DeleteSale : Form
    {
        public DeleteSale()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        string row1;
        public DeleteSale(string id, string row)
        {
            InitializeComponent();
            Design.Designer(this);
            row1 = row;
            ID = id;
            comboBox1.Text = ID;
            comboBox1.Height = 30;
            textBox7.Text = row;
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

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Sales WHERE SaleNumber='" + ID + "' AND RowNumber='" + row1 + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql4 = "SELECT * FROM PaymentMethods WHERE Number='" + dt.Rows[0]["PaymentMethod"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);

                    textBox7.Text = dt.Rows[i]["RowNumber"].ToString();
                    textBox1.Text = dt.Rows[i]["ItemNumber"].ToString();
                    textBox3.Text = dt.Rows[i]["Amount"].ToString();
                    textBox4.Text = dt.Rows[i]["Price"].ToString();
                    textBox5.Text = dt.Rows[i]["CarNumber"].ToString();
                    textBox2.Text = dt4.Rows[0]["Method"].ToString();
                    textBox6.Text = dt.Rows[i]["Description"].ToString();
                    label10.Text = dt.Rows[i]["StartDate"].ToString();
                    label14.Text = dt.Rows[i]["SupposeEndDate"].ToString();
                    label15.Text = dt.Rows[i]["EndDate"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה למחוק", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                string delete = "UPDATE Sales SET Active2='" + false + "' WHERE SaleNumber='" + comboBox1.Text + "' AND RowNumber='" + row1 + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                MessageBox.Show("מחיקה בוצעה");
                this.Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);

                //מחיקה
                //string delete = "DELETE FROM Sales WHERE SaleNumber='" + comboBox1.Text + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteSale f = new DeleteSale();
                //f.Show();
                //this.Close();
            }
        }
    }
}
