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
    public partial class Mail : Form
    {
        Translate tran1 = new Translate();
        public Mail()
        {
            InitializeComponent();
            Design.Designer(this);
            tran1.Add("Customers", "לקוחות", "CustomerID", "CustomerFName", "CustomerEmail", "ת.ז לקוח");
            tran1.Add("Employees", "עובדים", "EmployeeID", "EmployeeFName", "EmployeeEmail", "ת.ז עובד");
            tran1.Add("Garages", "מוסכים", "GarageNumber", "GarageName", "GarageEmail", "מספר מוסך");
            tran1.Add("Suppliers", "ספקים", "SupplierNumber", "SupplierName", "SupplierEmail", "מספר ספק");

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            for (int i = 0; i < tran1.Returnheb().Count; i++)
            {
                comboBox1.Items.Add(tran1.Returnheb()[i]);
            }
            comboBox1.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                string sql1 = "SELECT distinct " + tran1.FindCol(comboBox1.Text) + " FROM " + tran1.Find(comboBox1.Text) + " order by " + tran1.FindCol(comboBox1.Text);
                comboBox2.Items.Clear();
                comboBox2.ValueMember = "";
                comboBox2.Text = "";
                DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt1.Rows[i][0].ToString());
                }
                comboBox2.Text = null;
                textBox1.Text = "";
                string sql2 = "SELECT " + tran1.FindCol(comboBox1.Text) + " AS '" + tran1.Findheb(comboBox1.Text) + "' , " + tran1.FindCol2(comboBox1.Text) + " AS 'שם' , " + tran1.FindCol3(comboBox1.Text) + " AS 'אימייל' FROM " + tran1.Find(comboBox1.Text) + " order by " + tran1.FindCol(comboBox1.Text);
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql2))
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                }
                else
                    dataGridView1.Visible = false;
            }
            else
            {
                textBox1.Text = "";
                comboBox2.Text = null;
                dataGridView1.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                comboBox2.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                textBox1.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            }
            else
                MessageBox.Show("עליך להקליק על אחד מהשורות המלאות");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string email = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1[0, i].Value.ToString() == comboBox2.Text)
                    email = dataGridView1[2, i].Value.ToString();
            }
            textBox1.Text = email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
            {
                if (EmailChecks.CheckEmail(textBox1.Text) && EmailChecks.SendEmail(textBox1.Text, textBox2.Text, richTextBox1.Text))
                    MessageBox.Show("המייל נשלח");
                else
                    MessageBox.Show("המייל אינו תקין");
            }
            else
                MessageBox.Show("עליך להכניס כתובת מייל ולמלא את ההודעה");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (EmailChecks.CheckEmail(textBox1.Text))
                textBox1.ForeColor = Color.Green;
            else
                textBox1.ForeColor = Color.Red;
        }
    }
}
