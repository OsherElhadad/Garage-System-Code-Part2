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
    public partial class DeleteOrder : Form
    {
        public DeleteOrder()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        string row1;
        public DeleteOrder(string id, string row)
        {
            InitializeComponent();
            Design.Designer(this);
            row1 = row;
            ID = id;
            comboBox1.Text = ID;
            comboBox1.Height = 30;
            textBox6.Text = row;
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
                string delete = "UPDATE Orders SET Active2='" + false + "' WHERE OrderNumber='" + comboBox1.Text + "' AND RowNumber='" + row1 + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                MessageBox.Show("מחיקה בוצעה");
                this.Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);

                //מחיקה
                //string delete = "DELETE FROM Orders WHERE OrderNumber='" + comboBox1.Text + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteOrder f = new DeleteOrder();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Orders WHERE OrderNumber='" + ID + "' AND RowNumber='" + row1 + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    textBox6.Text = dt.Rows[i]["RowNumber"].ToString();
                    label3.Text = dt.Rows[i]["StartDate"].ToString();
                    label14.Text = dt.Rows[i]["SupposeEndDate"].ToString();
                    label15.Text = dt.Rows[i]["EndDate"].ToString();
                    textBox3.Text = dt.Rows[i]["ItemNumber"].ToString();
                    textBox4.Text = dt.Rows[i]["Amount"].ToString();
                    textBox5.Text = dt.Rows[i]["SupplierNumber"].ToString();
                    textBox2.Text = dt.Rows[i]["Price"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }
    }
}
