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
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
            Sets.SetNumber(textBox1);
            Sets.SetNumber(textBox12);
            Sets.SetNumber(textBox2);
            //Sets.SetPayment(textBox3);
            Sets.SetNumber(textBox4);
            Sets.SetNumber(textBox5);
            Sets.SetPrice(textBox6);
            Sets.SetNumber(textBox7);
            Sets.SetCarNumber(textBox8);
            Sets.SetPrice(textBox9);
            Sets.SetDate(dateTimePicker1);
            Sets.SetNote(textBox10);
            Sets.SetID(textBox11);
            string sql = "SELECT AccountNumber FROM Accounts ORDER BY AccountNumber";
            Checks.Max(textBox1, "AccountNumber", sql);
            textBox12.Text = "1";
            if (!Checks.NameLength(textBox10.Text, 10) || !Checks.NameSofiot(textBox10.Text))
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.BackColor = Color.Green;
                    label24.ForeColor = Color.Green;
                    label24.Text = "תקין";
                }
                else
                {
                    textBox10.BackColor = Color.Red;
                    label24.ForeColor = Color.Red;
                    label24.Text = "תיאור לא תקין";
                }
            }
            else
            {
                textBox10.BackColor = Color.Green;
                label24.ForeColor = Color.Green;
                label24.Text = "תקין";
            }
        }
        string t;
        public AddAccount(string num, string row, string type)
        {
            InitializeComponent();
            Sets.SetNumber(textBox1);
            Sets.SetNumber(textBox12);
            Sets.SetNumber(textBox2);
            //Sets.SetPayment(textBox3);
            Sets.SetNumber(textBox4);
            Sets.SetNumber(textBox5);
            Sets.SetPrice(textBox6);
            Sets.SetNumber(textBox7);
            Sets.SetCarNumber(textBox8);
            Sets.SetPrice(textBox9);
            Sets.SetDate(dateTimePicker1);
            Sets.SetNote(textBox10);
            Sets.SetID(textBox11);
            textBox1.Text = num;
            textBox12.Text = (int.Parse(row) + 1).ToString();
            t = type;
            if (!Checks.NameLength(textBox10.Text, 10) || !Checks.NameSofiot(textBox10.Text))
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.BackColor = Color.Green;
                    label24.ForeColor = Color.Green;
                    label24.Text = "תקין";
                }
                else
                {
                    textBox10.BackColor = Color.Red;
                    label24.ForeColor = Color.Red;
                    label24.Text = "תיאור לא תקין";
                }
            }
            else
            {
                textBox10.BackColor = Color.Green;
                label24.ForeColor = Color.Green;
                label24.Text = "תקין";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAccount f = new AddAccount();
            f.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label16.Text == "תקין" && label17.Text == "תקין" && label18.Text == "תקין" && label19.Text == "תקין" && label20.Text == "תקין" && label21.Text == "תקין" && label22.Text == "תקין" && label23.Text == "תקין" && label24.Text == "תקין" && label25.Text == "תקין")
            {
                string insert = "INSERT INTO Accounts VALUES ('" + textBox1.Text + "','" + textBox12.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "',N'" + dateTimePicker1.Value + "','" + textBox10.Text + "','" + textBox11.Text + "','" + true + "');";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                MessageBox.Show("חשבון נוסף בהצלחה");
                if (t == "a")
                {
                    AddAccount f = new AddAccount();
                    f.Show();
                }
                this.Close();
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Sales WHERE SaleNumber='" + textBox2.Text + "'";
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Red;
                label16.ForeColor = Color.Red;
                label16.Text ="מספר מכירה זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox2.BackColor = Color.Red;
                    label16.ForeColor = Color.Red;
                    label16.Text = "מספר מכירה זה לא קיים במאגר";
                }
                else
                {
                    textBox2.BackColor = Color.Green;
                    label16.ForeColor = Color.Green;
                    label16.Text = "תקין";
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text) || int.Parse(textBox3.Text) == 0)
            {
                textBox3.BackColor = Color.Red;
                label17.ForeColor = Color.Red;
                label17.Text = "אמצעי תשלום זה לא תקין";
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label17.ForeColor = Color.Green;
                label17.Text = "תקין";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Items WHERE ItemNumber='" + textBox4.Text + "'";
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.BackColor = Color.Red;
                label18.ForeColor = Color.Red;
                label18.Text = "מספר פריט זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox4.BackColor = Color.Red;
                    label18.ForeColor = Color.Red;
                    label18.Text = "מספר פריט זה לא קיים במאגר";
                }
                else
                {
                    textBox4.BackColor = Color.Green;
                    label18.ForeColor = Color.Green;
                    label18.Text = "תקין";
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.BackColor = Color.Red;
                label19.ForeColor = Color.Red;
                label19.Text = "כמות זו לא תקינה";
            }
            else
            {
                textBox5.BackColor = Color.Green;
                label19.ForeColor = Color.Green;
                label19.Text = "תקין";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.BackColor = Color.Red;
                label20.ForeColor = Color.Red;
                label20.Text = "מחיר זה לא תקין";
            }
            else
            {
                textBox6.BackColor = Color.Green;
                label20.ForeColor = Color.Green;
                label20.Text = "תקין";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Garages WHERE GarageNumber='" + textBox7.Text + "'";
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.BackColor = Color.Red;
                label21.ForeColor = Color.Red;
                label21.Text = "מספר מוסך זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox7.BackColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label21.Text = "מספר מוסך זה לא קיים במאגר";
                }
                else
                {
                    textBox7.BackColor = Color.Green;
                    label21.ForeColor = Color.Green;
                    label21.Text = "תקין";
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Cars WHERE CarNumber='" + textBox8.Text + "'";
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.BackColor = Color.Red;
                label22.ForeColor = Color.Red;
                label22.Text = "מספר רכב זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox8.BackColor = Color.Red;
                    label22.ForeColor = Color.Red;
                    label22.Text = "מספר רכב זה לא קיים במאגר";
                }
                else
                {
                    textBox8.BackColor = Color.Green;
                    label22.ForeColor = Color.Green;
                    label22.Text = "תקין";
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.BackColor = Color.Red;
                label23.ForeColor = Color.Red;
                label23.Text = "מחיר זה לא תקין";
            }
            else
            {
                textBox9.BackColor = Color.Green;
                label23.ForeColor = Color.Green;
                label23.Text = "תקין";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox10.Text, 10) || !Checks.NameSofiot(textBox10 .Text))
            {
                if (textBox10.Text.Length == 0)
                {
                    textBox10.BackColor = Color.Green;
                    label24.ForeColor = Color.Green;
                    label24.Text = "תקין";
                }
                else
                {
                    textBox10.BackColor = Color.Red;
                    label24.ForeColor = Color.Red;
                    label24.Text = "תיאור לא תקין";
                }
            }
            else
            {
                textBox10.BackColor = Color.Green;
                label24.ForeColor = Color.Green;
                label24.Text = "תקין";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Customers WHERE CustomerID='" + textBox11.Text + "'";
            if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox11.BackColor = Color.Red;
                label25.ForeColor = Color.Red;
                label25.Text = "ת.ז זו לא קיימת במאגר";
            }
            else
            {
                textBox11.BackColor = Color.Green;
                label25.ForeColor = Color.Green;
                label25.Text = "תקין";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label16.Text == "תקין" && label17.Text == "תקין" && label18.Text == "תקין" && label19.Text == "תקין" && label20.Text == "תקין" && label21.Text == "תקין" && label22.Text == "תקין" && label23.Text == "תקין" && label24.Text == "תקין" && label25.Text == "תקין")
            {
                string insert = "INSERT INTO Accounts VALUES ('" + textBox1.Text + "','" + textBox12.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "',N'" + dateTimePicker1.Value + "','" + textBox10.Text + "','" + textBox11.Text + "','" + true + "');";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                MessageBox.Show("שורה נוספה בהצלחה");
                if (t == "u")
                {
                    AddAccount f = new AddAccount(textBox1.Text, textBox12.Text, "u");
                    f.Show();
                    this.Close();
                }
                else
                {
                    AddAccount f = new AddAccount(textBox1.Text, textBox12.Text, "a");
                    f.Show();
                    this.Close();
                }
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
        }
    }
}
