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
    public partial class DeleteCar : Form
    {
        public DeleteCar()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        string t;
        public DeleteCar(string id)
        {
            InitializeComponent();
            Design.Designer(this);
            ID = id;
            comboBox1.Text = ID;
            comboBox1.Height = 30;
        }
        public DeleteCar(string id, string type)
        {
            InitializeComponent();
            Design.Designer(this);
            ID = id;
            t = type;
            comboBox1.Text = ID;
            comboBox1.Height = 30;
            if (t == "c")
                label3.Text = "ת.ז לקוח";
            else
                label3.Text = "מספר מוסך";
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
                string delete = "UPDATE Cars SET Active='" + false + "' WHERE CarNumber='" + comboBox1.Text + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                MessageBox.Show("מחיקה בוצעה");
                this.Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);

                //מחיקה
                //string delete = "DELETE FROM Cars WHERE CarNumber='" + comboBox1.Text + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteCar f = new DeleteCar();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Cars WHERE CarNumber='" + ID + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[i]["CarType"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);

                    if (t == "c")
                        textBox1.Text = dt.Rows[i]["CustomerID"].ToString();
                    else
                        textBox1.Text = dt.Rows[i]["GarageNumber"].ToString();
                    textBox2.Text = dt4.Rows[0]["Name"].ToString();
                    textBox3.Text = dt.Rows[i]["Year"].ToString();
                    label6.Text = "גיר " + dt.Rows[i]["GearType"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }
    }
}
