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
    public partial class AddOrder : Form
    {
        public AddOrder()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("RowNumber", "מספר שורה");
            dataGridView1.Columns.Add("ItemNumber", "מספר פריט");
            dataGridView1.Columns.Add("ItemName", "שם פריט");
            dataGridView1.Columns.Add("SupplierNumer", "מספר ספק");
            dataGridView1.Columns.Add("Amount", "כמות");
            dataGridView1.Columns.Add("Price", "מחיר");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            string sql2 = "SELECT distinct ItemNumber FROM Items WHERE Active='" + true + "' order by ItemNumber";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox5.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox5.DataSource = dt2;
            textBox5.ValueMember = "ItemNumber";
            textBox5.Text = null;

            textBox5.BackColor = SystemColors.Window;
            label15.ForeColor = Color.Black;
            label15.Text = "";

            textBox7.BackColor = SystemColors.Window;
            label17.ForeColor = Color.Black;
            label17.Text = "";

            Design.Designer(this);
            Sets.SetNumber(textBox1);
            Sets.SetNumber(textBox8);
            Sets.SetStartEndDate(dateTimePicker2);
            dateTimePicker2.MinDate = DateTime.Now;
            Sets.SetNumber(textBox5);
            Sets.SetNumber(textBox6);
            Sets.SetNumber(textBox7);
            string sql = "SELECT OrderNumber FROM Orders ORDER BY OrderNumber";
            Checks.Max(textBox1, "OrderNumber", sql);
            textBox8.Text = "1";
            textBox6.Text = "0";
            textBox3.Text = "0.00";
            textBox2.Text = "0.00";
        }

        public AddOrder(string itemnum)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("RowNumber", "מספר שורה");
            dataGridView1.Columns.Add("ItemNumber", "מספר פריט");
            dataGridView1.Columns.Add("ItemName", "שם פריט");
            dataGridView1.Columns.Add("SupplierNumer", "מספר ספק");
            dataGridView1.Columns.Add("Amount", "כמות");
            dataGridView1.Columns.Add("Price", "מחיר");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            Design.Designer(this);
            Sets.SetNumber(textBox1);
            Sets.SetNumber(textBox8);
            Sets.SetStartEndDate(dateTimePicker2);
            dateTimePicker2.MinDate = DateTime.Now;
            Sets.SetNumber(textBox5);
            Sets.SetNumber(textBox6);
            Sets.SetNumber(textBox7);
            string sql = "SELECT OrderNumber FROM Orders ORDER BY OrderNumber";
            Checks.Max(textBox1, "OrderNumber", sql);
            textBox8.Text = "1";
            textBox6.Text = "0";
            textBox3.Text = "0.00";
            textBox2.Text = "0.00";
            string sql2 = "SELECT distinct ItemNumber FROM Items WHERE Active='" + true + "' order by ItemNumber";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox5.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox5.DataSource = dt2;
            textBox5.ValueMember = "ItemNumber";
            textBox5.Text = itemnum;
        }
        string t;
        decimal a = 0;
        public AddOrder(string num, string row, string type)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("RowNumber", "מספר שורה");
            dataGridView1.Columns.Add("ItemNumber", "מספר פריט");
            dataGridView1.Columns.Add("ItemName", "שם פריט");
            dataGridView1.Columns.Add("SupplierNumer", "מספר ספק");
            dataGridView1.Columns.Add("Amount", "כמות");
            dataGridView1.Columns.Add("Price", "מחיר");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            Design.Designer(this);
            Sets.SetNumber(textBox1);
            Sets.SetNumber(textBox8);
            Sets.SetNumber(textBox5);
            Sets.SetNumber(textBox6);
            Sets.SetNumber(textBox7);
            t = type;
            this.row = int.Parse(row) - 1;
            textBox1.Text = num;
            textBox8.Text = row;
            string sql = "SELECT * FROM Orders WHERE OrderNumber='" + num + "' AND RowNumber='" + row + "'";
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            dateTimePicker2.Text = dt.Rows[0]["SupposeEndDate"].ToString();
            dateTimePicker2.MinDate = dateTimePicker2.Value;
            string sql5 = "SELECT distinct ItemNumber FROM Items WHERE Active='" + true + "' order by ItemNumber";
            DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
            textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox5.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox5.DataSource = dt4;
            textBox5.ValueMember = "ItemNumber";
            textBox5.Text = dt.Rows[0]["ItemNumber"].ToString();
            textBox7.Text = dt.Rows[0]["SupplierNumber"].ToString();
            textBox6.Text = dt.Rows[0]["Amount"].ToString();
            textBox3.Text = dt.Rows[0]["Price"].ToString();
            string sql2 = "SELECT * FROM Orders WHERE OrderNumber='" + num + "'";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                string sql3 = "SELECT ItemName FROM Items WHERE ItemNumber='" + dt2.Rows[i]["ItemNumber"].ToString() + "'";
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                dataGridView1.Rows.Insert(dataGridView1.Rows.Count, dt2.Rows[i]["RowNumber"].ToString(), dt2.Rows[i]["ItemNumber"].ToString(), dt3.Rows[0]["ItemName"].ToString(), dt2.Rows[i]["SupplierNumber"].ToString(), dt2.Rows[i]["Amount"].ToString(), dt2.Rows[i]["Price"].ToString(), "מחק");
                a += (decimal)dt2.Rows[i]["Price"];
            }
            textBox2.Text = a.ToString();
            label1.Text = "עדכון הזמנה";
            button3.Text = "עדכן";
            button4.Text = "עדכן שורה";
            button2.Visible = false;
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
            AddOrder f = new AddOrder();
            FormInPanel.AddForm(Form1.mainp, f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (t == "u")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string sql1 = "SELECT * FROM Orders WHERE OrderNumber='" + textBox1.Text + "' AND RowNumber='" + dataGridView1[0, i].Value.ToString() + "'";
                        DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                        string update = "UPDATE Orders SET SupposeEndDate=N'" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "', ItemNumber='" + dataGridView1[1, i].Value.ToString() + "', Amount='" + dataGridView1[4, i].Value.ToString() + "', SupplierNumber='" + dataGridView1[3, i].Value.ToString() + "', Price='" + dataGridView1[5, i].Value.ToString() + "' WHERE OrderNumber='" + textBox1.Text + "' AND RowNumber='" + dataGridView1[0, i].Value.ToString() + "';";
                        MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                    }
                    MessageBox.Show("הזמנה עודכנה בהצלחה");
                    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                    this.Close();
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string insert = "INSERT INTO Orders VALUES ('" + textBox1.Text + "','" + dataGridView1[0, i].Value.ToString() + "',N'" + DateTime.Now.ToString("MM/dd/yyyy") + "',N'" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "',N'" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + dataGridView1[1, i].Value.ToString() + "','" + dataGridView1[4, i].Value.ToString() + "','" + dataGridView1[3, i].Value.ToString() + "','" + dataGridView1[5, i].Value.ToString() + "','" + true + "','" + true + "');";
                        MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                    }
                    MessageBox.Show("הזמנה נוספה בהצלחה");
                    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                    AddOrder f = new AddOrder();
                    FormInPanel.AddForm(Form1.mainp, f);
                    this.Close();
                }
            }
            else
                MessageBox.Show("עליך להוסיף לפחות שורה אחת");
            //if (label15.Text == "תקין" && label17.Text == "תקין")
            //{
            //    string insert = "INSERT INTO Orders VALUES ('" + textBox1.Text + "','" + textBox8.Text + "',N'" + DateTime.Now + "',N'" + dateTimePicker2.Value + "','','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + true + "');";
            //    MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
            //    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + textBox5.Text + "'";
            //    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            //    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) + int.Parse(textBox6.Text);
            //    string update = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + textBox5.Text + "'";
            //    MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
            //    MessageBox.Show("הזמנה נוספה בהצלחה");
            //    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            //    if (t == "a")
            //    {
            //        AddOrder f = new AddOrder();
            //        FormInPanel.AddForm(Form1.mainp, f);
            //    }
            //    this.Close();
            //}
            //else
            //    MessageBox.Show("עליך לתקן את הטופס");
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Items WHERE ItemNumber='" + textBox5.Text + "' AND Active='" + true + "'";
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.BackColor = Color.Red;
                label15.ForeColor = Color.Red;
                label15.Text = "מספר פריט זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox5.BackColor = Color.Red;
                    label15.ForeColor = Color.Red;
                    label15.Text = "מספר פריט זה לא קיים במאגר";
                }
                else
                {
                    textBox5.BackColor = Color.Green;
                    label15.ForeColor = Color.Green;
                    label15.Text = "תקין";
                }
            }
            string sql1 = "SELECT * FROM Unions WHERE SupplierNumber='" + textBox7.Text + "' AND ItemNumber='" + textBox5.Text + "'";
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.BackColor = Color.Red;
                label17.ForeColor = Color.Red;
                label17.Text = "מספר ספק זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                {
                    textBox7.BackColor = Color.Red;
                    label17.ForeColor = Color.Red;
                    label17.Text = "מספר ספק זה לא קיים במאגר";
                }
                else
                {
                    textBox7.BackColor = Color.Green;
                    label17.ForeColor = Color.Green;
                    label17.Text = "תקין";
                }
            }
            string sql2 = "SELECT PriceFromSupplier FROM Unions WHERE SupplierNumber='" + textBox7.Text + "' AND ItemNumber='" + textBox5.Text + "'";
            if (!string.IsNullOrEmpty(textBox6.Text) && int.Parse(textBox6.Text) > 0 && MyAdoHelperCsharp.IsExist("Database1.mdf", sql2))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                decimal x = decimal.Parse(dt.Rows[0]["PriceFromSupplier"].ToString());
                decimal y = decimal.Parse(textBox6.Text) * x;
                textBox3.Text = y.ToString();
                if (dataGridView1.Rows.Count > 0 && !string.IsNullOrEmpty(textBox8.Text) && int.Parse(textBox8.Text) <= dataGridView1.Rows.Count)
                {
                    if (t == "u")
                        textBox2.Text = (a + y - decimal.Parse(dataGridView1[5, int.Parse(textBox8.Text) - 1].Value.ToString())).ToString();
                    else
                        textBox2.Text = (a + y - decimal.Parse(dataGridView1[5, int.Parse(textBox8.Text) - 2].Value.ToString())).ToString();
                }
                else
                    textBox2.Text = (a + y).ToString();
            }
            else
            {
                textBox3.Text = "0.00";
                textBox2.Text = a.ToString();
            }
            if (label15.Text == "תקין" && label17.Text == "תקין")
            {
                textBox6.Text = "0";
                textBox6.Text = "1";
            }
            else
                textBox6.Text = "0";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Unions WHERE SupplierNumber='" + textBox7.Text + "' AND ItemNumber='" + textBox5.Text + "'";
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.BackColor = Color.Red;
                label17.ForeColor = Color.Red;
                label17.Text = "מספר ספק זה לא תקין";
            }
            else
            {
                if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
                {
                    textBox7.BackColor = Color.Red;
                    label17.ForeColor = Color.Red;
                    label17.Text = "מספר ספק זה לא קיים במאגר";
                }
                else
                {
                    textBox7.BackColor = Color.Green;
                    label17.ForeColor = Color.Green;
                    label17.Text = "תקין";
                }
            }
            string sql1 = "SELECT PriceFromSupplier FROM Unions WHERE SupplierNumber='" + textBox7.Text + "' AND ItemNumber='" + textBox5.Text + "'";
            if (!string.IsNullOrEmpty(textBox6.Text) && int.Parse(textBox6.Text) > 0 && MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                decimal x = decimal.Parse(dt.Rows[0]["PriceFromSupplier"].ToString());
                decimal y = decimal.Parse(textBox6.Text) * x;
                textBox3.Text = y.ToString();
                if (dataGridView1.Rows.Count > 0 && !string.IsNullOrEmpty(textBox8.Text) && int.Parse(textBox8.Text) <= dataGridView1.Rows.Count)
                {
                    if (t == "u")
                        textBox2.Text = (a + y - decimal.Parse(dataGridView1[5, int.Parse(textBox8.Text) - 1].Value.ToString())).ToString();
                    else
                        textBox2.Text = (a + y - decimal.Parse(dataGridView1[5, int.Parse(textBox8.Text) - 2].Value.ToString())).ToString();
                }
                else
                    textBox2.Text = (a + y).ToString();
            }
            else
            {
                textBox3.Text = "0.00";
                textBox2.Text = a.ToString();
            }
            if (label15.Text == "תקין" && label17.Text == "תקין")
            {
                textBox6.Text = "0";
                textBox6.Text = "1";
            }
            else
                textBox6.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label15.Text == "תקין" && label17.Text == "תקין")
            {
                string sql = "SELECT ItemName FROM Items WHERE ItemNumber='" + textBox5.Text + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                if (button4.Text == "הוסף שורה")
                    dataGridView1.Rows.Insert(dataGridView1.Rows.Count, textBox8.Text, textBox5.Text, dt.Rows[0]["ItemName"].ToString(), textBox7.Text, textBox6.Text, textBox3.Text, "מחק");
                else
                {
                    button4.Text = "הוסף שורה";
                    dataGridView1[0, row].Value = textBox8.Text;
                    dataGridView1[1, row].Value = textBox5.Text;
                    dataGridView1[2, row].Value = dt.Rows[0]["ItemName"].ToString();
                    dataGridView1[3, row].Value = textBox7.Text;
                    dataGridView1[4, row].Value = textBox6.Text;
                    dataGridView1[5, row].Value = textBox3.Text;
                }
                textBox8.Text = (dataGridView1.Rows.Count + 1).ToString();
                textBox5.Text = "";
                textBox7.Text = "";
                textBox5.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox6.Text = "0";
                textBox3.Text = "0.00";
                label17.Text = "";
                label15.Text = "";
                decimal dec = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dec += decimal.Parse(dataGridView1[5, i].Value.ToString());
                textBox2.Text = dec.ToString();
                a = dec;
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
            //if (label15.Text == "תקין" && label17.Text == "תקין")
            //{
            //    string insert = "INSERT INTO Orders VALUES ('" + textBox1.Text + "','" + textBox8.Text + "',N'" + DateTime.Now + "',N'" + dateTimePicker2.Value + "',NULL,'" + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + true + "');";
            //    MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
            //    string sql= "SELECT Amount FROM Items WHERE ItemNumber='" + textBox5.Text + "'";
            //    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            //    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) + int.Parse(textBox6.Text);
            //    string update = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + textBox5.Text + "'";
            //    MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
            //    MessageBox.Show("שורה נוספה בהצלחה");
            //    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            //    if (t == "u")
            //    {
            //        AddOrder f = new AddOrder(textBox1.Text, textBox8.Text, "u");
            //        f.Show();
            //        FormInPanel.AddForm(Form1.mainp, f);
            //    }
            //    else
            //    {
            //        AddOrder f = new AddOrder(textBox1.Text, textBox8.Text, "a");
            //        f.Show();
            //        FormInPanel.AddForm(Form1.mainp, f);
            //    }
            //}
            //else
            //    MessageBox.Show("עליך לתקן את הטופס");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label15.Text == "תקין")
            {
                ShowItem f = new ShowItem("3", textBox5, textBox7);
                FormInPanel.AddForm(Form1.mainp, f);
            }
            else
                MessageBox.Show("מספר פריט לא תקין");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label15.Text == "תקין" && label17.Text == "תקין" && !string.IsNullOrEmpty(textBox6.Text))
            {
                string sql = "SELECT MaxAmount FROM Items WHERE ItemNumber='" + textBox5.Text + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1[1, i].Value.ToString() == textBox5.Text)
                    {
                        sum += int.Parse(dataGridView1[4, i].Value.ToString());
                    }
                }
                if (int.Parse(textBox6.Text) + sum + 1 > int.Parse(dt.Rows[0]["MaxAmount"].ToString()))
                {
                    DialogResult r = MessageBox.Show("כמות זו גדולה מכמות המקסימום האם אתה בטוח?", "התראה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        textBox6.Text = (int.Parse(textBox6.Text) + 1).ToString();
                    }
                }
                else
                    textBox6.Text = (int.Parse(textBox6.Text) + 1).ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox6.Text != "0" && textBox6.Text != "1" && !string.IsNullOrEmpty(textBox6.Text))
                textBox6.Text = (int.Parse(textBox6.Text) - 1).ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT PriceFromSupplier FROM Unions WHERE SupplierNumber='" + textBox7.Text + "' AND ItemNumber='" + textBox5.Text + "'";
            if (!string.IsNullOrEmpty(textBox6.Text) && int.Parse(textBox6.Text) > 0 && MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                decimal x = decimal.Parse(dt.Rows[0]["PriceFromSupplier"].ToString());
                decimal y = decimal.Parse(textBox6.Text) * x;
                textBox3.Text = y.ToString();
                if (dataGridView1.Rows.Count > 0 && !string.IsNullOrEmpty(textBox8.ToString()) && int.Parse(textBox8.Text) <= dataGridView1.Rows.Count)
                {
                    if (t == "u")
                        textBox2.Text = (a + y - decimal.Parse(dataGridView1[5, int.Parse(textBox8.Text) - 1].Value.ToString())).ToString();
                    else
                        textBox2.Text = (a + y - decimal.Parse(dataGridView1[5, int.Parse(textBox8.Text) - 2].Value.ToString())).ToString();
                }
                else
                    textBox2.Text = (a + y).ToString();
            }
            else
            {
                textBox3.Text = "0.00";
                textBox2.Text = a.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AddOrder_Load(object sender, EventArgs e)
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
                textBox8.Text = (dataGridView1.Rows.Count + 1).ToString();
                textBox5.Text = "";
                textBox7.Text = "";
                textBox5.BackColor = Color.White;
                textBox7.BackColor = Color.White;
                textBox6.Text = "0";
                textBox3.Text = "0.00";
                label17.Text = "";
                label15.Text = "";
                decimal dec = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    dec += decimal.Parse(dataGridView1[5, i].Value.ToString());
                textBox2.Text = dec.ToString();
                a = dec;
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    row = e.RowIndex;
                    button4.Text = "עדכן שורה";
                    textBox8.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                    textBox5.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                    textBox7.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                    textBox6.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                    textBox3.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                    decimal dec = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        dec += decimal.Parse(dataGridView1[5, i].Value.ToString());
                    textBox2.Text = dec.ToString();
                    a = dec;
                }
            }
        }
        int row;
        private void button8_Click(object sender, EventArgs e)
        {
            button4.Text = "הוסף שורה";
            textBox8.Text = (dataGridView1.Rows.Count + 1).ToString();
            textBox5.Text = "";
            textBox7.Text = "";
            textBox5.BackColor = Color.White;
            textBox7.BackColor = Color.White;
            textBox6.Text = "0";
            textBox3.Text = "0.00";
            label17.Text = "";
            label15.Text = "";
            decimal dec = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dec += decimal.Parse(dataGridView1[5, i].Value.ToString());
            textBox2.Text = dec.ToString();
            a = dec;
        }
    }
}
