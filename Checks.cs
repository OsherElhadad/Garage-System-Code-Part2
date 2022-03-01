using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Data;
namespace OsherProject
{
    class Checks
    {

        public static bool isnum(char x)
        {
            return (x >= '0' && x <= '9');
        }

        public static bool isletter(char c)
        {
            char x = Convert.ToChar(c.ToString());
            return (x >= 'א' && x <= 'ת');
        }

        public static int Max(TextBox t,string column,string sql)
        {
            int max;
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            if (dt.Rows.Count > 0)
            {
                max = int.Parse(dt.Rows[0][column].ToString());
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (int.Parse(dt.Rows[i][column].ToString()) > max)
                        max = int.Parse(dt.Rows[i][column].ToString());
                }
                max = max + 1;
            }
            else
                max = 1;
            t.Text = max.ToString();
            return max;
        }

        public static int Max2(string sql)
        {
            int max;
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            if (dt.Rows.Count > 0)
            {
                max = int.Parse(dt.Rows[0][0].ToString());
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    if (int.Parse(dt.Rows[i][0].ToString()) > max)
                        max = int.Parse(dt.Rows[i][0].ToString());
                }
                max = max + 1;
            }
            else
                max = 1;
            return max;
        }

        public static void FillColumns(ComboBox c, string tablename)
        {
            string sql = "SELECT * FROM "+ tablename;
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            c.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            c.AutoCompleteSource = AutoCompleteSource.ListItems;
            int x = dt.Columns.Count - 1;
            for (int i = 0; i < x; i++)
            {
                c.Items.Add(dt.Columns[i].ToString());
            }
            c.Text = "";
        }
        public static void FillColumns(ComboBox c, string sql, string a)
        {
            DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
            c.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            c.AutoCompleteSource = AutoCompleteSource.ListItems;
            int x = dt.Columns.Count - 1;
            for (int i = 0; i < x; i++)
            {
                c.Items.Add(dt.Columns[i].ToString());
            }
            c.Text = "";
        }
        public static void SetGeneral(TextBox t8)
        {
            t8.KeyPress += new KeyPressEventHandler(t8_KeyPress);
        }

        static void t8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == "'"[0] || e.KeyChar == '"')
            {
                e.Handled = true;
                return;
            }
        }
        public static void SetGeneral(ComboBox t9)
        {
            t9.KeyPress += new KeyPressEventHandler(t9_KeyPress);
        }

        static void t9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == "'"[0] || e.KeyChar == '"')
            {
                e.Handled = true;
                return;
            }
        }
        public static void SetOnlyNumbers(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);
        }

        static void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((sender as TextBox).Text.Length==0&& e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (!isnum(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }
        public static void SetOnlyID(TextBox t12)
        {
            t12.KeyPress += new KeyPressEventHandler(t12_KeyPress);
        }

        static void t12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (!isnum(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }
        public static void SetOnlyID(ComboBox t13)
        {
            t13.KeyPress += new KeyPressEventHandler(t13_KeyPress);
        }

        static void t13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (!isnum(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }

        public static void SetOnlyNumbers(ComboBox c)
        {
            c.KeyPress += new KeyPressEventHandler(c_KeyPress);
        }

        static void c_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as ComboBox).Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (!isnum(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }

        public static void SetOnlyNumbersAndHebrow(TextBox t2)
        {
            t2.KeyPress += new KeyPressEventHandler(t2_KeyPress);
        }

        static void t2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (!isnum(e.KeyChar.ToString()[0]) || !isletter(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }

        public static void SetOnlyHebrow(TextBox t1)
        {
            t1.KeyPress += new KeyPressEventHandler(t1_KeyPress);
        }

        static void t1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space && e.KeyChar != '-' && e.KeyChar != '.')
                if (!isletter(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }

        public static void SetOnlyHebrow(ComboBox c1)
        {
            c1.KeyPress += new KeyPressEventHandler(c1_KeyPress);
        }

        static void c1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ניתן להוסיף בדיקה אם לא מספר
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space && e.KeyChar != '-')
                if (!isletter(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
        }

        public static bool IsID(string id)
        {
            if (id.Length != 9)
                return false;
            int sum = 0;
            int num = 0;
            int sumnum;
            for (int i = 0; i < id.Length; i++)
            {
                num = int.Parse(id[i].ToString());
                if (i % 2 == 0)
                {
                    sumnum = 0;
                    while (num > 0)
                    {
                        sumnum += num % 10;
                        num = num / 10;
                    }
                }
                else
                {
                    num = num * 2;
                    sumnum = 0;
                    while (num > 0)
                    {
                        sumnum += num % 10;
                        num = num / 10;
                    }
                }
                sum += sumnum;
            }
            if (sum % 10 != 0)
                return false;
            return true;
        }

        public static void SetOnlyAdressNum(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t3_KeyPress);
        }

        private static void t3_KeyPress(object sender, KeyPressEventArgs e)
        {
            AddressNumber((TextBox)sender, e);
        }

        public static void AddressNumber(TextBox t, KeyPressEventArgs e)
        {
            string str = t.Text;
            string sofiot = "ףךםץן";
            if (str.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }
            string chars = "אבגדהוזחטיכלמנסעפצקרשת0123456789";
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (chars.IndexOf(e.KeyChar.ToString()[0]) == -1)
                {
                    e.Handled = true;
                    return;
                }
            if (e.KeyChar==' ')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Right || e.KeyChar == (char)Keys.Left)
                e.Handled = true;
            else
            {
                if (str.Length == 0)
                {
                    if (char.IsLetter(e.KeyChar))
                        e.Handled = true;
                }
                if (str.Length != 0)
                {
                    if (char.IsLetter(str[0]))
                    {
                        if (e.KeyChar != (char)Keys.Back)
                            if (!char.IsDigit(e.KeyChar))
                                e.Handled = true;
                    }
                    else
                    {
                        if (char.IsLetter(str[str.Length - 1]) && e.KeyChar != (char)Keys.Back)
                            e.Handled = true;
                        else
                        {
                            if (str.Length != 3)
                            {
                                if (char.IsDigit(e.KeyChar) || (char.IsLetter(e.KeyChar) && sofiot.IndexOf(e.KeyChar) == -1 && (e.KeyChar <= 'ת' && e.KeyChar >= 'א') || e.KeyChar == (char)Keys.Back))
                                    e.Handled = false;
                                else
                                    e.Handled = true;
                            }
                            else
                            {
                                if (char.IsDigit(e.KeyChar))
                                    e.Handled = true;
                                else
                                {
                                    if (char.IsLetter(e.KeyChar) && sofiot.IndexOf(e.KeyChar) == -1 && (e.KeyChar <= 'ת' && e.KeyChar >= 'א') || e.KeyChar == (char)Keys.Back)
                                        e.Handled = false;
                                    else
                                        e.Handled = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void SetOnlyCarNum(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t10_KeyPress);
        }

        private static void t10_KeyPress(object sender, KeyPressEventArgs e)
        {
            CarNumber((TextBox)sender, e);
        }
        public static void SetOnlyCarNum(ComboBox t30)
        {
            t30.KeyPress += new KeyPressEventHandler(t30_KeyPress);
        }

        private static void t30_KeyPress(object sender, KeyPressEventArgs e)
        {
            CarNumber((ComboBox)sender, e);
        }
        public static void CarNumber(ComboBox t, KeyPressEventArgs e)
        {
            string str = t.Text;
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
            {
                if (str.Length == 0 || str.Length == 1 || str.Length == 3 || str.Length == 4 || str.Length == 5 || str.Length == 7 || str.Length == 8)
                {
                    if (isnum(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    if (str.Length == 2 || str.Length == 6)
                    {
                        if (e.KeyChar == '-')
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                }
            }
        }
        public static void CarNumber(TextBox t, KeyPressEventArgs e)
        {
            string str = t.Text;
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
            {
                if (str.Length == 0 || str.Length == 1 || str.Length == 3 || str.Length == 4 || str.Length == 5 || str.Length == 7 || str.Length == 8)
                {
                    if (isnum(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    if (str.Length == 2 || str.Length == 6)
                    {
                        if (e.KeyChar == '-')
                            e.Handled = false;
                        else
                            e.Handled = true;
                    }
                }
            }
        }

        public static void SetOnlyNumbersAndPoint(TextBox t4)
        {
            t4.KeyPress += new KeyPressEventHandler(t4_KeyPress);
        }

        static void t4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Length == 0 && e.KeyChar == '0')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
                if (!isnum(e.KeyChar.ToString()[0]))
                {
                    e.Handled = true;
                }
            TextBox text = (TextBox)sender;
            string str = text.Text;
            if (str.Length == 0)
            {
                if (e.KeyChar == '.')
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    if (str.Split('.').Length == 2)
                        if (e.KeyChar == '.')
                            e.Handled = true;
                    if (str.Split('.').Length != 2)
                    {
                        if (str.Split('.')[0].Length == 6)
                        {
                            if (e.KeyChar != '.')
                                e.Handled = true;
                        }
                    }
                    else
                    {
                        if (str.Split('.')[1].Length > 1)
                            e.Handled = true;
                        if (str[str.Length - 1] == '.' && e.KeyChar == '.')
                            e.Handled = true;
                    }
                }
            }
        }

        public static bool validchar(string str,string tavim)
        {
            char tav;
            for (int i = 0; i < str.Length; i++)
            {
                tav = str[i];
                if (tavim.IndexOf(tav) == -1)
                    return false;
            }
            return true;
        }

        public static bool NameSofiot(string name)
        {
            string[] spliterName = name.Split(' ');
            string sofiot = "ףךםץן";
            string losofiot = "נצמכפ";
            char tav;
            for (int i = 0; i < spliterName.Length; i++)
            {
                if (spliterName[i].Length != 0 && (!(i == spliterName.Length - 1 && spliterName[i] == "בעמ")) && losofiot.IndexOf(spliterName[i][spliterName[i].Length - 1]) != -1)
                    return false;
                for (int j = 0; j < spliterName[i].Length - 1; j++)
                {
                    tav = spliterName[i][j];
                    if (sofiot.IndexOf(tav) != -1 && (spliterName[i][j + 1] != '-' || spliterName[i][j + 1] != '.'))
                        return false;
                }
            }
            spliterName = name.Split('-');
            for (int i = 0; i < spliterName.Length - 1; i++)
            {
                if (spliterName[i].Length != 0 && losofiot.IndexOf(spliterName[i][spliterName[i].Length - 1]) != -1)
                    return false;
                for (int j = 0; j < spliterName[i].Length - 1; j++)
                {
                    tav = spliterName[i][j];
                    if ((spliterName.Length != 1 && sofiot.IndexOf(tav) != -1) && (spliterName[i][j + 1] != ' ' || spliterName[i][j + 1] != '.'))
                        return false;
                }
            }
            spliterName = name.Split('.');
            for (int i = 0; i < spliterName.Length - 1; i++)
            {
                if (spliterName[i].Length != 0 && (!(i == spliterName.Length - 1 && spliterName[i] == "בעמ")) && losofiot.IndexOf(spliterName[i][spliterName[i].Length - 1]) != -1)
                    return false;
                for (int j = 0; j < spliterName[i].Length - 1; j++)
                {
                    tav = spliterName[i][j];
                    if ((spliterName.Length != 1 && sofiot.IndexOf(tav) != -1) && (spliterName[i][j + 1] != ' ' || spliterName[i][j + 1] != '-'))
                        return false;
                }
            }
            for (int i = 1; i < name.Length; i++)
                if ((name[i] == ' ' && name[i - 1] == '-') || (name[i] == ' ' && name[i - 1] == '.') || (name[i] == '-' && name[i - 1] == '.') || (name[i] == '-' && name[i - 1] == ' ') || (name[i] == '.' && name[i - 1] == ' ') || (name[i] == '.' && name[i - 1] == '-') || (name[i] == '.' && name[i - 1] == '.') || (name[i] == '-' && name[i - 1] == '-') || (name[i] == ' ' && name[i - 1] == ' '))
                    return false;
            return true;
        }

        public static bool NameLength(string name, int num)
        {
            string[] spliterName = name.Split(' ');
            bool f = true;
            for (int i = 0; i < spliterName.Length && f; i++)
                if (spliterName[i].Length < 2)
                    f = false;
            if (spliterName.Length > num)
                f = false;
            spliterName = name.Split('-');
            for (int i = 0; i < spliterName.Length && f; i++)
                if (spliterName[i].Length < 2)
                    f = false;
            if (spliterName.Length > num)
                f = false;
            spliterName = name.Split('.');
            for (int i = 0; i < spliterName.Length && f; i++)
                if (spliterName[i].Length < 1)
                    f = false;
            if (spliterName.Length > num)
                f = false;
            if (f)
                return true;
            else
                return false;
        }
        public static string GetCityNum(string text)
        {
            string sql = "SELECT * FROM Cities WHERE Name='" + text + "'";
            if (MyAdoHelperCsharp.IsExist("Database1.mdf", sql))
            {
                DataTable dt = MyAdoHelperCsharp.ExecuteDataTable("Database1.mdf", sql);
                return dt.Rows[0]["ID"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
