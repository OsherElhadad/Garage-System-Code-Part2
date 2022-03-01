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
    public partial class ItemsBySupplierReport : Form
    {
        public ItemsBySupplierReport()
        {
            InitializeComponent();
            Design.Designer(this);
            Sets.SetGeneral(comboBox1);
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

        private void ItemsBySupplierReport_Load(object sender, EventArgs e)
        {
            string sql2 = "SELECT distinct SupplierNumber FROM Items, Unions, CarTypes WHERE Items.ItemNumber = Unions.ItemNumber AND CarTypes.ID=CarType AND Unions.Active='True' order by SupplierNumber";
            DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.DataSource = dt2;
            comboBox1.ValueMember = "SupplierNumber";
            comboBox1.Text = "";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                string sql1 = "SELECT Items.ItemNumber AS 'מספר פריט', SupplierNumber AS 'מספר ספק', ItemNumberAtSupplier AS 'מספר פריט אצל ספק', PriceList AS 'מחירון', PriceFromSupplier AS 'מחיר מהספק', ItemName AS 'שם פריט', Amount AS 'כמות', MaxAmount AS 'כמות מקסימום', MinAmount AS 'כמות מינימום', Description AS 'תיאור', CarTypes.Name AS 'סוג רכב' FROM Items, Unions, CarTypes WHERE Items.ItemNumber = Unions.ItemNumber AND CarTypes.ID=CarType AND SupplierNumber LIKE'" + comboBox1.Text + "%' AND Unions.Active='True' order by Items.ItemNumber";
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
    }
}
