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
    public partial class DynamicComboBox : Form
    {
        Translate tran1 = new Translate();
        Translate tran2 = new Translate();
        public DynamicComboBox()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetGeneral(comboBox1);
            Sets.SetGeneral(comboBox2);
            Sets.SetGeneral(comboBox3);
            Sets.SetGeneral(textBox1);
            Sets.SetGeneral(textBox2);
            tran1.Add("CarTypes", "סוגי רכבים", "Name");
            tran1.Add("Cities", "ערים", "Name");
            tran1.Add("PaymentMethods", "אמצעי תשלום", "Method");
            tran1.Add("PrePhone", "קידומת פלאפון", "Pre");
            tran1.Add("PreTelephone", "קידומת טלפון", "Pre");
            tran1.Add("Roles", "תפקידים", "Role");

            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            for (int i = 0; i < tran1.Returnheb().Count; i++)
            {
                comboBox1.Items.Add(tran1.Returnheb()[i]);
            }
            comboBox1.Text = null;

            tran2.Add("CarTypes", "סוגי רכבים", "Name");
            tran2.Add("Cities", "ערים", "Name");
            tran2.Add("PaymentMethods", "אמצעי תשלום", "Method");
            tran2.Add("PrePhone", "קידומת פלאפון", "Pre");
            tran2.Add("PreTelephone", "קידומת טלפון", "Pre");
            tran2.Add("Roles", "תפקידים", "Role");

            comboBox3.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;
            for (int i = 0; i < tran2.Returnheb().Count; i++)
            {
                comboBox3.Items.Add(tran2.Returnheb()[i]);
            }
            comboBox3.Text = null;
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
            }
            else
                comboBox2.Text = null;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox3.Text = null;
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !comboBox2.Items.Contains(textBox1.Text) && comboBox1.Items.Contains(comboBox1.Text) && comboBox2.Items.Contains(comboBox2.Text))
            {
                string update = "UPDATE " + tran1.Find(comboBox1.Text) + " SET " + tran1.FindCol(comboBox1.Text) + "='" + textBox1.Text + "' WHERE " + tran1.FindCol(comboBox1.Text) + "='" + comboBox2.Text + "'";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                MessageBox.Show("הערך עודכן בהצלחה");
                comboBox2.Items.Clear();
                comboBox1.Text = null;
                comboBox2.Text = null;
                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("עליך לבחור את שם הטבלה ואת שם הערך");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox1.Text) && comboBox2.Items.Contains(comboBox2.Text))
            {
                if (comboBox2.Items.Contains(textBox1.Text))
                    textBox1.ForeColor = Color.Red;
                else
                    textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.ForeColor == Color.Green && comboBox3.Items.Contains(comboBox3.Text))
            {
                string insert = "INSERT INTO " + tran2.Find(comboBox3.Text) + " VALUES ('" + Checks.Max2("SELECT * FROM " + tran2.Find(comboBox3.Text)) + "','" + textBox2.Text + "')";
                MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                MessageBox.Show("הערך הוסף בהצלחה");
                comboBox3.Text = null;
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("עליך לבחור את שם הטבלה ולהכניס את שם הערך");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Items.Contains(comboBox3.Text))
            {
                string sql1 = "SELECT distinct " + tran2.FindCol(comboBox3.Text) + " FROM " + tran2.Find(comboBox3.Text) + " order by " + tran2.FindCol(comboBox3.Text);
                DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                List<string> l = new List<string>();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    l.Add(dt1.Rows[i][0].ToString());
                }
                if (l.Contains(textBox2.Text))
                    textBox2.ForeColor = Color.Red;
                else
                    textBox2.ForeColor = Color.Green;
            }
            else
            {
                textBox2.ForeColor = Color.Red;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
