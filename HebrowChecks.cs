using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyChecks
{
    class HebrowChecks
    {
        public static void SetOnlyHebrow(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);
        }

        static void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (e.KeyChar.ToString().ToCharArray()[0] > 'ת' || e.KeyChar.ToString().ToCharArray()[0] < 'א')
                {
                    e.Handled = true;
                }       
        }

        public static bool IsLetter(char c)
        {
            return c.ToString().ToCharArray()[0] >= 'א' && c.ToString().ToLower().ToCharArray()[0] <= 'ת';
        }
    }
}
