using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErtevMasaustu
{
    public partial class SecondWindow : Form
    {
        public string a;
        public string mod;
        basvur bsv = new basvur();
        basvurCRUD crud = new basvurCRUD();
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                bsv.Ad = textBox1.Text;
                bsv.Soyad = textBox2.Text;
                bsv.Mail = textBox3.Text;   
                bsv.Tel = textBox4.Text;
                bsv.Date = Convert.ToDateTime(textBox5.Text);
                a = crud.guncelle(bsv);
                MessageBox.Show("Güncelleme Başarılı");
                this.Close();
                MainWindow mainWindow = (MainWindow)Application.OpenForms["MainWindow"];
                mod = mainWindow.label4.Text;
                if(mod == "Liste Modu: Günlük Liste")
                    mainWindow.button3_Click(sender, e);
                else if (mod == "Liste Modu: Tüm Liste")
                    mainWindow.button4_Click(sender, e);
            }
            else
                MessageBox.Show("Boş Alan Bırakılamaz");
            
        }

        public void SecondWindow_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = crud.getir(a);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            textBox4.Text = dt.Rows[0][3].ToString();
            textBox5.Text = Convert.ToDateTime(dt.Rows[0][5]).ToShortDateString();
        }
    }
}
