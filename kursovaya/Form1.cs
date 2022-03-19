using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Library;


namespace kursovaya
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Stalker> stalkers = new List<Stalker>();
        List<Scientist> scientists = new List<Scientist>();
        List<Militarian> militarians = new List<Militarian>();
        private void goNext2(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(ref stalkers);
            f2.Show();
        }

        private void goNext3(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(ref scientists);
            f3.Show();
        }

        private void goNext4(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(ref militarians);
            f4.Show();
        }

        private void goNext5(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(ref stalkers, ref scientists, ref militarians);
            f5.Show();
        }
    }
    
}
