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
    public partial class AddSale : Form
    {
        public AddSale()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("RowNumber", "מספר שורה");
            dataGridView1.Columns.Add("ItemNumber", "מספר פריט");
            dataGridView1.Columns.Add("ItemName", "שם פריט");
            dataGridView1.Columns.Add("CarNumber", "מספר רכב");
            dataGridView1.Columns.Add("Description", "תיאור");
            dataGridView1.Columns.Add("Amount", "כמות");
            dataGridView1.Columns.Add("Price", "מחיר");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            string sql1 = "SELECT distinct Method FROM PaymentMethods order by Method";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.DataSource = dt1;
            comboBox1.ValueMember = "Method";
            comboBox1.Text = null;

            comboBox1.BackColor = SystemColors.Window;
            label9.ForeColor = Color.Black;
            label9.Text = "";

            string sql2 = "SELECT distinct ItemNumber FROM Items WHERE Active='" + true + "' order by ItemNumber";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox2.DataSource = dt2;
            textBox2.ValueMember = "ItemNumber";
            textBox2.Text = null;

            textBox2.BackColor = SystemColors.Window;
            label13.ForeColor = Color.Black;
            label13.Text = "";

            string sql3 = "SELECT distinct CarNumber FROM Cars WHERE Active='" + true + "' order by CarNumber";
            DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
            textBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox6.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox6.DataSource = dt3;
            textBox6.ValueMember = "CarNumber";
            textBox6.Text = null;

            textBox6.BackColor = SystemColors.Window;
            label17.ForeColor = Color.Black;
            label17.Text = "";

            Design.Designer(this);
            Sets.SetNumber(textBox2);
            Sets.SetNumber(textBox4);
            Sets.SetPrice(textBox5);
            Sets.SetCarNumber(textBox6);
            Sets.SetStartEndDate(dateTimePicker2);
            dateTimePicker2.MinDate = DateTime.Now;
            Sets.SetPayment(comboBox1);
            Sets.SetNote(textBox3);
            string sql = "SELECT SaleNumber FROM Sales ORDER BY SaleNumber";
            Checks.Max(textBox1, "SaleNumber", sql);
            textBox9.Text = "1";
            textBox7.Text = "0.00";
            textBox5.Text = "0.00";
            textBox4.Text = "0";
        }
        string t;
        decimal a = 0;
        public AddSale(string num, string row, string type)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("RowNumber", "מספר שורה");
            dataGridView1.Columns.Add("ItemNumber", "מספר פריט");
            dataGridView1.Columns.Add("ItemName", "שם פריט");
            dataGridView1.Columns.Add("CarNumber", "מספר רכב");
            dataGridView1.Columns.Add("Description", "תיאור");
            dataGridView1.Columns.Add("Amount", "כמות");
            dataGridView1.Columns.Add("Price", "מחיר");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            string sql1 = "SELECT distinct Method FROM PaymentMethods order by Method";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.DataSource = dt1;
            comboBox1.ValueMember = "Method";

            Design.Designer(this);
            Sets.SetNumber(textBox2);
            Sets.SetNumber(textBox4);
            Sets.SetPrice(textBox5);
            Sets.SetCarNumber(textBox6);
            Sets.SetPayment(comboBox1);
            Sets.SetNote(textBox3);
            t = type;
            this.row = int.Parse(row) - 1;
            textBox1.Text = num;
            textBox9.Text = row;
            string sql = "SELECT * FROM Sales WHERE SaleNumber='" + num + "' AND RowNumber='" + row + "'";
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            string sql4 = "SELECT * FROM PaymentMethods WHERE Number='" + dt.Rows[0]["PaymentMethod"].ToString() + "'";
            DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
            dateTimePicker2.Text = dt.Rows[0]["SupposeEndDate"].ToString();
            dateTimePicker2.MinDate = dateTimePicker2.Value;
            string sql5 = "SELECT distinct ItemNumber FROM Items WHERE Active='" + true + "' order by ItemNumber";
            DataTable dt5 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox2.DataSource = dt5;
            textBox2.ValueMember = "ItemNumber";
            textBox2.Text = dt.Rows[0]["ItemNumber"].ToString();
            string sql7 = "SELECT distinct CarNumber FROM Cars WHERE Active='" + true + "' order by CarNumber";
            DataTable dt7 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql7);
            textBox6.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox6.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox6.DataSource = dt7;
            textBox6.ValueMember = "CarNumber";
            textBox6.Text = dt.Rows[0]["CarNumber"].ToString();
            textBox3.Text = dt.Rows[0]["Description"].ToString();
            comboBox1.Text = dt4.Rows[0]["Method"].ToString();
            textBox4.Text = dt.Rows[0]["Amount"].ToString();
            textBox5.Text = dt.Rows[0]["Price"].ToString();
            string sql2 = "SELECT * FROM Sales WHERE SaleNumber='" + num + "'";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string sql3 = "SELECT ItemName FROM Items WHERE ItemNumber='" + dt2.Rows[i]["ItemNumber"].ToString() + "'";
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                dataGridView1.Rows.Insert(dataGridView1.Rows.Count, dt2.Rows[i]["RowNumber"].ToString(), dt2.Rows[i]["ItemNumber"].ToString(), dt3.Rows[0]["ItemName"].ToString(), dt2.Rows[i]["CarNumber"].ToString(), dt2.Rows[i]["Description"].ToString(), dt2.Rows[i]["Amount"].ToString(), dt2.Rows[i]["Price"].ToString(), "מחק");
                a += (decimal)dt2.Rows[i]["Price"];
            }
            textBox7.Text = a.ToString();
            label1.Text = "עדכון מכירה";
            button3.Text = "עדכן";
            button4.Text = "עדכן שורה";
            textBox6.Enabled = false;
            button2.Visible = false;
            if (!Checks.NameLength(textBox3.Text, 10) || !Checks.NameSofiot(textBox3.Text))
            {
                if (textBox3.Text.Length == 0)
                {
                    textBox3.BackColor = Color.Green;
                    label10.ForeColor = Color.Green;
                    label10.Text = "תקין";
                }
                else
                {
                    textBox3.BackColor = Color.Red;
                    label10.ForeColor = Color.Red;
                    label10.Text = "תיאור לא תקין";
                }
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label10.ForeColor = Color.Green;
                label10.Text = "תקין";
            }
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
            AddSale f = new AddSale();
            FormInPanel.AddForm(Form1.mainp, f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && label9.Text == "תקין")
            {
                if (t == "u")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        string sql1 = "SELECT * FROM PaymentMethods WHERE Method='" + comboBox1.Text + "'";
                        DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                        string update = "UPDATE Sales SET ItemNumber='" + dataGridView1[1, i].Value.ToString() + "', Amount='" + dataGridView1[5, i].Value.ToString() + "', Price='" + dataGridView1[6, i].Value.ToString() + "', CarNumber='" + dataGridView1[3, i].Value.ToString() + "', SupposeEndDate=N'" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "', PaymentMethod='" + dt1.Rows[0]["Number"].ToString() + "', Description='" + dataGridView1[4, i].Value.ToString() + "' WHERE SaleNumber='" + textBox1.Text + "' AND RowNumber='" + dataGridView1[0, i].Value.ToString() + "';";
                        MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                    }
                    MessageBox.Show("מכירה עודכנה בהצלחה");
                    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                    this.Close();
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string sql1 = "SELECT * FROM PaymentMethods WHERE Method='" + comboBox1.Text + "'";
                        DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                        string insert = "INSERT INTO Sales VALUES ('" + textBox1.Text + "','" + dataGridView1[0, i].Value.ToString() + "','" + dataGridView1[1, i].Value.ToString() + "','" + dataGridView1[5, i].Value.ToString() + "','" + dataGridView1[6, i].Value.ToString() + "','" + dataGridView1[3, i].Value.ToString() + "',N'" + DateTime.Now.ToString("MM/dd/yyyy") + "',N'" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "',N'" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + dt1.Rows[0]["Number"].ToString() + "','" + dataGridView1[4, i].Value.ToString() + "','" + true + "','" + true + "');";
                        MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                    }
                    MessageBox.Show("מכירה נוספה בהצלחה");
                    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                    AddSale f = new AddSale();
                    FormInPanel.AddForm(Form1.mainp, f);
                    this.Close();
                }
            }
            else
                MessageBox.Show("עליך להוסיף לפחות שורה אחת ולהכניס אמצעי תשלום");

            //if (label9.Text == "תקין" && label10.Text == "תקין" && label13.Text == "תקין" && label17.Text == "תקין")
            //{
            //    string sql1 = "SELECT * FROM PaymentMethods WHERE Method='" + comboBox1.Text + "'";
            //    DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            //    string insert = "INSERT INTO Sales VALUES ('" + textBox1.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "',N'" + DateTime.Now + "',N'" + dateTimePicker2.Value + "','','" + dt1.Rows[0]["Number"].ToString() + "','" + textBox3.Text + "','" + true + "');";
            //    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
            //    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            //    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - int.Parse(textBox4.Text);
            //    if (amount >= 0)
            //    {
            //        MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
            //        string update = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + textBox2.Text + "'";
            //        MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
            //        MessageBox.Show("מכירה נוספה בהצלחה");
            //        UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            //        if (t == "a")
            //        {
            //            AddSale f = new AddSale();
            //            FormInPanel.AddForm(Form1.mainp, f);
            //        }
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("כמות זו של פריט זה לא קיימת במאגר");
            //        DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (r == DialogResult.Yes)
            //        {
            //            AddOrder f = new AddOrder(textBox2.Text);
            //            FormInPanel.AddForm(Form1.mainp, f);
            //        }
            //    }
            //}
            //else
            //    MessageBox.Show("עליך לתקן את הטופס");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Items WHERE ItemNumber='" + textBox2.Text + "' AND Active='True'";
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.BackColor = Color.Red;
                label13.ForeColor = Color.Red;
                label13.Text = "מספר פריט זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox2.BackColor = Color.Red;
                    label13.ForeColor = Color.Red;
                    label13.Text = "מספר פריט זה לא קיים במאגר";
                }
                else
                {
                    textBox2.BackColor = Color.Green;
                    label13.ForeColor = Color.Green;
                    label13.Text = "תקין";
                }
            }
            if (!string.IsNullOrEmpty(textBox4.Text) && label13.Text == "תקין")
            {
                //if (t == "u")
                //{
                //    string sql3 = "SELECT Amount, MinAmount FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
                //    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                //    string sql1 = "SELECT * FROM Sales WHERE SaleNumber='" + textBox1.Text + "' AND RowNumber='" + textBox9.Text + "'";
                //    DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                //    int amountorder = int.Parse(dt2.Rows[0]["Amount"].ToString());
                //    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - 1 - int.Parse(textBox4.Text) + amountorder;
                //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //    {
                //        if (textBox9.Text != (i + 1).ToString() && textBox2.Text == dataGridView1[1, i].Value.ToString())
                //        {
                //            sql1 = "SELECT * FROM Sales WHERE SaleNumber='" + textBox1.Text + "' AND RowNumber='" + dataGridView1[0, i].Value.ToString() + "'";
                //            dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                //            amount = amount - int.Parse(dataGridView1[5, i].Value.ToString()) + int.Parse(dt2.Rows[0]["Amount"].ToString());
                //        }
                //    }
                //    if (amount >= int.Parse(dt.Rows[0]["MinAmount"].ToString()))
                //    {
                //        textBox4.Text = "0";
                //        textBox4.Text = "1";
                //    }
                //    else
                //    {
                //        MessageBox.Show("כמות זו של פריט זה מתחת לכמות המינימום");
                //        DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (r == DialogResult.Yes)
                //        {
                //            AddOrder f = new AddOrder(textBox1.Text);
                //            f.Show();
                //        }
                //    }
                //}
                //else
                //{
                    int amount;
                    string sql2 = "SELECT Amount, MinAmount FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                    amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - 1 - int.Parse(textBox4.Text);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (textBox9.Text != (i + 1).ToString() && textBox2.Text == dataGridView1[1, i].Value.ToString())
                        {
                            amount -= int.Parse(dataGridView1[5, i].Value.ToString());
                        }
                    }
                    if (amount >= int.Parse(dt.Rows[0]["MinAmount"].ToString()))
                    {
                        textBox4.Text = "0";
                        textBox4.Text = "1";
                    }
                    else
                    {
                        MessageBox.Show("כמות זו של פריט זה מתחת לכמות המינימום");
                        DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        textBox2.Text = "";
                        label13.Text = "";
                        textBox2.BackColor = Color.White;
                        if (r == DialogResult.Yes)
                        {
                            AddOrder f = new AddOrder(textBox2.Text);
                            FormInPanel.AddForm(Form1.mainp, f);
                        }
                    }
                //}
            }
            else
                textBox4.Text = "0";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            decimal z = 1;
            string sql = "SELECT PriceList FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
            if (!string.IsNullOrEmpty(textBox4.Text) && int.Parse(textBox4.Text) > 0 && MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                string sql1 = "SELECT * FROM Cars WHERE CarNumber='" + textBox6.Text + "' AND GarageNumber!=''";
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                {
                    DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                    string sql2 = "SELECT * FROM Garages WHERE GarageNumber='" + dt1.Rows[0]["GarageNumber"].ToString() + "'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql2))
                    {
                        DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                        z = 1 - (decimal.Parse(dt2.Rows[0]["Discount"].ToString()) / 100);
                    }
                }
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                decimal x = decimal.Parse(dt.Rows[0]["PriceList"].ToString());
                decimal y = decimal.Parse(textBox4.Text) * x * z;
                textBox5.Text = y.ToString();
                if (dataGridView1.Rows.Count > 0 && !string.IsNullOrEmpty(textBox9.Text) && int.Parse(textBox9.Text) <= dataGridView1.Rows.Count)
                    textBox7.Text = (a + y - decimal.Parse(dataGridView1[6, int.Parse(textBox9.Text) - 1].Value.ToString())).ToString();
                else
                    textBox7.Text = (a + y).ToString();
            }
            else
            {
                textBox5.Text = "0.00";
                textBox7.Text = a.ToString();
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Cars WHERE CarNumber='" + textBox6.Text + "'";
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.BackColor = Color.Red;
                label17.ForeColor = Color.Red;
                label17.Text = "מספר רכב זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox6.BackColor = Color.Red;
                    label17.ForeColor = Color.Red;
                    label17.Text = "מספר רכב זה לא קיים במאגר";
                }
                else
                {
                    textBox6.BackColor = Color.Green;
                    label17.ForeColor = Color.Green;
                    label17.Text = "תקין";
                }
            }
            decimal z = 1;
            string sql3 = "SELECT PriceList FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
            if (!string.IsNullOrEmpty(textBox4.Text) && int.Parse(textBox4.Text) > 0 && MyAdoHelperCsharp.IsExist("Database1.mdf", sql3))
            {
                string sql1 = "SELECT * FROM Cars WHERE CarNumber='" + textBox6.Text + "' AND GarageNumber!=''";
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                {
                    DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                    string sql2 = "SELECT * FROM Garages WHERE GarageNumber='" + dt1.Rows[0]["GarageNumber"].ToString() + "'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql2))
                    {
                        DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                        z = 1 - (decimal.Parse(dt2.Rows[0]["Discount"].ToString()) / 100);
                    }
                }
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                decimal x = decimal.Parse(dt.Rows[0]["PriceList"].ToString());
                decimal y = decimal.Parse(textBox4.Text) * x * z;
                textBox5.Text = y.ToString();
                if (dataGridView1.Rows.Count > 0 && !string.IsNullOrEmpty(textBox9.Text) && int.Parse(textBox9.Text) <= dataGridView1.Rows.Count)
                    textBox7.Text = (a + y - decimal.Parse(dataGridView1[6, int.Parse(textBox9.Text) - 1].Value.ToString())).ToString();
                else
                    textBox7.Text = (a + y).ToString();
            }
            else
            {
                textBox5.Text = "0.00";
                textBox7.Text = a.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((label10.Text == "תקין" || label10.Text == "") && label13.Text == "תקין" && label17.Text == "תקין")
            {
                string sql = "SELECT ItemName FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                if (button4.Text == "הוסף שורה")
                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count, textBox9.Text, textBox2.Text, dt.Rows[0]["ItemName"].ToString(), textBox6.Text, textBox3.Text, textBox4.Text, textBox5.Text, "מחק");
                else
                {
                    button4.Text = "הוסף שורה";
                    dataGridView1[0, row].Value = textBox9.Text;
                    dataGridView1[1, row].Value = textBox2.Text;
                    dataGridView1[2, row].Value = dt.Rows[0]["ItemName"].ToString();
                    dataGridView1[3, row].Value = textBox6.Text;
                    dataGridView1[4, row].Value = textBox3.Text;
                    dataGridView1[5, row].Value = textBox4.Text;
                    dataGridView1[6, row].Value = textBox5.Text;
                }
                textBox9.Text = (dataGridView1.Rows.Count + 1).ToString();
                textBox2.Text = "";
                textBox6.Enabled = false;
                textBox3.Text = "";
                textBox2.BackColor = Color.White;
                textBox4.Text = "0";
                textBox5.Text = "0.00";
                label13.Text = "";
                decimal dec = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dec += decimal.Parse(dataGridView1[6, i].Value.ToString());
                textBox7.Text = dec.ToString();
                a = dec;
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");

            //if (label9.Text == "תקין" && label10.Text == "תקין" && label13.Text == "תקין" && label17.Text == "תקין")
            //{
            //    string sql1 = "SELECT * FROM PaymentMethods WHERE Method='" + comboBox1.Text + "'";
            //    DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            //    string insert = "INSERT INTO Sales VALUES ('" + textBox1.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "',N'" + DateTime.Now + "',N'" + dateTimePicker2.Value + "',NULL,'" + "','" + dt1.Rows[0]["Number"].ToString() + "','" + textBox3.Text + "','" + true + "');";
            //    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
            //    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            //    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - int.Parse(textBox4.Text);
            //    if (amount >= 0)
            //    {
            //        MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
            //        string update = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + textBox2.Text + "'";
            //        MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
            //        MessageBox.Show("מכירה נוספה בהצלחה");
            //        UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            //        if (t == "u")
            //        {
            //            AddSale f = new AddSale(textBox1.Text, textBox9.Text, "u");
            //            FormInPanel.AddForm(Form1.mainp, f);
            //            this.Close();
            //        }
            //        else
            //        {
            //            AddSale f = new AddSale(textBox1.Text, textBox9.Text, "a");
            //            FormInPanel.AddForm(Form1.mainp, f);
            //            this.Close();
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("כמות זו של פריט זה לא קיימת במאגר");
            //        DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (r == DialogResult.Yes)
            //        {
            //            AddOrder f = new AddOrder(textBox2.Text);
            //            FormInPanel.AddForm(Form1.mainp, f);
            //        }
            //    }
            //}
            //else
            //    MessageBox.Show("עליך לתקן את הטופס");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label13.Text == "תקין" && !string.IsNullOrEmpty(textBox4.Text))
            {
                //if (t == "u")
                //{
                //    string sql = "SELECT Amount, MinAmount FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
                //    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                //    string sql1 = "SELECT * FROM Sales WHERE SaleNumber='" + textBox1.Text + "' AND RowNumber='" + textBox9.Text + "'";
                //    DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                //    int amountorder = int.Parse(dt2.Rows[0]["Amount"].ToString());
                //    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - 1 - int.Parse(textBox4.Text) + amountorder;
                //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //    {
                //        if (textBox9.Text != (i + 1).ToString() && textBox2.Text == dataGridView1[1, i].Value.ToString())
                //        {
                //            sql1 = "SELECT * FROM Sales WHERE SaleNumber='" + textBox1.Text + "' AND RowNumber='" + dataGridView1[0, i].Value.ToString() + "'";
                //            dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                //            amount = amount - int.Parse(dataGridView1[5, i].Value.ToString()) + int.Parse(dt2.Rows[0]["Amount"].ToString());
                //        }
                //    }
                //    if (amount >= int.Parse(dt.Rows[0]["MinAmount"].ToString()))
                //        textBox4.Text = (int.Parse(textBox4.Text) + 1).ToString();
                //    else
                //    {
                //        MessageBox.Show("כמות זו של פריט זה מתחת לכמות המינימום");
                //        DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (r == DialogResult.Yes)
                //        {
                //            AddOrder f = new AddOrder(textBox1.Text);
                //            f.Show();
                //        }
                //    }
                //}
                //else
                //{
                    int amount;
                    string sql = "SELECT Amount, MinAmount FROM Items WHERE ItemNumber='" + textBox2.Text + "'";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - 1 - int.Parse(textBox4.Text);
                    if (button4.Text == "הוסף שורה")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (textBox2.Text == dataGridView1[1, i].Value.ToString())
                            {
                                amount -= int.Parse(dataGridView1[5, i].Value.ToString());
                            }
                        }
                    }
                    if (amount >= int.Parse(dt.Rows[0]["MinAmount"].ToString()))
                        textBox4.Text = (int.Parse(textBox4.Text) + 1).ToString();
                    else
                    {
                        MessageBox.Show("כמות זו של פריט זה מתחת לכמות המינימום");
                        DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            AddOrder f = new AddOrder(textBox2.Text);
                            FormInPanel.AddForm(Form1.mainp, f);
                        }
                    }
                //}
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "0" && textBox4.Text != "1" && !string.IsNullOrEmpty(textBox4.Text))
                textBox4.Text = (int.Parse(textBox4.Text) - 1).ToString();
        }

        private void AddSale_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM PaymentMethods WHERE Method='" + comboBox1.Text + "'";
            if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                comboBox1.BackColor = Color.Red;
                label9.ForeColor = Color.Red;
                label9.Text = "אמצצעי תשלום זה לא תקין";
            }
            else
            {
                comboBox1.BackColor = Color.Green;
                label9.ForeColor = Color.Green;
                label9.Text = "תקין";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox3.Text, 10) || !Checks.NameSofiot(textBox3.Text))
            {
                if (textBox3.Text.Length == 0)
                {
                    textBox3.BackColor = Color.Green;
                    label10.ForeColor = Color.Green;
                    label10.Text = "תקין";
                }
                else
                {
                    textBox3.BackColor = Color.Red;
                    label10.ForeColor = Color.Red;
                    label10.Text = "תיאור לא תקין";
                }
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label10.ForeColor = Color.Green;
                label10.Text = "תקין";
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                button4.Text = "הוסף שורה";
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dataGridView1[0, i].Value = i + 1;
                textBox9.Text = (dataGridView1.Rows.Count + 1).ToString();
                if (dataGridView1.Rows.Count > 0)
                    textBox6.Enabled = false;
                else
                    textBox6.Enabled = true;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.BackColor = Color.White;
                textBox4.Text = "0";
                textBox5.Text = "0.00";
                label13.Text = "";
                decimal dec = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dec += decimal.Parse(dataGridView1[6, i].Value.ToString());
                textBox7.Text = dec.ToString();
                a = dec;
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    row = e.RowIndex;
                    button4.Text = "עדכן שורה";
                    textBox9.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                    textBox2.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                    textBox6.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                    textBox3.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                    textBox4.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                    textBox5.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                    decimal dec = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        dec += decimal.Parse(dataGridView1[6, i].Value.ToString());
                    textBox7.Text = dec.ToString();
                    a = dec;
                }
            }
        }
        int row;
        private void button5_Click(object sender, EventArgs e)
        {
            button4.Text = "הוסף שורה";
            textBox9.Text = (dataGridView1.Rows.Count + 1).ToString();
            if (dataGridView1.Rows.Count > 0)
                textBox6.Enabled = false;
            else
                textBox6.Enabled = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox2.BackColor = Color.White;
            textBox4.Text = "0";
            textBox5.Text = "0.00";
            label13.Text = "";
            decimal dec = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dec += decimal.Parse(dataGridView1[6, i].Value.ToString());
            textBox7.Text = dec.ToString();
            a = dec;
        }
    }
}
