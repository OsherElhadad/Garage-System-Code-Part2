using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
namespace OsherProject
{
    public partial class Catalogue : Form
    {
        int len;
        int index = 0;
        Translate tran = new Translate();
        string select = "";
        bool f = false;
        string searchi = "";
        string searchw = "";
        public Catalogue()
        {
            InitializeComponent();
            Sets.SetGeneral(comboBox1);
            Sets.SetGeneral(comboBox2);
            pictureBox1.Height = pictureBox1.Height + 5;
            pictureBox1.Width = pictureBox1.Height;
            pictureBox2.Height = pictureBox2.Height + 5;
            pictureBox2.Width = pictureBox2.Height;
            Design.Designer(this);
            timer1.Enabled = true;
            string sql1 = "SELECT * FROM Items";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            len = dt1.Rows.Count;
            if (len == 0)
                this.Close();
            string sql = "SELECT * FROM Items WHERE ItemNumber='" + (index + 1) + "'";
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            label2.Text = dt.Rows[0]["ItemNumber"].ToString();
            label4.Text = dt.Rows[0]["ItemName"].ToString();
            label6.Text = dt.Rows[0]["Amount"].ToString();
            label8.Text = dt.Rows[0]["Description"].ToString();
            string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[0]["CarType"].ToString() + "'";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            label10.Text = dt2.Rows[0]["Name"].ToString();
            label12.Text = dt.Rows[0]["PriceList"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["Picture"].ToString()))
            {
                byte[] tempimg = (byte[])dt.Rows[0]["Picture"];
                MemoryStream tempstream = new MemoryStream(tempimg);
                Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                pictureBox1.Image = RoundedImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                panel1.Width = 0;
                timer1.Enabled = true;
            }
            if (index < len - 1)
            {
                index++;
                string sql3 = "SELECT * FROM Items WHERE ItemNumber='" + (index + 1) + "'";
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                label14.Text = dt3.Rows[0]["ItemNumber"].ToString();
                label16.Text = dt3.Rows[0]["ItemName"].ToString();
                label18.Text = dt3.Rows[0]["Amount"].ToString();
                label20.Text = dt3.Rows[0]["Description"].ToString();
                string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt3.Rows[0]["CarType"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                label22.Text = dt4.Rows[0]["Name"].ToString();
                label24.Text = dt3.Rows[0]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt3.Rows[0]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt3.Rows[0]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox2.Image = RoundedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel2.Width = 0;
                    timer2.Enabled = true;
                }
            }
            else
            {
                panel2.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
                label17.Visible = false;
                label19.Visible = false;
                label21.Visible = false;
                label23.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
                label18.Visible = false;
                label20.Visible = false;
                label22.Visible = false;
                label24.Visible = false;
            }
        }
        public Catalogue(string a, string searchby, string searchwith)
        {
            InitializeComponent();
            Sets.SetGeneral(comboBox1);
            Sets.SetGeneral(comboBox2);
            f = true;
            tran.Add("ItemNumber", "מספר פריט");
            tran.Add("ItemName", "שם פריט");
            tran.Add("Amount", "כמות");
            tran.Add("Description", "תיאור");
            tran.Add("PriceList", "מחירון");
            Design.Designer(this);
            searchi = searchby;
            searchw = searchwith;
            comboBox1.Text = searchby;
            comboBox2.Text = searchwith;
            select = a;
            timer1.Enabled = true;
            string sql1 = "SELECT * FROM Items WHERE " + select;
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            len = dt1.Rows.Count;
            if (len == 0)
                this.Close();
            string sql = "SELECT * FROM Items WHERE " + select;
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            label2.Text = dt.Rows[index]["ItemNumber"].ToString();
            label4.Text = dt.Rows[index]["ItemName"].ToString();
            label6.Text = dt.Rows[index]["Amount"].ToString();
            label8.Text = dt.Rows[index]["Description"].ToString();
            string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[index]["CarType"].ToString() + "'";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            label10.Text = dt2.Rows[0]["Name"].ToString();
            label12.Text = dt.Rows[index]["PriceList"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[index]["Picture"].ToString()))
            {
                byte[] tempimg = (byte[])dt.Rows[index]["Picture"];
                MemoryStream tempstream = new MemoryStream(tempimg);
                Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                pictureBox1.Image = RoundedImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                panel1.Width = 0;
                timer1.Enabled = true;
            }
            if (index < len - 1)
            {
                index++;
                string sql3 = "SELECT * FROM Items WHERE " + select;
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                label14.Text = dt3.Rows[index]["ItemNumber"].ToString();
                label16.Text = dt3.Rows[index]["ItemName"].ToString();
                label18.Text = dt3.Rows[index]["Amount"].ToString();
                label20.Text = dt3.Rows[index]["Description"].ToString();
                string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt3.Rows[index]["CarType"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                label22.Text = dt4.Rows[0]["Name"].ToString();
                label24.Text = dt3.Rows[index]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt3.Rows[index]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt3.Rows[index]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox2.Image = RoundedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel2.Width = 0;
                    timer2.Enabled = true;
                }
            }
            else
            {
                panel2.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
                label17.Visible = false;
                label19.Visible = false;
                label21.Visible = false;
                label23.Visible = false;
                label14.Visible = false;
                label16.Visible = false;
                label18.Visible = false;
                label20.Visible = false;
                label22.Visible = false;
                label24.Visible = false;
            }
        }
        public static Image RoundCorners(Image StartImage, int CornerRadius, Color BackgroundColor)
        {
            CornerRadius *= 2;
            Bitmap RoundedImage = new Bitmap(StartImage.Width, StartImage.Height);
            Graphics g = Graphics.FromImage(RoundedImage);
            g.Clear(BackgroundColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush brush = new TextureBrush(StartImage);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddArc(0, 0, CornerRadius, CornerRadius, 180, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0, CornerRadius, CornerRadius, 270, 90);
            gp.AddArc(0 + RoundedImage.Width - CornerRadius, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            gp.AddArc(0, 0 + RoundedImage.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            g.FillPath(brush, gp);
            return RoundedImage;
        }

        private void Catalogue_Load(object sender, EventArgs e)
        {
            tran.Add("ItemNumber", "מספר פריט");
            tran.Add("ItemName", "שם פריט");
            tran.Add("Amount", "כמות");
            tran.Add("Description", "תיאור");
            tran.Add("PriceList", "מחירון");
            string sql1 = "SELECT ItemNumber AS 'מספר פריט', PriceList AS 'מחירון', ItemName AS 'שם פריט', Amount AS 'כמות', Description AS 'תיאור' FROM Items";
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            int x = dt.Columns.Count;
            for (int i = 0; i < x; i++)
                comboBox1.Items.Add(dt.Columns[i].ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel1.Width >= tableLayoutPanel1.Width * 0.3788)
                timer1.Enabled = false;
            else
                panel1.Width += 5;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panel2.Width >= tableLayoutPanel1.Width * 0.3788)
                timer1.Enabled = false;
            else
                panel2.Width += 5;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            timer5.Enabled = false;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            timer4.Enabled = true;
            timer6.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!f)
            {
                if (len == 1)
                    return;
                if (index == 1)
                    index = len - 1;
                else
                {
                    if (index == 0)
                        index = len - 2;
                    else
                        index = index - 2;
                }
                string sql3 = "SELECT * FROM Items WHERE ItemNumber='" + (index + 1) + "'";
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                label14.Text = dt3.Rows[0]["ItemNumber"].ToString();
                label16.Text = dt3.Rows[0]["ItemName"].ToString();
                label18.Text = dt3.Rows[0]["Amount"].ToString();
                label20.Text = dt3.Rows[0]["Description"].ToString();
                string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt3.Rows[0]["CarType"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                label22.Text = dt4.Rows[0]["Name"].ToString();
                label24.Text = dt3.Rows[0]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt3.Rows[0]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt3.Rows[0]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox2.Image = RoundedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel2.Width = 0;
                    timer2.Enabled = true;
                }
                else
                {
                    panel2.Width = 0;
                    timer2.Enabled = false;
                }
                if (index == 0)
                    index = len - 1;
                else
                    index--;
                string sql5 = "SELECT * FROM Items WHERE ItemNumber='" + (index + 1) + "'";
                DataTable dt5 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                label2.Text = dt5.Rows[0]["ItemNumber"].ToString();
                label4.Text = dt5.Rows[0]["ItemName"].ToString();
                label6.Text = dt5.Rows[0]["Amount"].ToString();
                label8.Text = dt5.Rows[0]["Description"].ToString();
                string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt5.Rows[0]["CarType"].ToString() + "'";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                label10.Text = dt2.Rows[0]["Name"].ToString();
                label12.Text = dt5.Rows[0]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt5.Rows[0]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt5.Rows[0]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox1.Image = RoundedImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Width = 0;
                    timer1.Enabled = true;
                }
                else
                {
                    panel1.Width = 0;
                    timer1.Enabled = false;
                }
                index++;
            }
            else
            {
                if (len == 1)
                    return;
                if (index == 1)
                    index = len - 1;
                else
                {
                    if (index == 0)
                        index = len - 2;
                    else
                        index = index - 2;
                }
                string sql3 = "SELECT * FROM Items WHERE " + select;
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                label14.Text = dt3.Rows[index]["ItemNumber"].ToString();
                label16.Text = dt3.Rows[index]["ItemName"].ToString();
                label18.Text = dt3.Rows[index]["Amount"].ToString();
                label20.Text = dt3.Rows[index]["Description"].ToString();
                string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt3.Rows[index]["CarType"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                label22.Text = dt4.Rows[0]["Name"].ToString();
                label24.Text = dt3.Rows[index]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt3.Rows[index]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt3.Rows[index]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox2.Image = RoundedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel2.Width = 0;
                    timer2.Enabled = true;
                }
                else
                {
                    panel2.Width = 0;
                    timer2.Enabled = false;
                }
                if (index == 0)
                    index = len - 1;
                else
                    index--;
                string sql5 = "SELECT * FROM Items WHERE " + select;
                DataTable dt5 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql5);
                label2.Text = dt5.Rows[index]["ItemNumber"].ToString();
                label4.Text = dt5.Rows[index]["ItemName"].ToString();
                label6.Text = dt5.Rows[index]["Amount"].ToString();
                label8.Text = dt5.Rows[index]["Description"].ToString();
                string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt5.Rows[index]["CarType"].ToString() + "'";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                label10.Text = dt2.Rows[0]["Name"].ToString();
                label12.Text = dt5.Rows[index]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt5.Rows[index]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt5.Rows[index]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox1.Image = RoundedImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Width = 0;
                    timer1.Enabled = true;
                }
                else
                {
                    panel1.Width = 0;
                    timer1.Enabled = false;
                }
                index++;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!f)
            {
                if (index == len - 1)
                    index = 0;
                else
                    index++;
                string sql = "SELECT * FROM Items WHERE ItemNumber='" + (index + 1) + "'";
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                label2.Text = dt.Rows[0]["ItemNumber"].ToString();
                label4.Text = dt.Rows[0]["ItemName"].ToString();
                label6.Text = dt.Rows[0]["Amount"].ToString();
                label8.Text = dt.Rows[0]["Description"].ToString();
                string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[0]["CarType"].ToString() + "'";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                label10.Text = dt2.Rows[0]["Name"].ToString();
                label12.Text = dt.Rows[0]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[0]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt.Rows[0]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox1.Image = RoundedImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Width = 0;
                    timer1.Enabled = true;
                }
                else
                {
                    panel1.Width = 0;
                    timer1.Enabled = false;
                }
                if (index == len - 1)
                    index = 0;
                else
                    index++;
                string sql3 = "SELECT * FROM Items WHERE ItemNumber='" + (index + 1) + "'";
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                label14.Text = dt3.Rows[0]["ItemNumber"].ToString();
                label16.Text = dt3.Rows[0]["ItemName"].ToString();
                label18.Text = dt3.Rows[0]["Amount"].ToString();
                label20.Text = dt3.Rows[0]["Description"].ToString();
                string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt3.Rows[0]["CarType"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                label22.Text = dt4.Rows[0]["Name"].ToString();
                label24.Text = dt3.Rows[0]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt3.Rows[0]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt3.Rows[0]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox2.Image = RoundedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel2.Width = 0;
                    timer2.Enabled = true;
                }
                else
                {
                    panel2.Width = 0;
                    timer2.Enabled = false;
                }
            }
            else
            {
                if (index == len - 1)
                    index = 0;
                else
                    index++;
                string sql = "SELECT * FROM Items WHERE " + select;
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                label2.Text = dt.Rows[index]["ItemNumber"].ToString();
                label4.Text = dt.Rows[index]["ItemName"].ToString();
                label6.Text = dt.Rows[index]["Amount"].ToString();
                label8.Text = dt.Rows[index]["Description"].ToString();
                string sql2 = "SELECT * FROM CarTypes WHERE ID='" + dt.Rows[index]["CarType"].ToString() + "'";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                label10.Text = dt2.Rows[0]["Name"].ToString();
                label12.Text = dt.Rows[index]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt.Rows[index]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt.Rows[index]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox1.Image = RoundedImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel1.Width = 0;
                    timer1.Enabled = true;
                }
                else
                {
                    panel1.Width = 0;
                    timer1.Enabled = false;
                }
                if (index == len - 1)
                    index = 0;
                else
                    index++;
                string sql3 = "SELECT * FROM Items WHERE " + select;
                DataTable dt3 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql3);
                label14.Text = dt3.Rows[index]["ItemNumber"].ToString();
                label16.Text = dt3.Rows[index]["ItemName"].ToString();
                label18.Text = dt3.Rows[index]["Amount"].ToString();
                label20.Text = dt3.Rows[index]["Description"].ToString();
                string sql4 = "SELECT * FROM CarTypes WHERE ID='" + dt3.Rows[index]["CarType"].ToString() + "'";
                DataTable dt4 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql4);
                label22.Text = dt4.Rows[0]["Name"].ToString();
                label24.Text = dt3.Rows[index]["PriceList"].ToString();
                if (!string.IsNullOrEmpty(dt3.Rows[index]["Picture"].ToString()))
                {
                    byte[] tempimg = (byte[])dt3.Rows[index]["Picture"];
                    MemoryStream tempstream = new MemoryStream(tempimg);
                    Image RoundedImage = Images.CropCircle2(Images.PadImage(Image.FromStream(tempstream)));
                    pictureBox2.Image = RoundedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    panel2.Width = 0;
                    timer2.Enabled = true;
                }
                else
                {
                    panel2.Width = 0;
                    timer2.Enabled = false;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Height >= 1000)
                timer3.Enabled = false;
            else
                pictureBox3.Height += 15;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (pictureBox4.Height >= 1000)
                timer4.Enabled = false;
            else
                pictureBox4.Height += 15;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            timer5.Enabled = true;
            timer3.Enabled = false;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (pictureBox3.Height <= 150)
                timer5.Enabled = false;
            else
                pictureBox3.Height -= 15;
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            if (pictureBox4.Height <= 150)
                timer6.Enabled = false;
            else
                pictureBox4.Height -= 15;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            timer6.Enabled = true;
            timer4.Enabled = false;
        }
        static int count = 0;
        bool flag = false;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag = false;
            string sql1 = "SELECT distinct ";
            sql1 += tran.Find(comboBox1.Text) + " FROM Items";
            sql1 += " order by ";
            sql1 += tran.Find(comboBox1.Text);
            comboBox2.DataSource = new List<string>();
            comboBox2.ValueMember = "";
            string g = comboBox2.Text;
            comboBox2.Text = "";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.DataSource = dt1;
            comboBox2.ValueMember = tran.Find(comboBox1.Text);
            comboBox2.Text = g;
            flag = true;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (count == 1)
            {
                count = 0;
                return;
            }
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text) && flag && ((comboBox1.Text == searchi && comboBox2.Text != searchw) || (comboBox1.Text != searchi)) && comboBox1.SelectedIndex >= 0 && comboBox1.Items[comboBox1.SelectedIndex].ToString() == comboBox1.Text)
            {
                string sql1 = "SELECT ItemNumber, PriceList, ItemName, Amount, Description FROM Items WHERE ";
                string s = tran.Find(comboBox1.Text) + " LIKE'" + comboBox2.Text + "%'";
                sql1 += tran.Find(comboBox1.Text) + " LIKE'" + comboBox2.Text + "%'";
                if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql1))
                {
                    Catalogue f = new Catalogue(s, comboBox1.Text, comboBox2.Text);
                    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                    count++;
                    FormInPanel.AddForm(Form1.mainp, f);
                }
            }
        }
    }
}
