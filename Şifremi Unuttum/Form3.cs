using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Şifremi_Unuttum
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential("ynsaltinn@gmail.com", "******");

            string konu = "ŞİFRE HATIRLATMA";
            string icerik = "ŞİFRENİZ: qwerty123";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ynsaltinn@gmail.com", "Yunus Altın");
            mail.To.Add(textBox1.Text);
            mail.Subject = konu;
            mail.Body = icerik;
            sc.Send(mail);
        }
    }
}
