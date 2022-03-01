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
    public partial class Form1 : Form
    {
        public static Panel mainp;
        public Form1()
        {
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());
            if (UserLogIn.name == "")
            {
                LogIn f = new LogIn();
                f.ShowDialog();
            }
            if (UserLogIn.per == "1")
            {
                דוחותושאילתותToolStripMenuItem.Enabled = false;
                תוכניותשירותToolStripMenuItem.Enabled = false;
                ספקיםToolStripMenuItem.Enabled = false;
                מכירותToolStripMenuItem.Enabled = false;
                עובדיםToolStripMenuItem.Enabled = false;
                שאילתותToolStripMenuItem.Enabled = false;
            }
            if (UserLogIn.per == "2")
            {
                תוכניותשירותToolStripMenuItem.Enabled = false;
                ספקיםToolStripMenuItem.Enabled = false;
                עובדיםToolStripMenuItem.Enabled = false;
            }
            timer1.Start();
            mainp = panel1;
            UserLogIn.myforms.Add(this);
        }

        private void הוספהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomer f = new AddCustomer();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomer f = new ShowCustomer("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomer f = new ShowCustomer("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCustomer f = new ShowCustomer();
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספהToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddGarage f = new AddGarage();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowGarage f = new ShowGarage("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowGarage f = new ShowGarage("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowGarage f = new ShowGarage();
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספהToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddSupplier f = new AddSupplier();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowSupplier f = new ShowSupplier("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowSupplier f = new ShowSupplier("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowSupplier f = new ShowSupplier();
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספהToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AddSale f = new AddSale();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowSale f = new ShowSale("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowSale f = new ShowSale("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowSale f = new ShowSale();
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספהToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AddAccount f = new AddAccount();
            f.StartPosition = FormStartPosition.CenterScreen;
            Util.Animate(f, Util.Effect.Slide, 500, 800);
        }

        private void עדכוןToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ShowAccount f = new ShowAccount("1");
            f.StartPosition = FormStartPosition.CenterScreen;
            Util.Animate(f, Util.Effect.Slide, 500, 800);
        }

        private void מחיקהToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ShowAccount f = new ShowAccount("2");
            f.StartPosition = FormStartPosition.CenterScreen;
            Util.Animate(f, Util.Effect.Slide, 500, 800);
        }

        private void הצגהToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ShowAccount f = new ShowAccount();
            f.StartPosition = FormStartPosition.CenterScreen;
            Util.Animate(f, Util.Effect.Slide, 500, 800);
        }

        private void הוספהToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AddOrder f = new AddOrder();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ShowOrder f = new ShowOrder("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ShowOrder f = new ShowOrder("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ShowOrder f = new ShowOrder();
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספהToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            AddEmployee f = new AddEmployee();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ShowEmployee f = new ShowEmployee("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ShowEmployee f = new ShowEmployee("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ShowEmployee f = new ShowEmployee();
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספהToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            AddItem f = new AddItem("a");
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ShowItem f = new ShowItem("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקהToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ShowItem f = new ShowItem("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            ShowItem f = new ShowItem();
            FormInPanel.AddForm(panel1, f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה לסגור", "סגירה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void הוספתרכבToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCar f = new AddCar("c");
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןרכבToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCar f = new ShowCar("1", "c");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקתרכבToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCar f = new ShowCar("2", "c");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ShowCar f = new ShowCar("c");
            FormInPanel.AddForm(panel1, f);
        }

        private void הוספתרכבToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCar f = new AddCar("g");
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןרכבToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowCar f = new ShowCar("1", "g");
            FormInPanel.AddForm(panel1, f);
        }

        private void מחיקתרכבToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowCar f = new ShowCar("2", "g");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגהToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            ShowCar f = new ShowCar("g");
            FormInPanel.AddForm(panel1, f);
        }

        private void בקרתקבלתהזמנהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlGetOrder f = new ControlGetOrder();
            FormInPanel.AddForm(panel1, f);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = OsherProject.Properties.Resources.minus7775;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = OsherProject.Properties.Resources.close777;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = OsherProject.Properties.Resources.minus75;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = OsherProject.Properties.Resources.close7;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = Design.DayOfTheWeek(DateTime.Now.DayOfWeek + "") + ", " + DateTime.Now + "";
            if (UserLogIn.name != "")
            {
                label2.Text = "שלום " + UserLogIn.name;
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = OsherProject.Properties.Resources.back777;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = OsherProject.Properties.Resources.back7;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!UserLogIn.myforms[UserLogIn.myforms.Count - 1].Name.Equals("Form1"))
            {
                DialogResult r = MessageBox.Show("?האם אתה בטוח שאתה רוצה לצאת מהפעולה", "יציאה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    UserLogIn.myforms[UserLogIn.myforms.Count - 1].Close();
                    UserLogIn.myforms.Remove(UserLogIn.myforms[UserLogIn.myforms.Count - 1]);
                }
            }
        }

        private void הוספתהזמנהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrder f = new AddOrder();
            FormInPanel.AddForm(panel1, f);
        }

        private void עדכוןפרטיהזמנהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrder f = new ShowOrder("1");
            FormInPanel.AddForm(panel1, f);
        }

        private void ביטולהזמנהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrder f = new ShowOrder("2");
            FormInPanel.AddForm(panel1, f);
        }

        private void הצגתהזמנהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrder f = new ShowOrder();
            FormInPanel.AddForm(panel1, f);
        }

        private void בקרתקבלתהזמנהToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ControlGetOrder f = new ControlGetOrder();
            FormInPanel.AddForm(panel1, f);
        }

        private void קטלוגToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Catalogue f = new Catalogue();
            FormInPanel.AddForm(panel1, f);
        }

        private void סיוםמכירהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FinishSale f = new FinishSale();
            FormInPanel.AddForm(panel1, f);
        }

        private void רשימותנגללותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DynamicComboBox f = new DynamicComboBox();
            FormInPanel.AddForm(panel1, f);
        }

        private void שליחתמיילToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mail f = new Mail();
            FormInPanel.AddForm(panel1, f);
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = OsherProject.Properties.Resources.logout2;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = OsherProject.Properties.Resources.logout;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Restart();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ItemsBySupplierReport f = new ItemsBySupplierReport();
            FormInPanel.AddForm(panel1, f);
        }

        private void פריטלפיספקToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemBySupplierQuery f = new ItemBySupplierQuery();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SuppliersByCityReport f = new SuppliersByCityReport();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SupplierByCityQuery f = new SupplierByCityQuery();
            FormInPanel.AddForm(panel1, f);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SalesByDatesReport f = new SalesByDatesReport();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            OrdersByDatesReport f = new OrdersByDatesReport();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            SalesByDatesQuery f = new SalesByDatesQuery();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            OrdersByDatesQuery f = new OrdersByDatesQuery();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            CustomersGraphicReport f = new CustomersGraphicReport();
            FormInPanel.AddForm(panel1, f);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            SalesGraphicQuery f = new SalesGraphicQuery();
            FormInPanel.AddForm(panel1, f);
        }

        private void שליחתמיילחגשמחלכלהלקוחותוהמוסכיםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql= "SELECT CustomerEmail, CustomerFName, CustomerLName FROM Customers";
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            for(int i=0;i<dt.Rows.Count;i++)
            {
                EmailChecks.SendEmail(dt.Rows[i]["CustomerEmail"].ToString(), "חג שמח מ", "חג שמח ל" + dt.Rows[i]["CustomerFName"].ToString() + " " + dt.Rows[i]["CustomerLName"].ToString() + ", מאחלים ממוסך הרדיאטורים");
            }
            string sql1 = "SELECT GarageEmail, GarageName FROM Garages";
            DataTable dt1 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                EmailChecks.SendEmail(dt1.Rows[i]["GarageEmail"].ToString(), "חג שמח מ", "חג שמח ל" + dt1.Rows[i]["GarageName"].ToString() + ", מאחלים ממוסך הרדיאטורים");
            }
            MessageBox.Show("מייל חג שמח נשלח בהצלחה לכל הלקוחות והמוסכים");
        }
    }
}
