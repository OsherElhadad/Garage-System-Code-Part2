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
    public partial class ControlGetOrder : Form
    {
        public ControlGetOrder()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetNumber(textBox2);
            Sets.SetGeneral(comboBox1);
            Sets.SetGeneral(comboBox2);
        }
        Translate tran = new Translate();
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה לצאת מהפעולה", "יציאה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {
                UserLogIn.myforms[UserLogIn.myforms.Count - 1].Close();
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
            }
        }

        private void comboBox2_TextChanged_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
            if (!string.IsNullOrEmpty(comboBox1.Text) && comboBox1.SelectedIndex >= 0 && comboBox1.Items[comboBox1.SelectedIndex].ToString() == comboBox1.Text)
            {
                string sql1 = "SELECT OrderNumber AS 'מספר הזמנה', RowNumber AS 'מספר שורה', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', ItemNumber AS 'מספר פריט', Amount AS 'כמות', SupplierNumber AS 'מספר ספק', Price AS 'מחיר', Active AS 'בתהליך', Active2 AS 'פעיל' FROM Orders WHERE " + tran.Find(comboBox1.Text);
                DateTime a;
                if ((tran.Find(comboBox1.Text) == "StartDate" || tran.Find(comboBox1.Text) == "SupposeEndDate" || tran.Find(comboBox1.Text) == "EndDate") && DateTime.TryParse(comboBox2.Text, out a))
                    sql1 += "='" + Convert.ToDateTime(comboBox2.Text).ToString("MM/dd/yyyy") + "'";
                else
                    sql1 += " LIKE'" + comboBox2.Text + "%'";
                sql1 += "AND Active='True' AND Active2='True'";
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                }
                else
                    dataGridView1.Visible = false;
            }
            else
                dataGridView1.Visible = false;
        }

        private void ControlGetOrder_Load(object sender, EventArgs e)
        {
            tran.Add("OrderNumber", "מספר הזמנה");
            tran.Add("RowNumber", "מספר שורה");
            tran.Add("StartDate", "תאריך התחלה");
            tran.Add("SupposeEndDate", "תאריך משוער לסיום");
            tran.Add("EndDate", "תאריך סיום");
            tran.Add("ItemNumber", "מספר פריט");
            tran.Add("Amount", "כמות");
            tran.Add("SupplierNumber", "מספר ספק");
            tran.Add("Price", "מחיר");
            tran.Add("Active", "פעיל");
            string sql1 = "SELECT OrderNumber AS 'מספר הזמנה', RowNumber AS 'מספר שורה', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', ItemNumber AS 'מספר פריט', Amount AS 'כמות', SupplierNumber AS 'מספר ספק', Price AS 'מחיר', Active AS 'פעיל' FROM Orders";
            Checks.FillColumns(comboBox1, sql1, "");
        }
        int amount = 0;
        string ordernum = "";
        string supplier = "";
        string rownum = "";
        string itemnum = "";
        string price = "";
        string amount1 = "";
        int index = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dateTimePicker1.MaxDate = DateTime.Today;
                dateTimePicker1.MinDate = Convert.ToDateTime(dataGridView1[2, e.RowIndex].Value.ToString());
                index = e.RowIndex;
                textBox4.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                textBox5.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                ordernum = dataGridView1[0, e.RowIndex].Value.ToString();
                rownum = dataGridView1[1, e.RowIndex].Value.ToString();
                itemnum = dataGridView1[5, e.RowIndex].Value.ToString();
                amount1 = dataGridView1[6, e.RowIndex].Value.ToString();
                supplier = dataGridView1[7, e.RowIndex].Value.ToString();
                price = dataGridView1[8, e.RowIndex].Value.ToString();
                panel1.Visible = true;
                textBox3.Text = (dateTimePicker1.Value - Convert.ToDateTime(dataGridView1[3, e.RowIndex].Value.ToString())).Days.ToString();
                if (int.Parse(textBox3.Text) < 0)
                    textBox3.Text = "0";
                textBox1.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                amount = int.Parse(textBox1.Text);
                textBox2.Text = "";
            }
            else
                MessageBox.Show("עליך להקליק על אחד מהשורות המלאות");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT distinct " + tran.Find(comboBox1.Text) + " FROM Orders WHERE Active='True' AND Active2='True'";
            sql1 += " order by " + tran.Find(comboBox1.Text);
            comboBox2.DataSource = new List<string>();
            comboBox2.ValueMember = "";
            comboBox2.Text = "";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.DataSource = dt1;
            comboBox2.ValueMember = tran.Find(comboBox1.Text);
            comboBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
                textBox1.Text = (amount - int.Parse(textBox2.Text)).ToString();
            else
                textBox1.Text = amount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (int.Parse(textBox1.Text) > 0)
                {
                    //decimal y = decimal.Parse(price);
                    //string sql4 = "SELECT PriceFromSupplier FROM Unions WHERE SupplierNumber='" + supplier + "' AND ItemNumber='" + itemnum + "'";
                    //if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql4))
                    //{
                    //    DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                    //    decimal x = decimal.Parse(dt3.Rows[0]["PriceFromSupplier"].ToString());
                    //    y = decimal.Parse(textBox1.Text) * x;
                    //}

                    string update = "UPDATE Orders SET Amount='" + textBox1.Text + "' WHERE OrderNumber='" + ordernum + "' AND RowNumber='" + rownum + "';";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + itemnum + "'";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    string sql3 = "SELECT * FROM Orders WHERE OrderNumber='" + ordernum + "' AND RowNumber='" + rownum + "'";
                    DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) + int.Parse(textBox2.Text);
                    string update1 = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + itemnum + "'";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update1);
                    string select = "SELECT SupplierEmail FROM Suppliers WHERE SupplierNumber = '" + dt2.Rows[0]["SupplierNumber"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", select);
                    if (int.Parse(textBox3.Text) <= 0)
                    {
                        MessageBox.Show("מספר הזמנה: " + ordernum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nההזמנה הגיעה בזמן" + "\nכמות נדרשת: " + amount1 + "\nכמות שהגיעה: " + textBox2.Text + "\nכמות שנותרה להגיע מהספק: " + textBox1.Text);
                        EmailChecks.SendEmail(dt4.Rows[0]["SupplierEmail"].ToString(), "הגעת הזמנה", "מספר מוצר: " + itemnum + ", ההזמנה הגיעה בזמן, " + "כמות נדרשת: " + amount1 + ", כמות שהגיעה: " + textBox2.Text + ", כמות שנותרה להגיע: " + textBox1.Text);
                    }
                    if (int.Parse(textBox3.Text) > 0)
                    {
                        MessageBox.Show("מספר הזמנה: " + ordernum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nימי איחור: " + textBox3.Text + "\nכמות נדרשת: " + amount1 + "\nכמות שהגיעה: " + textBox2.Text + "\nכמות שנותרה להגיע מהספק: " + textBox1.Text);
                        EmailChecks.SendEmail(dt4.Rows[0]["SupplierEmail"].ToString(), "הגעת הזמנה", "מספר מוצר: " + itemnum + ", ימי איחור: " + textBox3.Text + ", כמות נדרשת: " + amount1 + ", כמות שהגיעה: " + textBox2.Text + ", כמות שנותרה להגיע: " + textBox1.Text);
                    }
                    string sql1 = "SELECT OrderNumber AS 'מספר הזמנה', RowNumber AS 'מספר שורה', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', ItemNumber AS 'מספר פריט', Amount AS 'כמות', SupplierNumber AS 'מספר ספק', Price AS 'מחיר', Active AS 'בתהליך', Active2 AS 'פעיל' FROM Orders WHERE " + tran.Find(comboBox1.Text);
                    DateTime a;
                    if ((tran.Find(comboBox1.Text) == "StartDate" || tran.Find(comboBox1.Text) == "SupposeEndDate" || tran.Find(comboBox1.Text) == "EndDate") && DateTime.TryParse(comboBox2.Text, out a))
                        sql1 += "='" + Convert.ToDateTime(comboBox2.Text).ToString("MM/dd/yyyy") + "'";
                    else
                        sql1 += " LIKE'" + comboBox2.Text + "%'";
                    sql1 += "AND Active='True' AND Active2='True'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                    {
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }
                    panel1.Visible = false;
                }
                else
                {
                    string update = "UPDATE Orders SET Amount='" + 0 + "', EndDate=N'" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "', Active='false' WHERE OrderNumber='" + ordernum + "' AND RowNumber='" + rownum + "';";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + itemnum + "'";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    string sql3 = "SELECT * FROM Orders WHERE OrderNumber='" + ordernum + "' AND RowNumber='" + rownum + "'";
                    DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                    int amountorder = int.Parse(dt2.Rows[0]["Amount"].ToString());
                    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) + int.Parse(amount1);
                    string update1 = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + itemnum + "'";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update1);
                    string select = "SELECT SupplierEmail FROM Suppliers WHERE SupplierNumber = '" + dt2.Rows[0]["SupplierNumber"].ToString() + "'";
                    DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", select);
                    if (int.Parse(textBox3.Text) <= 0)
                    {
                        MessageBox.Show("מספר הזמנה: " + ordernum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nההזמנה הגיעה בזמן" + "\nכמות נדרשת: " + amount1 + "\nכמות שהגיעה: " + textBox2.Text + "\nכמות עודפת שהגיעה מהספק: " + (int.Parse(textBox1.Text) * (-1)));
                        EmailChecks.SendEmail(dt4.Rows[0]["SupplierEmail"].ToString(), "הגעת הזמנה", "מספר מוצר: " + itemnum + ", ההזמנה הגיעה בזמן, " + "כמות נדרשת: " + amount1 + ", כמות שהגיעה: " + textBox2.Text + ", כמות שמוחזרת לספק: " + (int.Parse(textBox1.Text) * (-1)));
                    }
                    if (int.Parse(textBox3.Text) > 0)
                    {
                        MessageBox.Show("מספר הזמנה: " + ordernum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nימי איחור: " + textBox3.Text + "\nכמות נדרשת: " + amount1 + "\nכמות שהגיעה: " + textBox2.Text + "\nכמות עודפת שהגיעה מהספק: " + (int.Parse(textBox1.Text) * (-1)));
                        EmailChecks.SendEmail(dt4.Rows[0]["SupplierEmail"].ToString(), "הגעת הזמנה", "מספר מוצר: " + itemnum + ", ימי איחור: " + textBox3.Text + ", כמות נדרשת: " + amount1 + ", כמות שהגיעה: " + textBox2.Text + ", כמות שמוחזרת לספק: " + (int.Parse(textBox1.Text) * (-1)));
                    }
                    string sql1 = "SELECT OrderNumber AS 'מספר הזמנה', RowNumber AS 'מספר שורה', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', ItemNumber AS 'מספר פריט', Amount AS 'כמות', SupplierNumber AS 'מספר ספק', Price AS 'מחיר', Active AS 'בתהליך', Active2 AS 'פעיל' FROM Orders WHERE " + tran.Find(comboBox1.Text);
                    DateTime a;
                    if ((tran.Find(comboBox1.Text) == "StartDate" || tran.Find(comboBox1.Text) == "SupposeEndDate" || tran.Find(comboBox1.Text) == "EndDate") && DateTime.TryParse(comboBox2.Text, out a))
                        sql1 += "='" + Convert.ToDateTime(comboBox2.Text).ToString("MM/dd/yyyy") + "'";
                    else
                        sql1 += " LIKE'" + comboBox2.Text + "%'";
                    sql1 += "AND Active='True' AND Active2='True'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                    {
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }
                    panel1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("עליך למלא את הטופס");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = (dateTimePicker1.Value - Convert.ToDateTime(dataGridView1[3, index].Value.ToString())).Days.ToString();
            if (int.Parse(textBox3.Text) < 0)
                textBox3.Text = "0";
        }
    }
}
