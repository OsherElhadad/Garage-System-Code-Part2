using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OsherProject
{
    class Design
    {
        public static void Designer(Form form)
        {
            UserLogIn.myforms.Add(form);
            form.TopMost = true;
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;
            form.BackColor= ColorTranslator.FromHtml("#6464FA");
            form.Font= new Font("Tahoma", 15);
            foreach (Control c in form.Controls)
            {
                if (c.Controls.Count > 0)
                    PanelInPanel(c);
                else if (c is Button)
                {
                    Button temp = c as Button;
                    temp.FlatStyle = FlatStyle.Flat;
                    temp.Font = new Font("Tahoma", 15);
                    temp.FlatAppearance.BorderColor = Color.White;
                    temp.FlatAppearance.BorderSize = 1;
                    temp.ForeColor = Color.White;
                    temp.Height = 40;
                }
            }
        }

        public static void Design1(Control c)
        {
            if (c is Button)
            {
                Button temp = c as Button;
                temp.FlatStyle = FlatStyle.Flat;
                temp.Font = new Font("Tahoma", 15);
                temp.FlatAppearance.BorderColor = Color.White;
                temp.FlatAppearance.BorderSize = 1;
                temp.ForeColor = Color.White;
                temp.Height = 40;
            }
        }

        public static void PanelInPanel(Control c)
        {
            foreach (Control c1 in c.Controls)
            {
                if (c1.Controls.Count > 0)
                    PanelInPanel(c1);
                else
                    Design1(c1);
            }
        }

        public static string DayOfTheWeek(string day)
        {
            string myday = "";
            switch (day)
            {
                case "Sunday":
                    myday = "יום א'";
                    break;
                case "Monday":
                    myday = "יום ב'";
                    break;
                case "Tuesday":
                    myday = "יום ג'";
                    break;
                case "Wednesday":
                    myday = "יום ד'";
                    break;
                case "Thursday":
                    myday = "יום ה'";
                    break;
                case "Friday":
                    myday = "יום ו'";
                    break;
                case "Saturday":
                    myday = "יום ש'";
                    break;
            }
            return myday;
        }
    }
}
