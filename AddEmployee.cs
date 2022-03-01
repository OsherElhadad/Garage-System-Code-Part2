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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetID(textBox1);
            Sets.SetName(textBox2);
            Sets.SetName(textBox3);
            Sets.SetName(textBox4);
            Sets.SetName(textBox5);
            Sets.SetHouseNumber(textBox6);
            Sets.SetZipCode(textBox7);
            Sets.SetPrePhone(comboBox2);
            Sets.SetPhone(textBox9);
            Sets.SetBirthDate(dateTimePicker1);
            Sets.SetEmail(textBox10);
            Sets.SetRole(textBox8);
            Sets.SetNote(textBox11);
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
            AddEmployee f = new AddEmployee();
            FormInPanel.AddForm(Form1.mainp, f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label9.Text == "תקין" && label15.Text == "תקין" && label16.Text == "תקין" && label17.Text == "תקין" && label18.Text == "תקין" && label19.Text == "תקין" && label20.Text == "תקין" && label21.Text == "תקין" && label22.Text == "תקין" && label23.Text == "תקין" && (label24.Text == "תקין" || label24.Text == "") && !string.IsNullOrEmpty(comboBox2.Text))
            {
                string sql = "SELECT * FROM Cities WHERE Name='" + textBox4.Text + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                string sql1 = "SELECT * FROM Roles WHERE Role='" + textBox8.Text + "'";
                DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                string sql2 = "SELECT * FROM PrePhone WHERE Pre='" + comboBox2.Text + "'";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                string insert = "INSERT INTO Employees VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dt.Rows[0]["ID"].ToString() + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + dt2.Rows[0]["Number"].ToString() + "','" + textBox9.Text + "',N'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','" + textBox10.Text + "','" + dt1.Rows[0]["Number"].ToString() + "','" + textBox11.Text + "','" + true + "');";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                MessageBox.Show("עובד נוסף בהצלחה");
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                AddEmployee f = new AddEmployee();
                FormInPanel.AddForm(Form1.mainp, f);
                this.Close();
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Employees WHERE EmployeeID='" + textBox1.Text + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox1.BackColor = Color.Red;
                label9.ForeColor = Color.Red;
                label9.Text = "ת.ז זו קיימת במאגר";
            }
            else
            {
                if (!Checks.IsID(textBox1.Text))
                {
                    textBox1.BackColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    label9.Text = "ת.ז זו לא תקינה";
                }
                else
                {
                    textBox1.BackColor = Color.Green;
                    label9.ForeColor = Color.Green;
                    label9.Text = "תקין";
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox2.Text, 4) || !Checks.NameSofiot(textBox2.Text))
            {
                textBox2.BackColor = Color.Red;
                label15.ForeColor = Color.Red;
                label15.Text = "שם פרטי זה לא תקין";
            }
            else
            {
                textBox2.BackColor = Color.Green;
                label15.ForeColor = Color.Green;
                label15.Text = "תקין";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox3.Text, 4) || !Checks.NameSofiot(textBox3.Text))
            {
                textBox3.BackColor = Color.Red;
                label16.ForeColor = Color.Red;
                label16.Text = "שם משפחה זה לא תקין";
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label16.ForeColor = Color.Green;
                label16.Text = "תקין";
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber !='" + textBox6.Text + "'"))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT EmployeeHnumber, EmployeeZipCode FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber !='" + textBox6.Text + "'");
                string adress = dt.Rows[0]["EmployeeHnumber"].ToString();
                string adress2 = textBox6.Text;
                int zipcode = int.Parse(dt.Rows[0]["EmployeeZipCode"].ToString());
                if (adress[adress.Length - 1] >= 'א' && adress[adress.Length - 1] <= 'ת')
                {
                    adress = adress.Remove(adress.Length - 1);
                }
                if (!string.IsNullOrEmpty(adress2) && adress2[adress2.Length - 1] >= 'א' && adress2[adress2.Length - 1] <= 'ת')
                {
                    adress2 = adress2.Remove(adress2.Length - 1);
                }
                if (string.IsNullOrEmpty(adress2))
                    zipcode = zipcode + -int.Parse(adress);
                else
                    zipcode = zipcode + int.Parse(adress2) - int.Parse(adress);
                textBox7.Text = zipcode.ToString();
                textBox7.ReadOnly = true;
            }
            else
            {
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber ='" + textBox6.Text + "'"))
                {
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT EmployeeHnumber, EmployeeZipCode FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber ='" + textBox6.Text + "'");
                    textBox7.Text = dt.Rows[0]["EmployeeZipCode"].ToString();
                    textBox7.ReadOnly = true;
                }
                else
                {
                    textBox7.ReadOnly = false;
                    textBox7.Text = "";
                }
            }
            string sql = "SELECT * FROM Cities WHERE Name='" + textBox4.Text + "'";
            if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox4.BackColor = Color.Red;
                label17.ForeColor = Color.Red;
                label17.Text = "עיר זו לא תקינה";
            }
            else
            {
                textBox4.BackColor = Color.Green;
                label17.ForeColor = Color.Green;
                label17.Text = "תקין";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber !='" + textBox6.Text + "'"))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT EmployeeHnumber, EmployeeZipCode FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber !='" + textBox6.Text + "'");
                string adress = dt.Rows[0]["EmployeeHnumber"].ToString();
                string adress2 = textBox6.Text;
                int zipcode = int.Parse(dt.Rows[0]["EmployeeZipCode"].ToString());
                if (adress[adress.Length - 1] >= 'א' && adress[adress.Length - 1] <= 'ת')
                {
                    adress = adress.Remove(adress.Length - 1);
                }
                if (!string.IsNullOrEmpty(adress2) && adress2[adress2.Length - 1] >= 'א' && adress2[adress2.Length - 1] <= 'ת')
                {
                    adress2 = adress2.Remove(adress2.Length - 1);
                }
                if (string.IsNullOrEmpty(adress2))
                    zipcode = zipcode + -int.Parse(adress);
                else
                    zipcode = zipcode + int.Parse(adress2) - int.Parse(adress);
                textBox7.Text = zipcode.ToString();
                textBox7.ReadOnly = true;
            }
            else
            {
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber ='" + textBox6.Text + "'"))
                {
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT EmployeeHnumber, EmployeeZipCode FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber ='" + textBox6.Text + "'");
                    textBox7.Text = dt.Rows[0]["EmployeeZipCode"].ToString();
                    textBox7.ReadOnly = true;
                }
                else
                {
                    textBox7.ReadOnly = false;
                    textBox7.Text = "";
                }
            }
            if (!Checks.NameLength(textBox5.Text, 4) || !Checks.NameSofiot(textBox5.Text))
            {
                textBox5.BackColor = Color.Red;
                label18.ForeColor = Color.Red;
                label18.Text = "רחוב זה לא תקין";
            }
            else
            {
                textBox5.BackColor = Color.Green;
                label18.ForeColor = Color.Green;
                label18.Text = "תקין";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber !='" + textBox6.Text + "'"))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT EmployeeHnumber, EmployeeZipCode FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber !='" + textBox6.Text + "'");
                string adress = dt.Rows[0]["EmployeeHnumber"].ToString();
                string adress2 = textBox6.Text;
                int zipcode = int.Parse(dt.Rows[0]["EmployeeZipCode"].ToString());
                if (adress[adress.Length - 1] >= 'א' && adress[adress.Length - 1] <= 'ת')
                {
                    adress = adress.Remove(adress.Length - 1);
                }
                if (!string.IsNullOrEmpty(adress2) && adress2[adress2.Length - 1] >= 'א' && adress2[adress2.Length - 1] <= 'ת')
                {
                    adress2 = adress2.Remove(adress2.Length - 1);
                }
                if (string.IsNullOrEmpty(adress2))
                    zipcode = zipcode + -int.Parse(adress);
                else
                    zipcode = zipcode + int.Parse(adress2) - int.Parse(adress);
                textBox7.Text = zipcode.ToString();
                textBox7.ReadOnly = true;
            }
            else
            {
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber ='" + textBox6.Text + "'"))
                {
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT EmployeeHnumber, EmployeeZipCode FROM Employees WHERE EmployeeCity='" + Checks.GetCityNum(textBox4.Text) + "' AND EmployeeStreet='" + textBox5.Text + "' AND EmployeeHNumber ='" + textBox6.Text + "'");
                    textBox7.Text = dt.Rows[0]["EmployeeZipCode"].ToString();
                    textBox7.ReadOnly = true;
                }
                else
                {
                    textBox7.ReadOnly = false;
                    textBox7.Text = "";
                }
            }
            if (textBox6.Text.Length == 0)
            {
                textBox6.BackColor = Color.Red;
                label19.ForeColor = Color.Red;
                label19.Text = "מספר בית זה לא תקין";
            }
            else
            {
                textBox6.BackColor = Color.Green;
                label19.ForeColor = Color.Green;
                label19.Text = "תקין";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length != 7)
            {
                textBox7.BackColor = Color.Red;
                label20.ForeColor = Color.Red;
                label20.Text = "מיקוד זה לא תקין";
            }
            else
            {
                textBox7.BackColor = Color.Green;
                label20.ForeColor = Color.Green;
                label20.Text = "תקין";
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Red;
                label21.ForeColor = Color.Red;
                label21.Text = "יש לכניס קידומת";
            }
            else
            {
                comboBox2.BackColor = Color.Green;
                label21.ForeColor = Color.Green;
                if (textBox9.Text.Length != 7)
                {
                    textBox9.BackColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label21.Text = "פלאפון זה לא תקין";
                }
                else
                {
                    textBox9.BackColor = Color.Green;
                    label21.ForeColor = Color.Green;
                    label21.Text = "תקין";
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!EmailChecks.CheckEmail(textBox10.Text))
            {
                textBox10.BackColor = Color.Red;
                label22.ForeColor = Color.Red;
                label22.Text = "אימייל זה לא תקין";
            }
            else
            {
                if (!EmailChecks.SendEmail(textBox10.Text, "", ""))
                {
                    textBox10.BackColor = Color.Red;
                    label22.ForeColor = Color.Red;
                    label22.Text = "אימייל זה לא תקין";
                }
                else
                {
                    textBox10.BackColor = Color.Green;
                    label22.ForeColor = Color.Green;
                    label22.Text = "תקין";
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Roles WHERE Role='" + textBox8.Text + "'";
            if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox8.BackColor = Color.Red;
                label23.ForeColor = Color.Red;
                label23.Text = "תפקיד זה לא תקין";
            }
            else
            {
                textBox8.BackColor = Color.Green;
                label23.ForeColor = Color.Green;
                label23.Text = "תקין";
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox11.Text, 10) || !Checks.NameSofiot(textBox11.Text))
            {
                if (textBox11.Text.Length == 0)
                {
                    textBox11.BackColor = Color.Green;
                    label24.ForeColor = Color.Green;
                    label24.Text = "תקין";
                }
                else
                {
                    textBox11.BackColor = Color.Red;
                    label24.ForeColor = Color.Red;
                    label24.Text = "הערות לא תקינות";
                }
            }
            else
            {
                textBox11.BackColor = Color.Green;
                label24.ForeColor = Color.Green;
                label24.Text = "תקין";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Today.AddYears(-100))
            {
                DialogResult r = MessageBox.Show("הלקוח בן יותר ממאה שנים. האם אתה בטוח שאתה רוצה להוסיפו?", "האם אתה בטוח?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    dateTimePicker1.Value = dateTimePicker1.MaxDate;
            }
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            string sql1 = "SELECT distinct Name FROM Cities order by Name";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            textBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox4.DataSource = dt1;
            textBox4.ValueMember = "Name";
            textBox4.Text = "";

            textBox4.BackColor = SystemColors.Window;
            label17.ForeColor = Color.Black;
            label17.Text = "";

            string sql2 = "SELECT distinct Role FROM Roles order by Role";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox8.DataSource = dt2;
            textBox8.ValueMember = "Role";
            textBox8.Text = "";

            textBox8.BackColor = SystemColors.Window;
            label23.ForeColor = Color.Black;
            label23.Text = "";

            string sql3 = "SELECT distinct Pre FROM PrePhone";
            DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.DataSource = dt3;
            comboBox2.ValueMember = "Pre";
            comboBox2.Text = null;

            textBox9.BackColor = SystemColors.Window;
            label21.ForeColor = Color.Black;
            label21.Text = "";
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Red;
                label21.ForeColor = Color.Red;
                label21.Text = "יש לכניס קידומת";
            }
            else
            {
                comboBox2.BackColor = Color.Green;
                label21.ForeColor = Color.Green;
                if (textBox9.Text.Length != 7)
                {
                    textBox9.BackColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label21.Text = "פלאפון זה לא תקין";
                }
                else
                {
                    textBox9.BackColor = Color.Green;
                    label21.ForeColor = Color.Green;
                    label21.Text = "תקין";
                }
            }
        }
    }
}
