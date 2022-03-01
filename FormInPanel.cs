using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace OsherProject
{
    class FormInPanel
    {
        public static void AddForm(Control p, Form f)
        {
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            p.Controls.Add(f);
            f.Show();
        }
    }
}