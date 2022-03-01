using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace OsherProject
{
    public partial class AddItem : Form
    {
        string type;
        public AddItem(string t)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("SupplierNumber", "מספר ספק");
            dataGridView1.Columns.Add("SupplierName", "שם ספק");
            dataGridView1.Columns.Add("ItemNumberAtSupplier", "מספר פריט אצל ספק");
            dataGridView1.Columns.Add("PriceFromSupplier", "מחיר מהספק");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            string sql1 = "SELECT distinct Name FROM CarTypes order by Name";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox8.DataSource = dt1;
            textBox8.ValueMember = "Name";
            textBox8.Text = null;

            textBox8.BackColor = SystemColors.Window;
            label17.ForeColor = Color.Black;
            label17.Text = "";

            Design.Designer(this);
            Sets.SetName(textBox2);
            Sets.SetPrice(textBox3);
            Sets.SetNumber(textBox4);
            Sets.SetNote(textBox7);
            Sets.SetNumber(textBox5);
            Sets.SetNumber(textBox6);
            Sets.SetNumber(comboBox2);
            Sets.SetPrice(comboBox3);
            type = t;
            textBox4.Text = "0";
            string sql = "SELECT ItemNumber FROM Items ORDER BY ItemNumber";
            Checks.Max(textBox1, "ItemNumber", sql);
        }
        bool f = false;
        byte[] tempimg2;
        public AddItem(string t, string itemnum)
        {
            InitializeComponent();
            dataGridView1.Columns.Add("SupplierNumber", "מספר ספק");
            dataGridView1.Columns.Add("SupplierName", "שם ספק");
            dataGridView1.Columns.Add("ItemNumberAtSupplier", "מספר פריט אצל ספק");
            dataGridView1.Columns.Add("PriceFromSupplier", "מחיר מהספק");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "מחיקה";
            btn.Text = "מחיקה";
            btn.FlatStyle = FlatStyle.Flat;
            btn.Name = "btn";

            string sql1 = "SELECT distinct Name FROM CarTypes order by Name";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            textBox8.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox8.AutoCompleteSource = AutoCompleteSource.ListItems;
            textBox8.DataSource = dt1;
            textBox8.ValueMember = "Name";

            Design.Designer(this);
            Sets.SetName(textBox2);
            Sets.SetPrice(textBox3);
            Sets.SetNumber(textBox4);
            Sets.SetNote(textBox7);
            Sets.SetNumber(textBox5);
            Sets.SetNumber(textBox6);
            Sets.SetNumber(comboBox2);
            Sets.SetPrice(comboBox3);
            type = t;
            textBox1.Text = itemnum;
            string sql = "SELECT * FROM Items WHERE ItemNumber='" + itemnum + "'";
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[0]["CarType"].ToString() + "'";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            textBox2.Text = dt.Rows[0]["ItemName"].ToString();
            textBox4.Text = dt.Rows[0]["Amount"].ToString();
            textBox7.Text = "f";
            textBox7.Text = dt.Rows[0]["Description"].ToString();
            textBox8.Text = dt2.Rows[0]["Name"].ToString();
            textBox3.Text = dt.Rows[0]["PriceList"].ToString();
            textBox5.Text = dt.Rows[0]["MinAmount"].ToString();
            textBox6.Text = dt.Rows[0]["MaxAmount"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["Picture"].ToString()))
            {
                byte[] tempimg = (byte[])dt.Rows[0]["Picture"];
                tempimg2 = (byte[])dt.Rows[0]["Picture"];
                MemoryStream tempstream = new MemoryStream(tempimg);
                pictureBox1.Image = Image.FromStream(tempstream);
                f = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            string sql3 = "SELECT * FROM Unions WHERE ItemNumber='" + itemnum + "'";
            DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                string sql4 = "SELECT SupplierName FROM Suppliers WHERE SupplierNumber='" + dt3.Rows[i]["SupplierNumber"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                dataGridView1.Rows.Insert(dataGridView1.Rows.Count, dt3.Rows[i]["SupplierNumber"].ToString(), dt4.Rows[0]["SupplierName"].ToString(), dt3.Rows[i]["ItemNumberAtSupplier"].ToString(), dt3.Rows[i]["PriceFromSupplier"].ToString(), "מחק");
            }
            label1.Text = "עדכון פריט";
            button3.Text = "עדכן";
            button2.Visible = false;
        }
        string picLoc = "";
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
            AddItem f = new AddItem("a");
            FormInPanel.AddForm(Form1.mainp, f);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label10.Text == "תקין" && label11.Text == "תקין" && (label16.Text == "תקין" || label16.Text == "") && label17.Text == "תקין" && label21.Text == "תקין" && label22.Text == "תקין")
            {
                if (type == "u")
                {
                    string delete = "DELETE FROM Items WHERE ItemNumber='" + textBox1.Text + "'";
                    string delete2 = "DELETE FROM Unions WHERE ItemNumber='" + textBox1.Text + "'";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", delete);
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", delete2);
                }
                string sql1 = "SELECT * FROM CarTypes WHERE Name='" + textBox8.Text + "'";
                DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
                string insert = "INSERT INTO Items VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + dt1.Rows[0]["ID"].ToString() + "','" + textBox3.Text;
                if (f)
                {
                    insert += "' , @img, '" + true + "');";
                    MyAdoHelperCsharp.DoQueryWithImage("Database1.mdf", insert, tempimg2);
                }
                else
                {
                    if (string.IsNullOrEmpty(pictureBox1.ImageLocation))
                    {
                        insert += "' , NULL, '" + true + "');";
                        MyAdoHelperCsharp.DoQuery("Database1.mdf", insert);
                    }
                    else
                    {
                        byte[] binaryImg;
                        FileStream fs = new FileStream(picLoc, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        binaryImg = br.ReadBytes((int)fs.Length);
                        insert += "' , @img, '" + true + "');";
                        MyAdoHelperCsharp.DoQueryWithImage("Database1.mdf", insert, binaryImg);
                    }
                }
                string insert2;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    insert2 = "INSERT INTO Unions VALUES ('" + dataGridView1[0, i].Value.ToString() + "','" + textBox1.Text + "','" + dataGridView1[2, i].Value.ToString() + "','" + dataGridView1[3, i].Value.ToString() + "','" + true + "');";
                    MyAdoHelperCsharp.DoQuery("Database1.mdf", insert2);
                }
                if (type == "u")
                    MessageBox.Show("פריט עודכן בהצלחה");
                else
                    MessageBox.Show("פריט נוסף בהצלחה");
                UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                if (type == "a")
                {
                    AddItem f1 = new AddItem("a");
                    FormInPanel.AddForm(Form1.mainp, f1);
                }
                this.Close();
            }
            else
                MessageBox.Show("עליך לתקן את הטופס");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox2.Text, 4) || !Checks.NameSofiot(textBox2.Text))
            {
                textBox2.BackColor = Color.Red;
                label11.ForeColor = Color.Red;
                label11.Text = "שם פריט זה לא תקין";
            }
            else
            {
                textBox2.BackColor = Color.Green;
                label11.ForeColor = Color.Green;
                label11.Text = "תקין";
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!Checks.NameLength(textBox7.Text, 10) || !Checks.NameSofiot(textBox7.Text))
            {
                if (textBox7.Text.Length == 0)
                {
                    textBox7.BackColor = Color.Green;
                    label16.ForeColor = Color.Green;
                    label16.Text = "תקין";
                }
                else
                {
                    textBox7.BackColor = Color.Red;
                    label16.ForeColor = Color.Red;
                    label16.Text = "תיאור לא תקין";
                }
            }
            else
            {
                textBox7.BackColor = Color.Green;
                label16.ForeColor = Color.Green;
                label16.Text = "תקין";
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CarTypes WHERE Name='" + textBox8.Text + "'";
            if (!MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                textBox8.BackColor = Color.Red;
                label17.ForeColor = Color.Red;
                label17.Text = "סוג זה לא תקין";
            }
            else
            {
                textBox8.BackColor = Color.Green;
                label17.ForeColor = Color.Green;
                label17.Text = "תקין";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "הוסף ספק")
            {
                ShowSupplier f = new ShowSupplier("3", dataGridView1);
                FormInPanel.AddForm(Form1.mainp, f);
            }
            else
            {
                if (label23.Text == "תקין" && label24.Text == "תקין")
                {
                    dataGridView1[2, index].Value = comboBox2.Text;
                    dataGridView1[3, index].Value = comboBox3.Text;
                }
                else
                {
                    MessageBox.Show("עליך לתקן את פרטי הספק");
                    return;
                }
            }
            comboBox1.ReadOnly = true;
            comboBox2.ReadOnly = true;
            comboBox3.ReadOnly = true;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox2.BackColor = SystemColors.Window;
            label23.ForeColor = Color.Black;
            label23.Text = "";
            comboBox3.BackColor = SystemColors.Window;
            label24.ForeColor = Color.Black;
            label24.Text = "";
            button4.Text = "הוסף ספק";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.BackColor = Color.Red;
                label10.ForeColor = Color.Red;
                label10.Text = "מחיר זה לא תקין";
            }
            else
            {
                textBox3.BackColor = Color.Green;
                label10.ForeColor = Color.Green;
                label10.Text = "תקין";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            dlg.Title = "Select Product Image";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                f = false;
                picLoc = dlg.FileName;
                pictureBox1.ImageLocation = picLoc;
                pictureBox1.Visible = true;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            f = false;
            pictureBox1.Visible = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox1.ImageLocation = "";
        }

        private void AddItem_Load(object sender, EventArgs e)
        {

        }
        int index = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                comboBox1.ReadOnly = true;
                comboBox2.ReadOnly = true;
                comboBox3.ReadOnly = true;
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox2.BackColor = SystemColors.Window;
                label23.ForeColor = Color.Black;
                label23.Text = "";
                comboBox3.BackColor = SystemColors.Window;
                label24.ForeColor = Color.Black;
                label24.Text = "";
                button4.Text = "הוסף ספק";
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    comboBox1.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                    comboBox2.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                    comboBox3.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                    comboBox1.ReadOnly = false;
                    comboBox2.ReadOnly = false;
                    comboBox3.ReadOnly = false;
                    button4.Text = "עדכן ספק";
                    index = e.RowIndex;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                if (string.IsNullOrEmpty(textBox6.Text) || int.Parse(textBox5.Text) >= int.Parse(textBox6.Text))
                {
                    textBox6.Text = (int.Parse(textBox5.Text) + 1).ToString();
                }
                textBox5.BackColor = Color.Green;
                label21.ForeColor = Color.Green;
                label21.Text = "תקין";
            }
            else
            {
                textBox5.BackColor = Color.Red;
                label21.ForeColor = Color.Red;
                label21.Text = "כמות זו לא תקינה";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox6.Text))
            {
                if (string.IsNullOrEmpty(textBox5.Text) || int.Parse(textBox5.Text) >= int.Parse(textBox6.Text))
                {
                    if (int.Parse(textBox6.Text) != 0)
                        textBox5.Text = (int.Parse(textBox6.Text) - 1).ToString();
                    else
                    {
                        textBox6.Text = "1";
                    }
                }
                textBox6.BackColor = Color.Green;
                label22.ForeColor = Color.Green;
                label22.Text = "תקין";
            }
            else
            {
                textBox6.BackColor = Color.Red;
                label22.ForeColor = Color.Red;
                label22.Text = "כמות זו לא תקינה";
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.BackColor = Color.Red;
                label23.ForeColor = Color.Red;
                label23.Text = "מספר קטלוגי זה לא תקין";
            }
            else
            {
                string sql = "SELECT * FROM Unions WHERE SupplierNumber='" + comboBox1.Text + "' AND ItemNumberAtSupplier='" + comboBox2.Text + "'";
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql) && MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql).Rows[0]["ItemNumber"].ToString() + MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql).Rows[0]["SupplierNumber"].ToString() != textBox1.Text + comboBox1.Text)
                {
                    comboBox2.BackColor = Color.Red;
                    label23.ForeColor = Color.Red;
                    label23.Text = "מספר קטלוגי של ספק זה קיים";
                }
                else
                {
                    comboBox2.BackColor = Color.Green;
                    label23.ForeColor = Color.Green;
                    label23.Text = "תקין";
                }
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox3.Text))
            {
                comboBox3.BackColor = Color.Red;
                label24.ForeColor = Color.Red;
                label24.Text = "מחיר זה לא תקין";
            }
            else
            {
                comboBox3.BackColor = Color.Green;
                label24.ForeColor = Color.Green;
                label24.Text = "תקין";
            }
        }
    }
}
