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
    public partial class DeleteEmployee : Form
    {
        public DeleteEmployee()
        {
            InitializeComponent();
            Design.Designer(this);
            comboBox1.Height = 30;
        }
        string ID = "";
        public DeleteEmployee(string id)
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
                string delete = "UPDATE Employees SET Active='" + false + "' WHERE EmployeeID='" + comboBox1.Text + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                MessageBox.Show("מחיקה בוצעה");
                this.Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);

                //מחיקה
                //string delete = "DELETE FROM Employees WHERE EmployeeID='" + ID + "'";
                //MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                //DeleteEmployee f = new DeleteEmployee();
                //f.Show();
                //this.Close();
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT * FROM Employees WHERE EmployeeID='" + ID + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                groupBox1.Visible = true;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sql4 = "SELECT * FROM Cities WHERE ID='" + dt.Rows[i]["EmployeeCity"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                    string sql5 = "SELECT * FROM Roles WHERE Number='" + dt.Rows[i]["Role"].ToString() + "'";
                    DataTable dt5 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                    string sql6 = "SELECT * FROM PrePhone WHERE Number='" + dt.Rows[i]["EmployeePrePhone"].ToString() + "'";
                    DataTable dt6 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql6);

                    textBox2.Text = dt.Rows[i]["EmployeeFName"].ToString();
                    textBox3.Text = dt.Rows[i]["EmployeeLName"].ToString();
                    textBox4.Text = dt4.Rows[0]["Name"].ToString(); ;
                    textBox5.Text = dt.Rows[i]["EmployeeStreet"].ToString();
                    textBox6.Text = dt.Rows[i]["EmployeeHNumber"].ToString();
                    textBox7.Text = dt.Rows[i]["EmployeeZipCode"].ToString();
                    label19.Text = dt6.Rows[0]["Pre"].ToString();
                    textBox9.Text = dt.Rows[i]["EmployeePhone"].ToString();
                    label18.Text = dt.Rows[i]["EmployeeBirthDate"].ToString();
                    textBox10.Text = dt.Rows[i]["EmployeeEmail"].ToString();
                    textBox1.Text = dt5.Rows[0]["Role"].ToString();
                    textBox8.Text = dt.Rows[i]["Notes"].ToString();
                }
            }
            else
                groupBox1.Visible = false;
        }
    }
}
