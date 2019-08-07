using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUtilites
{
    public partial class MainForm : Form
    {

        int count = 0;
        Random rnd;
        char[] spec = new char[] { '#', '$', '%', '^', '&', '*', ')', '~', '?' };

        public MainForm()
        {
            InitializeComponent();
            rnd = new Random();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа \"мои утилиты\" содержит ряд небольших программ, которые могут пригодиться в жизни.\n A главное, научат меня основам программирования на С#.\n Автор: Усов Александр.", "О программе");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            count++;
            lblCount.Text = count.ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            count--;
            lblCount.Text = count.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            count = 0;
            lblCount.Text = count.ToString();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int n;
            n = rnd.Next((int)numericUpDown1.Value, (int)numericUpDown2.Value + 1);
            lblRandom.Text = n.ToString();
            if (chbRandom.Checked == true)
            {
                if(tbRandom.Text.IndexOf(n.ToString()) == -1)
                {
                    tbRandom.AppendText(n + "\n");
                }
            }
            else tbRandom.AppendText(n + "\n"); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbRandom.Clear();
        }

        private void btnPandomCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbRandom.Text);
        }

        private void tsmiInsertDate_Click(object sender, EventArgs e)
        {
            rtbNotePad.AppendText(DateTime.Now.ToShortDateString() + "\n");
        }

        private void tsmiInsertTime_Click(object sender, EventArgs e)
        {
            rtbNotePad.AppendText(DateTime.Now.ToShortTimeString() + "\n");
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotePad.SaveFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохрнении");
            }
        }

        private void tsmiLoad_Click(object sender, EventArgs e)
        {
            try
            {
                rtbNotePad.LoadFile("notepad.rtf");
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке");
            }
        }

        private void btnCreatePassword_Click(object sender, EventArgs e)
        {
            if (clbPassword.CheckedItems.Count == 0) return;
            string password = "";
            for(int i = 0; i < nudPassLength.Value; i++)
            {
                int n = rnd.Next(0, clbPassword.CheckedItems.Count);
                string s = clbPassword.CheckedItems[n].ToString();
                switch (s)
                {
                    case "Цифры": password += rnd.Next(10).ToString();
                        break;
                    case "Прописные буквы":
                        password += Convert.ToChar(rnd.Next(65, 88));
                        break;
                    case "Строчные буквы":
                        password += Convert.ToChar(rnd.Next(97, 122));
                        break;
                    default:
                        password += spec[rnd.Next(spec.Length)];
                        break;

                }
                tbPassword.Text = password;
                Clipboard.SetText(password);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            clbPassword.SetItemChecked(0, true);
            clbPassword.SetItemChecked(1, true);
        }
    }
}
