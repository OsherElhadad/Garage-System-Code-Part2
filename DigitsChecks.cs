using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyChecks
{
    class DigitsChecks
    {
        public static void SetOnlyDigits(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);
        }

        static void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Back)
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
        }

        public static bool IsDigits(char c)
        {
            return char.IsDigit(c);
        }
    }
}
