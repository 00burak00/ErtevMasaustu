using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErtevMasaustu
{
    public partial class MainWindow : Form
    {
        
        basvur bsv = new basvur();
        basvurCRUD crud = new basvurCRUD();
        int a = 1;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = crud.getirall();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listBox1.Items.Add(dt.Rows[i][0] + " " + dt.Rows[i][1]);
                listBox2.Items.Add(dt.Rows[i][3]);

            }
            label4.Text = "Liste Modu: Tüm Liste";
            timer1.Stop();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           WindowState =  FormWindowState.Normal;
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                notifyIcon1.Visible=true;
            this.ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                bool a;
                a = crud.sil(listBox2.SelectedItem);
                if (a)
                    MessageBox.Show("Silme Başarılı");
                else
                    MessageBox.Show("Silme Başarısız");
                button3.PerformClick();
            }
            else
                MessageBox.Show("Telefon Bilgisini Seçmediniz");
           
        }
               
        public void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
            DataTable dt = new DataTable();
            dt = crud.listeleme();
            if(!(a == 1))
            {
                if (WindowState == FormWindowState.Minimized)
                {

                    if(listBox1.Items.Count < dt.Rows.Count)
                        {
                            notifyIcon1.ShowBalloonTip(1000);
                        }
                }
            }
            a = 0;
           
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listBox1.Items.Add( dt.Rows[i][0] + " " + dt.Rows[i][1]);
                listBox2.Items.Add(dt.Rows[i][3]);

            }
            label4.Text = "Liste Modu: Günlük Liste";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button3.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox2.SelectedIndex != -1)
            {
                SecondWindow secondWindow = new SecondWindow();
                secondWindow.a = listBox2.SelectedItem.ToString();
                secondWindow.Show();
            }
            else
                MessageBox.Show("Telefon Bilgisini Seçmediniz");
          
        }
    }
    }


