using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OsherProject
{
    class EnglishChecks
    {
        public static void SetOnlyEnglish(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);
        }

        private static void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (e.KeyChar.ToString().ToLower().ToCharArray()[0] > 'z' || e.KeyChar.ToString().ToLower().ToCharArray()[0] < 'a')
                {
                    e.Handled = true;
                }
        }

        public static void SetFirstLetter(TextBox t)
        {
            t.LostFocus += new EventHandler(t_TextChanged);
        }

        static void t_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 0)
                if (IsLetter(((TextBox)sender).Text[0]))
                {
                    System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                    System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;

                    ((TextBox)sender).Text = textInfo.ToTitleCase(((TextBox)sender).Text.ToLower());
                }
        }

        public static bool IsLetter(char c)
        {
            return c.ToString().ToLower().ToCharArray()[0] <= 'z' && c.ToString().ToLower().ToCharArray()[0] >= 'a';
        }
    }
}
