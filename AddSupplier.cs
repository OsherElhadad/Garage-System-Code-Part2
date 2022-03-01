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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetName(textBox1);
            Sets.SetName(textBox2);
            Sets.SetName(textBox3);
            Sets.SetName(textBox4);
            Sets.SetName(textBox5);
            Sets.SetHouseNumber(textBox6);
            Sets.SetZipCode(textBox7);
            Sets.SetPrePhone(comboBox1);
            Sets.SetPhone(textBox8);
            Sets.SetPrePhone(comboBox2);
            Sets.SetPhone(textBox9);
            Sets.SetEmail(textBox10);
            string sql = "SELECT SupplierNumber FROM Suppliers ORDER BY SupplierNumber";
            Checks.Max(textBox11, "SupplierNumber", sql);
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
            AddSupplier f = new AddSupplier();
            FormInPanel.AddForm(Form1.mainp, f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label12.Text == "תקין" && label13.Text == "תקין" && label14.Text == "תקין" && label15.Text == "תקין" && label16.Text == "תקין" && label17.Text == "תקין" && label18.Text == "תקין" && label19.Text == "תקין" && label20.Text == "תקין" && label21.Text == "תקין" && !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
            {
                string sql1 = "SELECT * FROM Cities WHERE Name='" + textBox4.Text + "'";
                DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                string sql2 = "SELECT * FROM PreTelephone WHERE Pre='" + comboBox1.Text + "'";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                string sql3 = "SELECT * FROM PrePhone WHERE Pre='" + comboBox2.Text + "'";
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                string sql = "SELECT SupplierNumber FROM Suppliers ORDER BY SupplierNumber";
                string insert = "INSERT INTO Suppliers VALUES ('" + Checks.Max(textBox11, "SupplierNumber", sql) + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dt1.Rows[0]["ID"].ToString() + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + dt2.Rows[0]["Number"].ToString() + "','" + textBox8.Text + "','" + dt3.Rows[0]["Number"].ToString() + "','" + textBox9.Text + "','" + textBox10.Text + "','" + true + "');";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                MessageBox.Show("ספק נוסף בהצלחה");
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                AddSupplier f = new AddSupplier();
                FormInPanel.AddForm(Form1.mainp, f);
                this.Close();
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox1.Text, 4) || !Checks.NameSofiot(textBox1.Text))
            {
                textBox1.BackColor = Color.Red;
                label12.ForeColor = Color.Red;
                label12.Text = "שם ספק זה לא תקין";
            }
            else
            {
                textBox1.BackColor = Color.Green;
                label12.ForeColor = Color.Green;
                label12.Text = "תקין";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox2.Text, 4) || !Checks.NameSofiot(textBox2.Text))
            {
                textBox2.BackColor = Color.Red;
                label13.ForeColor = Color.Red;
                label13.Text = "שם פרטי זה לא תקין";
            }
            else
            {
                textBox2.BackColor = Color.Green;
                label13.ForeColor = Color.Green;
                label13.Text = "תקין";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox3.Text, 4) || !Checks.NameSofiot(textBox3.Text))
            {
                textBox3.BackColor = Color.Red;
                label14.ForeColor = Color.Red;
                label14.Text = "שם משפחה זה לא תקין";
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label14.ForeColor = Color.Green;
                label14.Text = "תקין";
            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'"))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT SupplierHnumber, SupplierZipCode FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'");
                string adress = dt.Rows[0]["SupplierHnumber"].ToString();
                string adress2 = textBox6.Text;
                int zipcode = int.Parse(dt.Rows[0]["SupplierZipCode"].ToString());
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
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber ='" + textBox6.Text + "'"))
                {
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT SupplierHnumber, SupplierZipCode FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'");
                    textBox7.Text = dt.Rows[0]["SupplierZipCode"].ToString();
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
                label15.ForeColor = Color.Red;
                label15.Text = "עיר זו לא תקינה";
            }
            else
            {
                textBox4.BackColor = Color.Green;
                label15.ForeColor = Color.Green;
                label15.Text = "תקין";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'"))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT SupplierHnumber, SupplierZipCode FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'");
                string adress = dt.Rows[0]["SupplierHnumber"].ToString();
                string adress2 = textBox6.Text;
                int zipcode = int.Parse(dt.Rows[0]["SupplierZipCode"].ToString());
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
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber ='" + textBox6.Text + "'"))
                {
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT SupplierHnumber, SupplierZipCode FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'");
                    textBox7.Text = dt.Rows[0]["SupplierZipCode"].ToString();
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
                label16.ForeColor = Color.Red;
                label16.Text = "רחוב זה לא תקין";
            }
            else
            {
                textBox5.BackColor = Color.Green;
                label16.ForeColor = Color.Green;
                label16.Text = "תקין";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text) && MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'"))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT SupplierHnumber, SupplierZipCode FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber !='" + textBox6.Text + "'");
                string adress = dt.Rows[0]["SupplierHnumber"].ToString();
                string adress2 = textBox6.Text;
                int zipcode = int.Parse(dt.Rows[0]["SupplierZipCode"].ToString());
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
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", "SELECT * FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber ='" + textBox6.Text + "'"))
                {
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", "SELECT SupplierHnumber, SupplierZipCode FROM Suppliers WHERE SupplierCity='" + Checks.GetCityNum(textBox4.Text) + "' AND SupplierStreet='" + textBox5.Text + "' AND SupplierHNumber ='" + textBox6.Text + "'");
                    textBox7.Text = dt.Rows[0]["SupplierZipCode"].ToString();
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
                label17.ForeColor = Color.Red;
                label17.Text = "מספר בית זה לא תקין";
            }
            else
            {
                textBox6.BackColor = Color.Green;
                label17.ForeColor = Color.Green;
                label17.Text = "תקין";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text.Length != 7)
            {
                textBox7.BackColor = Color.Red;
                label18.ForeColor = Color.Red;
                label18.Text = "מיקוד זה לא תקין";
            }
            else
            {
                textBox7.BackColor = Color.Green;
                label18.ForeColor = Color.Green;
                label18.Text = "תקין";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.BackColor = Color.Red;
                label19.ForeColor = Color.Red;
                label19.Text = "יש לכניס קידומת";
            }
            else
            {
                comboBox1.BackColor = Color.Green;
                label19.ForeColor = Color.Green;
                if (textBox8.Text.Length != 7)
                {
                    textBox8.BackColor = Color.Red;
                    label19.ForeColor = Color.Red;
                    label19.Text = "טלפון זה לא תקין";
                }
                else
                {
                    textBox8.BackColor = Color.Green;
                    label19.ForeColor = Color.Green;
                    label19.Text = "תקין";
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Red;
                label20.ForeColor = Color.Red;
                label20.Text = "יש לכניס קידומת";
            }
            else
            {
                comboBox2.BackColor = Color.Green;
                label20.ForeColor = Color.Green;
                if (textBox9.Text.Length != 7)
                {
                    textBox9.BackColor = Color.Red;
                    label20.ForeColor = Color.Red;
                    label20.Text = "פלאפון זה לא תקין";
                }
                else
                {
                    textBox9.BackColor = Color.Green;
                    label20.ForeColor = Color.Green;
                    label20.Text = "תקין";
                }
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (!EmailChecks.CheckEmail(textBox10.Text))
            {
                textBox10.BackColor = Color.Red;
                label21.ForeColor = Color.Red;
                label21.Text = "אימייל זה לא תקין";
            }
            else
            {
                if (!EmailChecks.SendEmail(textBox10.Text, "", ""))
                {
                    textBox10.BackColor = Color.Red;
                    label21.ForeColor = Color.Red;
                    label21.Text = "אימייל זה לא תקין";
                }
                else
                {
                    textBox10.BackColor = Color.Green;
                    label21.ForeColor = Color.Green;
                    label21.Text = "תקין";
                }
            }
        }

        private void AddSupplier_Load(object sender, EventArgs e)
        {
            string sql1 = "SELECT distinct Name FROM Cities order by Name";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            textBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox4.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox4.DataSource = dt1;
            textBox4.ValueMember = "Name";
            textBox4.Text = "";

            textBox4.BackColor = SystemColors.Window;
            label15.ForeColor = Color.Black;
            label15.Text = "";

            string sql2 = "SELECT distinct Pre FROM PreTelephone";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.DataSource = dt2;
            comboBox1.ValueMember = "Pre";
            comboBox1.Text = null;

            textBox8.BackColor = SystemColors.Window;
            label19.ForeColor = Color.Black;
            label19.Text = "";

            string sql3 = "SELECT distinct Pre FROM PrePhone";
            DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.DataSource = dt3;
            comboBox2.ValueMember = "Pre";
            comboBox2.Text = null;

            textBox9.BackColor = SystemColors.Window;
            label20.ForeColor = Color.Black;
            label20.Text = "";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.BackColor = Color.Red;
                label19.ForeColor = Color.Red;
                label19.Text = "יש לכניס קידומת";
            }
            else
            {
                comboBox1.BackColor = Color.Green;
                label19.ForeColor = Color.Green;
                if (textBox8.Text.Length != 7)
                {
                    textBox8.BackColor = Color.Red;
                    label19.ForeColor = Color.Red;
                    label19.Text = "טלפון זה לא תקין";
                }
                else
                {
                    textBox8.BackColor = Color.Green;
                    label19.ForeColor = Color.Green;
                    label19.Text = "תקין";
                }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Red;
                label20.ForeColor = Color.Red;
                label20.Text = "יש לכניס קידומת";
            }
            else
            {
                comboBox2.BackColor = Color.Green;
                label20.ForeColor = Color.Green;
                if (textBox9.Text.Length != 7)
                {
                    textBox9.BackColor = Color.Red;
                    label20.ForeColor = Color.Red;
                    label20.Text = "פלאפון זה לא תקין";
                }
                else
                {
                    textBox9.BackColor = Color.Green;
                    label20.ForeColor = Color.Green;
                    label20.Text = "תקין";
                }
            }
        }
    }
}
