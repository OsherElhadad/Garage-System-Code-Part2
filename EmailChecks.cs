using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace OsherProject
{
    class EmailChecks
    {
        public static bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            string chars = "abcdefghijklmnopqrstvuwxyzABCDEFGHIJKLMNOPQRSTVUWXYZ-.0123456789_@";
            foreach (char c in email)
                if (!chars.Contains(c))
                    return false;
            if (!match.Success)
                return false;
            if (email.Length < 6)
                return false;
            if (!((email.Split('@').Length == 2) && (email.Split('@')[1].Split('.').Length < 5) && (email.Split('@')[1].IndexOf('_') == -1) && (email.Split('@')[1].IndexOf('.') != -1)))
                return false;
            string notstart = "0123456789.-_";
            for (int i = 0; i < notstart.Length; i++)
                for (int j = 0; j < email.Split('@').Length; j++)
                    if ((email.Split('@')[j][0] == notstart[i]) && (email.Split('@')[j][email.Split('@')[j].Length - 1] == notstart[i]))
                        return false;
            string notnear = ".-_";
            for (int j = 0; j < email.Split('@').Length; j++)
            {
                if (email.Split('@')[j].Length > 0 && (notnear.IndexOf(email.Split('@')[j][0]) != -1 || notnear.IndexOf(email.Split('@')[j][email.Split('@')[j].Length - 1]) != -1))
                    return false;
            }
            for (int i = 1; i < email.Length - 1; i++)
            {
                if ((notnear.IndexOf(email[i]) != -1) && ((notnear.IndexOf(email[i - 1]) != -1) || (notnear.IndexOf(email[i + 1]) != -1)))
                    return false;
            }
            return (match.Success);
        }
        public static void SetOnlyEmail(TextBox t)
        {
            t.KeyPress += new KeyPressEventHandler(t_KeyPress);
        }

        private static void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                return;
            }
            string chars = "abcdefghijklmnopqrstvuwxyzABCDEFGHIJKLMNOPQRSTVUWXYZ-.0123456789_@";
            if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                if (chars.IndexOf(e.KeyChar.ToString()[0]) == -1)
                {
                    e.Handled = true;
                }
        }
        public static bool SendEmail(string To, string Subject, string Body)
        {
            //MailMessage msg = new MailMessage();

            //msg.From = new MailAddress("radiatorgarage@gmail.com");
            //msg.To.Add(To);
            //msg.IsBodyHtml = true;
            //msg.Subject = Subject + "מוסך לרדיאטורים";
            //string htmlBody = "";

            //htmlBody += "<html>";
            //htmlBody += "<body dir = 'rtl'>";
            //htmlBody += "    <div id='header' style='width: 100%;";
            //htmlBody += "            padding: 35px;";
            //htmlBody += "            background: #00CC99;";
            //htmlBody += "            color: #fff;";
            //htmlBody += "            font-size: 30px;";
            //htmlBody += "            margin-bottom: 50px;'>מוסך לרדיאטורים</div>";
            //htmlBody += "    <div id='content' style='";
            //htmlBody += "            background: #fafafa;";
            //htmlBody += "            padding: 20px;";
            //htmlBody += "            width: 80%;";
            //htmlBody += "            max-width: 540px;";
            //htmlBody += "            margin: 0 auto;color:#222222;'>";

            //htmlBody += Body;

            //htmlBody += "    </div>";
            //htmlBody += "</body>";
            //htmlBody += "</html>";

            //msg.Body = htmlBody;
            //SmtpClient client = new SmtpClient();
            //client.UseDefaultCredentials = true;
            //client.Host = "smtp.gmail.com";
            //client.Port = 587;
            //client.EnableSsl = true;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.Credentials = new System.Net.NetworkCredential("radiatorgarage@gmail.com", "radiator123!");
            //client.Timeout = 20000;
            //try
            //{
            //    client.Send(msg);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
            try
            {
                string from = "radiatorgarage@gmail.com";
                string password = "radiator123!";

                //string from = "radiators121@gmail.com";
                //string password = "12123344radiator";

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(from);
                mail.To.Add(To);
                mail.Subject = Subject + "מוסך לרדיאטורים";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = "";

                htmlBody += "<html>";
                htmlBody += "<body dir = 'rtl'>";
                htmlBody += "    <div id='header' style='width: 100%;";
                htmlBody += "            padding: 35px;";
                htmlBody += "            background: #00CC99;";
                htmlBody += "            color: #fff;";
                htmlBody += "            font-size: 30px;";
                htmlBody += "            margin-bottom: 50px;'>מוסך לרדיאטורים</div>";
                htmlBody += "    <div id='content' style='";
                htmlBody += "            background: #fafafa;";
                htmlBody += "            padding: 20px;";
                htmlBody += "            width: 80%;";
                htmlBody += "            max-width: 540px;";
                htmlBody += "            margin: 0 auto;color:#222222;'>";

                htmlBody += Body;

                htmlBody += "    </div>";
                htmlBody += "</body>";
                htmlBody += "</html>";

                mail.Body = htmlBody;

                //SmtpServer.UseDefaultCredentials = true;
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                //SmtpServer.Timeout = 20000;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(from, password);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;


                //// kobbi's: else101@walla.co.il
                //// yariv's: yariv.amiasaf@gmail.com

            }
            catch
            {
                return false;
            }
        }
    }
}
