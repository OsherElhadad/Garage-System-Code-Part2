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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetCarNumber(textBox1);
            Sets.SetID(textBox2);
            Sets.SetGeneral(textBox3);
            Sets.SetCarModel(dateTimePicker1);
        }
        string t;
        string ID = "";
        public AddCar(string type)
        {
            InitializeComponent();
            Design.Designer(this);
            t = type;
            Sets.SetCarNumber(textBox1);
            if (type == "c")
            {
                Sets.SetID(textBox2);
                label3.Text = "ת.ז לקוח";
            }
            else
            {
                Sets.SetNumber(textBox2);
                label3.Text = "מספר מוסך";
            }
            Sets.SetCarModel(dateTimePicker1);
            Sets.SetGeneral(textBox3);
        }
        public AddCar(string type, string id)
        {
            InitializeComponent();
            Design.Designer(this);
            t = type;
            ID = id;
            Sets.SetCarNumber(textBox1);
            if (type == "c")
            {
                Sets.SetID(textBox2);
                label3.Text = "ת.ז לקוח";
            }
            else
            {
                Sets.SetNumber(textBox2);
                label3.Text = "מספר מוסך";
            }
            Sets.SetCarModel(dateTimePicker1);
            Sets.SetGeneral(textBox3);
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
            UserLogIn.myforms[UserLogIn.myforms.Count - 1].Close();
            UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            AddCar f = new AddCar(t);
            FormInPanel.AddForm(Form1.mainp, f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label6.Text == "תקין" && label7.Text == "תקין" && label8.Text == "תקין")
            {
                string sql = "SELECT * FROM CarTypes WHERE Name='" + textBox3.Text + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                string insert = "INSERT INTO Cars VALUES ('" + textBox1.Text + "','";
                if (t == "c")
                    insert += textBox2.Text + "','";
                else
                    insert += "','";
                insert += dt.Rows[0]["ID"].ToString() + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','";
                if (radioButton1.Checked)
                    insert += "ידני";
                else
                    insert += "אוטומט";
                if (t == "g")
                    insert += "','" + textBox2.Text;
                else
                    insert += "','";
                insert += "','" + true;
                insert += "');";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                MessageBox.Show("מכונית נוספה בהצלחה");
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                AddCar f = new AddCar(t);
                FormInPanel.AddForm(Form1.mainp, f);
                this.Close();
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Cars WHERE CarNumber='" + textBox1.Text + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox1.BackColor = Color.Red;
                label6.ForeColor = Color.Red;
                label6.Text = "מספר רכב זה קיים במאגר";
            }
            else
            {
                if (textBox1.Text.Length != 9)
                {
                    textBox1.BackColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    label6.Text = "מספר רכב זה לא תקין";
                }
                else
                {
                    textBox1.BackColor = Color.Green;
                    label6.ForeColor = Color.Green;
                    label6.Text = "תקין";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (t == "c")
            {
                string sql = "SELECT * FROM Customers WHERE CustomerID='" + textBox2.Text + "'";
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox2.BackColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label7.Text = "ת.ז זו לא קיימת במאגר";
                }
                else
                {
                    textBox2.BackColor = Color.Green;
                    label7.ForeColor = Color.Green;
                    label7.Text = "תקין";
                }
            }
            else
            {
                string sql = "SELECT * FROM Garages WHERE GarageNumber='" + textBox2.Text + "'";
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.BackColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    label7.Text = "מספר מוסך זה לא תקין";
                }
                else
                {
                    if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                    {
                        textBox2.BackColor = Color.Red;
                        label7.ForeColor = Color.Red;
                        label7.Text = "מספר מוסך זה לא קיים במאגר";
                    }
                    else
                    {
                        textBox2.BackColor = Color.Green;
                        label7.ForeColor = Color.Green;
                        label7.Text = "תקין";
                    }
                }
            }
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CarTypes WHERE Name='" + textBox3.Text + "'";
            if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox3.BackColor = Color.Red;
                label8.ForeColor = Color.Red;
                label8.Text = "סוג זה לא תקין";
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label8.ForeColor = Color.Green;
                label8.Text = "תקין";
            }
        }

        private void AddCar_Load(object sender, EventArgs e)
        {
            string sql2 = "SELECT distinct Name FROM CarTypes order by Name";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            textBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox3.DataSource = dt2;
            textBox3.ValueMember = "Name";
            textBox3.Text = "";

            textBox3.BackColor = SystemColors.Window;
            label8.ForeColor = Color.Black;
            label8.Text = "";

            string sql1;
            if (t == "c")
                sql1 = "SELECT distinct CustomerID FROM Customers order by CustomerID";
            else
                sql1 = "SELECT distinct GarageNumber FROM Garages order by GarageNumber";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox2.DataSource = dt1;
            if (t == "c")
                textBox2.ValueMember = "CustomerID";
            else
                textBox2.ValueMember = "GarageNumber";
            textBox2.Text = ID;
            if (string.IsNullOrEmpty(ID))
            {
                textBox2.BackColor = SystemColors.Window;
                label7.ForeColor = Color.Black;
                label7.Text = "";
            }
        }
    }
}
