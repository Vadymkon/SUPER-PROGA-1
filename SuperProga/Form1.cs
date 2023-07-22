using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperProga
{
    public partial class Form1 : Form
    {
        int k = 0;
        public Form1()
        {
            InitializeComponent();
            Loading();
        }

        async void Loading()
        {
            int b = 1;

        Script:
            Loading1();
            await Task.Delay(200);
            Loading2();

            if (b < 7) { b++; goto Script; } //для красивого разного мигания
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length != 0) label1.Text = Convert.ToInt32(textBox1.Text).ToString();
                Clipboard.Clear(); // очистить буфер
                Clipboard.SetText(Convert.ToInt32(textBox1.Text).ToString()); // закинуть туда вписанную цифру
            }
            catch (Exception ex1) 
            {
                int i = button1.Text == "button1" ? 10 : 2;
                button1.Text = i.ToString();
                ++k;
                label2.Text = k.ToString();
                Clipboard.Clear(); // очистить буфер
                Clipboard.SetText(ex1.ToString()); // закинуть туда вписанную ОШИБКУ
                try { progressBar1.Value = k; }
                catch { Close(); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Location.ToString();
            ++k;
            label2.Text = k.ToString();

            switch (k)
            {
                case 1: label3.Text = $"You tapped: {k}"; break;
                case 2: label3.Text = $"You tapped: {k}"; break;
                case 3: label3.Text = $"You tapped: {k}"; break;
                case 4: case 5: case 6: case 7: label3.Text = "why are you keep doing that thing..."; break;
                default: label3.Text =  "pervert."; break;
            }
            try { progressBar1.Value = k; }
            catch { Close(); }
        }

        
        async void Loading1()
        {

            while (true)
            {
                foreach (CheckBox cb in Controls.OfType<CheckBox>())
                {
                    cb.Visible = false;
                    await Task.Delay(100/2/2/2);
                    cb.Checked = true;
                    await Task.Delay(50/2/2/2);

                }
                foreach (CheckBox cb in Controls.OfType<CheckBox>())
                {
                    cb.Visible = true;
                    await Task.Delay(50/2/2/2);
                    cb.Checked = false;
                    await Task.Delay(100/2/2/2);
                }
            }


        }async void Loading2()
        {
            while (true)
            {
                foreach (CheckBox cb in Controls.OfType<CheckBox>())
                {

                    cb.BackColor = Color.MediumVioletRed;
                    await Task.Delay(2/2);
                }
                foreach (CheckBox cb in Controls.OfType<CheckBox>())
                {
                    cb.BackColor = Color.Black;
                    await Task.Delay(2/2);
                }
            }
        }
        async void Form1_MouseHover(object sender, EventArgs e)
        {



            while (true)
            {
                while (progressBar2.Value != progressBar2.Maximum)
                {
                    progressBar2.Value++;
                    label4.Text = (progressBar2.Value * 2).ToString();
                    await Task.Delay(1);
                }
                await Task.Delay(100);
                while (progressBar2.Value != progressBar2.Minimum)
                {
                    progressBar2.Value--;
                    label4.Text = (progressBar2.Value * 2).ToString();
                    await Task.Delay(1);
                }
            }
        }

        async void Form1_Load(object sender, EventArgs e)
        {
            for (Opacity = 0; Opacity < 0.98; Opacity += 0.05)
                await Task.Delay(1);
        }

        void GoToDirectory(string path)
        {
            Process.Start(new ProcessStartInfo{FileName = "explorer", Arguments = $"/n, /select, {path}"});
        }

        void button3_Click(object sender, EventArgs e)
        {
            string path = @"C:\Program Files (x86)";
            for (int i = 0; i< 5; i++) GoToDirectory(path);
        }
    }
}
