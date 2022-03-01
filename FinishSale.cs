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
    public partial class FinishSale : Form
    {
        public FinishSale()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetNumber(textBox2);
            Sets.SetPrice(textBox6);
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
                string sql1 = "SELECT SaleNumber AS 'מספר מכירה', RowNumber AS 'מספר שורה', ItemNumber AS 'מספר פריט', Amount AS 'כמות', Price AS 'מחיר', CarNumber AS 'מספר רכב', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', PaymentMethods.Method AS 'אמצעי תשלום', Description AS 'תיאור', Active AS 'בתהליך', Active2 AS 'פעיל' FROM Sales, PaymentMethods WHERE " + tran.Find(comboBox1.Text);
                DateTime a;
                if ((tran.Find(comboBox1.Text) == "StartDate" || tran.Find(comboBox1.Text) == "SupposeEndDate" || tran.Find(comboBox1.Text) == "EndDate") && DateTime.TryParse(comboBox2.Text, out a))
                    sql1 += "='" + Convert.ToDateTime(comboBox2.Text).ToString("MM/dd/yyyy") + "'";
                else
                    sql1 += " LIKE'" + comboBox2.Text + "%'";
                sql1 += " AND PaymentMethods.Number=PaymentMethod AND Active='True' AND Active2='True'";
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

        int amount = 0;
        string salenum = "";
        string rownum = "";
        string itemnum = "";
        string amount1 = "";
        string price = "";
        string carnumber = "";
        int index = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dateTimePicker1.MaxDate = DateTime.Today;
                dateTimePicker1.MinDate = Convert.ToDateTime(dataGridView1[6, e.RowIndex].Value.ToString());
                index = e.RowIndex;
                textBox4.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                textBox5.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                salenum = dataGridView1[0, e.RowIndex].Value.ToString();
                rownum = dataGridView1[1, e.RowIndex].Value.ToString();
                itemnum = dataGridView1[2, e.RowIndex].Value.ToString();
                amount1 = dataGridView1[3, e.RowIndex].Value.ToString();
                price = dataGridView1[4, e.RowIndex].Value.ToString();
                carnumber = dataGridView1[5, e.RowIndex].Value.ToString();
                panel1.Visible = true;
                textBox2.Text = "";
                textBox6.Text = "";
                textBox3.Text = (DateTime.Today - Convert.ToDateTime(dataGridView1[8, e.RowIndex].Value.ToString())).Days.ToString();
                if (int.Parse(textBox3.Text) < 0)
                    textBox3.Text = "0";
                textBox1.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                amount = int.Parse(textBox1.Text);
            }
            else
                MessageBox.Show("עליך להקליק על אחד מהשורות המלאות");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql1 = "SELECT distinct " + tran.Find(comboBox1.Text) + " FROM Sales, PaymentMethods WHERE PaymentMethods.Number=PaymentMethod AND Active='True' AND Active2='True'";
            sql1 += " order by " + tran.Find(comboBox1.Text);
            comboBox2.DataSource = new List<string>();
            comboBox2.ValueMember = "";
            comboBox2.Text = "";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.DataSource = dt1;
            if (tran.Find(comboBox1.Text).Split('.').Length == 1)
                comboBox2.ValueMember = tran.Find(comboBox1.Text);
            else
                comboBox2.ValueMember = tran.Find(comboBox1.Text).Split('.')[1];
            comboBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                int amount1;
                string sql2 = "SELECT Amount, MinAmount FROM Items WHERE ItemNumber='" + itemnum + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                amount1 = int.Parse(dt.Rows[0]["Amount"].ToString()) - int.Parse(textBox2.Text);
                if (amount1 < int.Parse(dt.Rows[0]["MinAmount"].ToString()))
                {
                    MessageBox.Show("כמות זו של פריט זה מתחת לכמות המינימום");
                    DialogResult r = MessageBox.Show("?האם אתה רוצה להזמין פריט זה", "הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        AddOrder f = new AddOrder(itemnum);
                        FormInPanel.AddForm(Form1.mainp, f);
                    }
                    textBox2.Text = "0";
                    textBox2.BackColor = Color.White;
                }
                else
                {
                    textBox1.Text = (amount - int.Parse(textBox2.Text)).ToString();
                }
            }
            else
            {
                textBox1.Text = amount.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox6.Text))
            {
                if (int.Parse(textBox1.Text) >= 0)
                {
                    string sql3 = "SELECT * FROM Sales WHERE SaleNumber='" + salenum + "' AND RowNumber='" + rownum + "'";
                    DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                    int amountorder = int.Parse(dt3.Rows[0]["Amount"].ToString());

                    decimal z = 1;
                    decimal y = decimal.Parse(price);
                    string sql5 = "SELECT PriceList FROM Items WHERE ItemNumber='" + itemnum + "'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql5))
                    {
                        string sql6 = "SELECT * FROM Cars WHERE CarNumber='" + carnumber + "' AND GarageNumber!=''";
                        if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql6))
                        {
                            DataTable dt6 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql6);
                            string sql7 = "SELECT * FROM Garages WHERE GarageNumber='" + dt6.Rows[0]["GarageNumber"].ToString() + "'";
                            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql7))
                            {
                                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql7);
                                z = 1 - (decimal.Parse(dt2.Rows[0]["Discount"].ToString()) / 100);
                            }
                        }
                        DataTable dt7 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                        decimal x = decimal.Parse(dt7.Rows[0]["PriceList"].ToString());
                        y = decimal.Parse(textBox2.Text) * x * z;
                    }

                    string update = "UPDATE Sales SET Amount='" + textBox2.Text + "', EndDate=N'" + DateTime.Today.ToString("MM/dd/yyyy") + "', Price='" + (y + decimal.Parse(textBox6.Text)) + "', Active='False' WHERE SaleNumber='" + salenum + "' AND RowNumber='" + rownum + "';";
                    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + itemnum + "'";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - int.Parse(textBox2.Text);
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                    string update1 = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + itemnum + "'";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update1);
                    if (int.Parse(textBox3.Text) <= 0)
                        MessageBox.Show("מספר מכירה: " + salenum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nהמכירה נמכרה בזמן" + "\nכמות נדרשת: " + amount1 + "\nכמות שנמכרה: " + textBox2.Text + "\nכמות שלא נמכרה מהמכירה: " + textBox1.Text);
                    if (int.Parse(textBox3.Text) > 0)
                        MessageBox.Show("מספר מכירה: " + salenum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nימי איחור: " + textBox3.Text + "\nכמות נדרשת: " + amount1 + "\nכמות שנמכרה: " + textBox2.Text + "\nכמות שלא נמכרה מהמכירה: " + textBox1.Text);
                    string sql2 = "SELECT SaleNumber AS 'מספר מכירה', RowNumber AS 'מספר שורה', ItemNumber AS 'מספר פריט', Amount AS 'כמות', Price AS 'מחיר', CarNumber AS 'מספר רכב', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', PaymentMethods.Method AS 'אמצעי תשלום', Description AS 'תיאור', Active AS 'בתהליך', Active2 AS 'פעיל' FROM Sales, PaymentMethods WHERE " + tran.Find(comboBox1.Text);
                    DateTime a;
                    if ((tran.Find(comboBox1.Text) == "StartDate" || tran.Find(comboBox1.Text) == "SupposeEndDate" || tran.Find(comboBox1.Text) == "EndDate") && DateTime.TryParse(comboBox2.Text, out a))
                        sql2 += "='" + Convert.ToDateTime(comboBox2.Text).ToString("MM/dd/yyyy") + "'";
                    else
                        sql2 += " LIKE'" + comboBox2.Text + "%'";
                    sql2 += " AND PaymentMethods.Number=PaymentMethod AND Active='True' AND Active2='True'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql2))
                    {
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                    }
                    else
                    {
                        dataGridView1.Visible = false;
                    }
                    panel1.Visible = false;
                }
                else
                {
                    string sql3 = "SELECT * FROM Sales WHERE SaleNumber='" + salenum + "' AND RowNumber='" + rownum + "'";
                    DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                    int amountorder = int.Parse(dt3.Rows[0]["Amount"].ToString());

                    decimal z = 1;
                    decimal y = decimal.Parse(price);
                    string sql5 = "SELECT PriceList FROM Items WHERE ItemNumber='" + itemnum + "'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql5))
                    {
                        string sql6 = "SELECT * FROM Cars WHERE CarNumber='" + carnumber + "' AND GarageNumber!=''";
                        if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql6))
                        {
                            DataTable dt6 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql6);
                            string sql7 = "SELECT * FROM Garages WHERE GarageNumber='" + dt6.Rows[0]["GarageNumber"].ToString() + "'";
                            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql7))
                            {
                                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql7);
                                z = 1 - (decimal.Parse(dt2.Rows[0]["Discount"].ToString()) / 100);
                            }
                        }
                        DataTable dt7 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                        decimal x = decimal.Parse(dt7.Rows[0]["PriceList"].ToString());
                        y = decimal.Parse(textBox2.Text) * x * z;
                    }

                    string update = "UPDATE Sales SET Amount='" + textBox2.Text + "', EndDate=N'" + DateTime.Today.ToString("MM/dd/yyyy") + "', Price='" + (y + decimal.Parse(textBox6.Text)) + "', Active='False' WHERE SaleNumber='" + salenum + "' AND RowNumber='" + rownum + "';";
                    string sql = "SELECT Amount FROM Items WHERE ItemNumber='" + itemnum + "'";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    int amount = int.Parse(dt.Rows[0]["Amount"].ToString()) - int.Parse(textBox2.Text);
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update);
                    string update1 = "UPDATE Items SET Amount='" + amount + "' WHERE ItemNumber='" + itemnum + "'";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", update1);
                    if (int.Parse(textBox3.Text) <= 0)
                        MessageBox.Show("מספר מכירה: " + salenum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nהמכירה נמכרה בזמן" + "\nכמות נדרשת: " + amount1 + "\nכמות שנמכרה: " + textBox2.Text + "\nכמות נוספת שנמכרה: " + (int.Parse(textBox1.Text)*(-1)));
                    if (int.Parse(textBox3.Text) > 0)
                        MessageBox.Show("מספר מכירה: " + salenum + "\nמספר שורה: " + rownum + "\nמספר מוצר: " + itemnum + "\nימי איחור: " + textBox3.Text + "\nכמות נדרשת: " + amount1 + "\nכמות שנמכרה: " + textBox2.Text + "\nכמות נוספת שנמכרה: " + (int.Parse(textBox1.Text) * (-1)));
                    string sql2 = "SELECT SaleNumber AS 'מספר מכירה', RowNumber AS 'מספר שורה', ItemNumber AS 'מספר פריט', Amount AS 'כמות', Price AS 'מחיר', CarNumber AS 'מספר רכב', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', PaymentMethods.Method AS 'אמצעי תשלום', Description AS 'תיאור', Active AS 'בתהליך', Active2 AS 'פעיל' FROM Sales, PaymentMethods WHERE " + tran.Find(comboBox1.Text);
                    DateTime a;
                    if ((tran.Find(comboBox1.Text) == "StartDate" || tran.Find(comboBox1.Text) == "SupposeEndDate" || tran.Find(comboBox1.Text) == "EndDate") && DateTime.TryParse(comboBox2.Text, out a))
                        sql2 += "='" + Convert.ToDateTime(comboBox2.Text).ToString("MM/dd/yyyy") + "'";
                    else
                        sql2 += " LIKE'" + comboBox2.Text + "%'";
                    sql2 += " AND PaymentMethods.Number=PaymentMethod AND Active='True' AND Active2='True'";
                    if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql2))
                    {
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
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

        private void FinishSale_Load(object sender, EventArgs e)
        {
            tran.Add("SaleNumber", "מספר מכירה");
            tran.Add("RowNumber", "מספר שורה");
            tran.Add("ItemNumber", "מספר פריט");
            tran.Add("Amount", "כמות");
            tran.Add("Price", "מחיר");
            tran.Add("CarNumber", "מספר רכב");
            tran.Add("StartDate", "תאריך התחלה");
            tran.Add("SupposeEndDate", "תאריך משוער לסיום");
            tran.Add("EndDate", "תאריך סיום");
            tran.Add("PaymentMethods.Method", "אמצעי תשלום");
            tran.Add("Description", "תיאור");
            tran.Add("Active", "פעיל");
            string sql1 = "SELECT SaleNumber AS 'מספר מכירה', RowNumber AS 'מספר שורה', ItemNumber AS 'מספר פריט', Amount AS 'כמות', Price AS 'מחיר', CarNumber AS 'מספר רכב', StartDate AS 'תאריך התחלה', SupposeEndDate AS 'תאריך משוער לסיום', EndDate AS 'תאריך סיום', PaymentMethod AS 'אמצעי תשלום', Description AS 'תיאור', Active AS 'פעיל' FROM Sales";
            Checks.FillColumns(comboBox1, sql1, "");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text = (dateTimePicker1.Value - Convert.ToDateTime(dataGridView1[8, index].Value.ToString())).Days.ToString();
            if (int.Parse(textBox3.Text) < 0)
                textBox3.Text = "0";
        }
    }
}
