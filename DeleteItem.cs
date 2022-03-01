using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OsherProject
{
    public partial class DeleteItem : Form
    {
        public DeleteItem()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        public DeleteItem(string id)
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
                string delete = "UPDATE Items SET Active='" + false + "' WHERE ItemNumber='" + comboBox1.Text + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                string delete2 = "UPDATE Unions SET Active='" + false + "' WHERE ItemNumber='" + comboBox1.Text + "';";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete2);
                MessageBox.Show("מחיקה בוצעה");
                this.Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);

                //מחיקה
                //string delete = "DELETE FROM Items WHERE ItemNumber='" + comboBox1.Text + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteItem f = new DeleteItem();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Items WHERE ItemNumber='" + ID + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[i]["CarType"].ToString() + "'";
                    DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);

                    textBox1.Text = dt.Rows[i]["ItemName"].ToString();
                    textBox3.Text = dt.Rows[i]["Amount"].ToString();
                    textBox6.Text = dt.Rows[i]["Description"].ToString();
                    textBox7.Text = dt2.Rows[0]["Name"].ToString();
                    textBox2.Text = dt.Rows[i]["PriceList"].ToString();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Picture"].ToString()))
                    {
                        byte[] tempimg = (byte[])dt.Rows[i]["Picture"];
                        MemoryStream tempstream = new MemoryStream(tempimg);
                        pictureBox1.Image = Image.FromStream(tempstream);
                        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            else
                groupBox1.Visible = false;
        }
    }
}
