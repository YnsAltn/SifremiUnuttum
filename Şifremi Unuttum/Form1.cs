using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Contexts;

namespace Şifremi_Unuttum
{
    public partial class Form1 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-DORQ3O9;Initial Catalog=sifremiunuttum;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string KullaniciAd = textBox1.Text;
            string Sifre = textBox2.Text;
            bool kayitliMi = false;

            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM SifremiUnuttum ", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (KullaniciAd == oku["KullaniciAdi"].ToString() && Sifre == oku["Sifre"].ToString())
                {
                    kayitliMi = true;
                }
                else kayitliMi = false;
            }
            baglan.Close();

            if (kayitliMi == true)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
                this.Hide();
            }
            else MessageBox.Show("LÜTFEN BİLGİLERİNİZİ KONTROL EDİP TEKRAR GİRİŞ YAPMAYI DENEYİNİZ", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            this.Hide();
        }
    }
}
