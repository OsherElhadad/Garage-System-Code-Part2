using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyChecks
{
    class NumbersChecks
    {
        public static void SetPhone(TextBox t)
        {
            t.MaxLength = 7;
            DigitsChecks.SetOnlyDigits(t);
        }

        public static void SetFax(TextBox t)
        {
            t.MaxLength = 7;
            DigitsChecks.SetOnlyDigits(t);
        }

        public static void SetZipCode(TextBox t)
        {
            t.MaxLength = 7;
            DigitsChecks.SetOnlyDigits(t);
        }

        public static void SetId(TextBox t)
        {
            t.MaxLength = 9;
            DigitsChecks.SetOnlyDigits(t);
        }

        public static bool IsVailId(TextBox t)
        {
            int mone = 0;
            int incNum;
            if (t.Text.Length == 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    incNum = Convert.ToInt32(t.Text[i].ToString());
                    incNum *= (i % 2) + 1;
                    if (incNum > 9)
                        incNum -= 9;
                    mone += incNum;
                }
                return (mone % 10 == 0);
            }
            else
            {
                MessageBox.Show("אורך תעודת זהות קטן מ9");
                return false;
            }
        }
    }
}

