using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace OsherProject
{
    public partial class CustomersGraphicReport : Form
    {
        public bool flag1 = true, flag2 = false;
        public string sql = "";
        public Series MySeries = new Series();
        public CustomersGraphicReport()
        {
            InitializeComponent();
            Design.Designer(this);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                flag1 = false;
                flag2 = true;
            }
            else
            {
                flag2 = false;
                flag1 = true;
            }
            chart1.Series.Clear();
            MySeries.Points.Clear();
            chart1.Series.Add(MySeries);
            if (flag1)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                MySeries.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisX.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisY.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].AxisX2.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].BackColor = Color.White;
            }
            else if (flag2)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                chart1.Series[0]["PieLineColor"] = "White";
                chart1.Series[0].Font = new Font("Tahoma", 16f);
                chart1.Series[0].LabelForeColor = Color.White;
                chart1.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#6464FA");
            }

            if (comboBox1.Text == "פילוג על פי גילאים")
            {
                string[] counter;
                for (int i = 18; i < 69; i = i + 10)
                {
                    if (i != 68)
                    {
                        sql = "SELECT COUNT(CustomerBirthDate) FROM Customers WHERE (CustomerBirthDate < '" + DateTime.Today.AddYears(-i).ToString("MM/dd/yyyy") + "') AND (CustomerBirthDate > '" + DateTime.Today.AddYears(-i - 9).ToString("MM/dd/yyyy") + "')";
                        counter = MyAdoHelperCsharp.returnIFonlyoneLine("Database1.mdf", sql);
                        MySeries.Points.AddXY(i + "-" + (i + 9), counter[0]);
                    }
                    else
                    {
                        sql = "SELECT COUNT(CustomerBirthDate) FROM Customers WHERE CustomerBirthDate < '" + DateTime.Today.AddYears(-i + 1).ToString("MM/dd/yyyy") + "'";
                        counter = MyAdoHelperCsharp.returnIFonlyoneLine("Database1.mdf", sql);
                        MySeries.Points.AddXY("67+", counter[0]);
                    }
                    chart1.Visible = true;
                }
            }
            else if (comboBox1.Text == "פילוג על פי מספר מכירות")
            {
                string sql2 = "SELECT DISTINCT Customers.CustomerFName AS Fname, Customers.CustomerLName AS Lname FROM Cars, Sales, Customers WHERE Sales.CarNumber=Cars.CarNumber AND Cars.CustomerID!='' AND Cars.CustomerID=Customers.CustomerID";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    sql = "SELECT COUNT(t1.Num) AS Number FROM (SELECT DISTINCT SaleNumber, Customers.CustomerFName AS Fname, Sales.CarNumber AS Num, Customers.CustomerLName AS Lname FROM Cars, Sales, Customers WHERE Sales.CarNumber=Cars.CarNumber AND Cars.CustomerID!='' AND Cars.CustomerID=Customers.CustomerID AND CustomerFName='" + dt2.Rows[i]["FName"].ToString() + "' AND CustomerLName='" + dt2.Rows[i]["LName"].ToString() + "' AND Sales.Active='false' AND Sales.Active2='true') t1";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    if (flag2)
                    {
                        MySeries.Points.AddXY(dt2.Rows[i]["FName"].ToString() + " " + dt2.Rows[i]["LName"].ToString() + " " + dt.Rows[0]["Number"].ToString() + " מכירות ללקוח זה", dt.Rows[0]["Number"].ToString());
                    }
                    else
                    {
                        MySeries.Points.AddXY(dt2.Rows[i]["FName"].ToString() + " " + dt2.Rows[i]["LName"].ToString(), dt.Rows[0]["Number"].ToString());
                    }
                }
                chart1.Visible = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                flag1 = false;
                flag2 = true;
            }
            else
            {
                flag2 = false;
                flag1 = true;
            }
            chart1.Series.Clear();
            MySeries.Points.Clear();
            chart1.Series.Add(MySeries);
            if (flag1)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                MySeries.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisX.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisY.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].AxisX2.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].BackColor = Color.White;
            }
            else if (flag2)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                chart1.Series[0]["PieLineColor"] = "White";
                chart1.Series[0].Font = new Font("Tahoma", 16f);
                chart1.Series[0].LabelForeColor = Color.White;
                chart1.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#6464FA");
            }

            if (comboBox1.Text == "פילוג על פי גילאים")
            {
                string[] counter;
                for (int i = 18; i < 69; i = i + 10)
                {
                    if (i != 68)
                    {
                        sql = "SELECT COUNT(CustomerBirthDate) FROM Customers WHERE (CustomerBirthDate < '" + DateTime.Today.AddYears(-i).ToString("MM/dd/yyyy") + "') AND (CustomerBirthDate > '" + DateTime.Today.AddYears(-i - 9).ToString("MM/dd/yyyy") + "')";
                        counter = MyAdoHelperCsharp.returnIFonlyoneLine("Database1.mdf", sql);
                        MySeries.Points.AddXY(i + "-" + (i + 9), counter[0]);
                    }
                    else
                    {
                        sql = "SELECT COUNT(CustomerBirthDate) FROM Customers WHERE CustomerBirthDate < '" + DateTime.Today.AddYears(-i + 1).ToString("MM/dd/yyyy") + "'";
                        counter = MyAdoHelperCsharp.returnIFonlyoneLine("Database1.mdf", sql);
                        MySeries.Points.AddXY("67+", counter[0]);
                    }
                    chart1.Visible = true;
                }
            }
            else if (comboBox1.Text == "פילוג על פי מספר מכירות")
            {
                string sql2 = "SELECT DISTINCT Customers.CustomerFName AS Fname, Customers.CustomerLName AS Lname FROM Cars, Sales, Customers WHERE Sales.CarNumber=Cars.CarNumber AND Cars.CustomerID!='' AND Cars.CustomerID=Customers.CustomerID";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    sql = "SELECT COUNT(t1.Num) AS Number FROM (SELECT DISTINCT SaleNumber, Customers.CustomerFName AS Fname, Sales.CarNumber AS Num, Customers.CustomerLName AS Lname FROM Cars, Sales, Customers WHERE Sales.CarNumber=Cars.CarNumber AND Cars.CustomerID!='' AND Cars.CustomerID=Customers.CustomerID AND CustomerFName='" + dt2.Rows[i]["FName"].ToString() + "' AND CustomerLName='" + dt2.Rows[i]["LName"].ToString() + "' AND Sales.Active='false' AND Sales.Active2='true') t1";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    if (flag2)
                    {
                        MySeries.Points.AddXY(dt2.Rows[i]["FName"].ToString() + " " + dt2.Rows[i]["LName"].ToString() + " " + dt.Rows[0]["Number"].ToString() + " מכירות ללקוח זה", dt.Rows[0]["Number"].ToString());
                    }
                    else
                    {
                        MySeries.Points.AddXY(dt2.Rows[i]["FName"].ToString() + " " + dt2.Rows[i]["LName"].ToString(), dt.Rows[0]["Number"].ToString());
                    }
                }
                chart1.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            MySeries.Points.Clear();
            chart1.Series.Add(MySeries);
            if (flag1)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                MySeries.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Black;
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Tahoma", 14f);
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisX.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisY.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].AxisX2.MajorGrid.LineWidth = 2;
                chart1.ChartAreas[0].BackColor = Color.White;
            }
            else if (flag2)
            {
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                chart1.Series[0]["PieLineColor"] = "White";
                chart1.Series[0].Font = new Font("Tahoma", 16f);
                chart1.Series[0].LabelForeColor = Color.White;
                chart1.ChartAreas[0].BackColor = ColorTranslator.FromHtml("#6464FA");
            }

            if (comboBox1.Text == "פילוג על פי גילאים")
            {
                string[] counter;
                for (int i = 18; i < 69; i = i + 10)
                {
                    if (i != 68)
                    {
                        sql = "SELECT COUNT(CustomerBirthDate) FROM Customers WHERE (CustomerBirthDate < '" + DateTime.Today.AddYears(-i).ToString("MM/dd/yyyy") + "') AND (CustomerBirthDate > '" + DateTime.Today.AddYears(-i - 9).ToString("MM/dd/yyyy") + "')";
                        counter = MyAdoHelperCsharp.returnIFonlyoneLine("Database1.mdf", sql);
                        MySeries.Points.AddXY(i + "-" + (i + 9), counter[0]);
                    }
                    else
                    {
                        sql = "SELECT COUNT(CustomerBirthDate) FROM Customers WHERE CustomerBirthDate < '" + DateTime.Today.AddYears(-i + 1).ToString("MM/dd/yyyy") + "'";
                        counter = MyAdoHelperCsharp.returnIFonlyoneLine("Database1.mdf", sql);
                        MySeries.Points.AddXY("67+", counter[0]);
                    }
                    chart1.Visible = true;
                }
            }
            else if (comboBox1.Text == "פילוג על פי מספר מכירות")
            {
                string sql2 = "SELECT DISTINCT Customers.CustomerFName AS Fname, Customers.CustomerLName AS Lname FROM Cars, Sales, Customers WHERE Sales.CarNumber=Cars.CarNumber AND Cars.CustomerID!='' AND Cars.CustomerID=Customers.CustomerID";
                DataTable dt2 = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql2);
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    sql = "SELECT COUNT(t1.Num) AS Number FROM (SELECT DISTINCT SaleNumber, Customers.CustomerFName AS Fname, Sales.CarNumber AS Num, Customers.CustomerLName AS Lname FROM Cars, Sales, Customers WHERE Sales.CarNumber=Cars.CarNumber AND Cars.CustomerID!='' AND Cars.CustomerID=Customers.CustomerID AND CustomerFName='" + dt2.Rows[i]["FName"].ToString() + "' AND CustomerLName='" + dt2.Rows[i]["LName"].ToString() + "' AND Sales.Active='false' AND Sales.Active2='true') t1";
                    DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                    if (flag2)
                    {
                        MySeries.Points.AddXY(dt2.Rows[i]["FName"].ToString() + " " + dt2.Rows[i]["LName"].ToString() + " " + dt.Rows[0]["Number"].ToString() + " מכירות ללקוח זה", dt.Rows[0]["Number"].ToString());
                    }
                    else
                    {
                        MySeries.Points.AddXY(dt2.Rows[i]["FName"].ToString() + " " + dt2.Rows[i]["LName"].ToString(), dt.Rows[0]["Number"].ToString());
                    }
                }
                chart1.Visible = true;
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

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
    }
}
