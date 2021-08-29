using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negyedikheti
{
    public partial class Form1 : Form
    {
        Model mod;
        public Form1()
        {
            mod = new Model();
            InitializeComponent();
            button3.Text = "Exit";
            button1.Text = "New Game";
            button2.Text = "Leaderboard";
            button1.Enabled = false;
            textBox1.TextChanged += (s, e) =>
            {
                button1.Enabled = true;
            };
            button1.Click += (s, e) =>
            {
                Form2 form = new Form2(mod);
                form.Show();
                this.Hide();
                form.FormClosed += GameIsClosed;
            };

            button2.Click += (s, e) =>
            {
                Form3 form = new Form3(mod);
                form.Show();
                this.Hide();
                form.FormClosed += LeaderBoardIsClosed;
            };

            button3.Click += (s, e) =>
            {
                Application.Exit();
            };
        }
        private void GameIsClosed(object sender, FormClosedEventArgs e)
        {
            mod.Export(textBox1.Text, mod.PontImport());
            this.Show();
        }
        private void LeaderBoardIsClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
