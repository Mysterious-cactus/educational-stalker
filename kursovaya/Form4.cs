using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace kursovaya
{
    public partial class Form4 : Form
    {
        protected int bolt = 0;
        protected int bread = 0;
        protected int medicine = 0;
        List<Militarian> militarians_f4 = new List<Militarian>();
        public Form4(ref List<Militarian> militarians)
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            label1.Parent = pictureBox1; label2.Parent = pictureBox1; label3.Parent = pictureBox1; label4.Parent = pictureBox1;
            label5.Parent = pictureBox1; label6.Parent = pictureBox1; label8.Parent = pictureBox1;
            comboBox1.SelectedIndex = 0;
            militarians_f4 = militarians;
            foreach (var mil1 in militarians_f4)
            {
                ListViewItem lvi1 = new ListViewItem(new string[] {mil1.Name, mil1.DateOfBirth.ToShortDateString(), mil1.ShowReputation().ToString(),
                    mil1.Rank, mil1.ReturnHealth().Endurance.ToString(), mil1.ReturnHealth().Immunity.ToString(), mil1.ReturnInventory().Bolt.ToString(),
                    mil1.ReturnInventory().Medicine.ToString(), mil1.ReturnInventory().Bread.ToString()});
                listView1.Items.Add(lvi1);
            }
        }

        private void goBack(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addNewMilitarian(object sender, EventArgs e)
        {
            Militarian mil1;
            Inventory in1 = new Inventory(bread, bolt, medicine);
            if (textBox1.Text != "")
            {
                mil1 = new Militarian(dateTimePicker1.Value.Date, (int)numericUpDown1.Value, comboBox1.SelectedItem.ToString(), in1, textBox1.Text);
                militarians_f4.Add(mil1);
                ListViewItem lvi1 = new ListViewItem(new string[] {mil1.Name, mil1.DateOfBirth.ToShortDateString(), mil1.ShowReputation().ToString(),
                    mil1.Rank, mil1.ReturnHealth().Endurance.ToString(), mil1.ReturnHealth().Immunity.ToString(), mil1.ReturnInventory().Bolt.ToString(),
                    mil1.ReturnInventory().Medicine.ToString(), mil1.ReturnInventory().Bread.ToString()});
                listView1.Items.Add(lvi1);
            }
            else
            {
                mil1 = new Militarian(dateTimePicker1.Value.Date, (int)numericUpDown1.Value, comboBox1.SelectedItem.ToString(), in1);
                militarians_f4.Add(mil1);
                ListViewItem lvi1 = new ListViewItem(new string[] {mil1.Name, mil1.DateOfBirth.ToShortDateString(), mil1.ShowReputation().ToString(),
                    mil1.Rank, mil1.ReturnHealth().Endurance.ToString(), mil1.ReturnHealth().Immunity.ToString(), mil1.ReturnInventory().Bolt.ToString(),
                    mil1.ReturnInventory().Medicine.ToString(), mil1.ReturnInventory().Bread.ToString()});
                listView1.Items.Add(lvi1);
            }
        }

        private void plusBolt(object sender, EventArgs e)
        {
            bolt += 1;
            label5.Text = "болтов:  " + bolt.ToString();
        }

        private void plusMedicine(object sender, EventArgs e)
        {
            medicine += 1;
            label6.Text = "аптечек:  " + medicine.ToString();
        }

        private void plusBread(object sender, EventArgs e)
        {
            bread += 1;
            label8.Text = "батонов:  " + bread.ToString();
        }

        private void clearAll(object sender, EventArgs e)
        {
            bolt = 0;
            bread = 0;
            medicine = 0;
            label5.Text = "болтов:  0";
            label6.Text = "аптечек:  0";
            label8.Text = "батонов:  0";
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            comboBox1.SelectedIndex = 0;
        }

        
    }
}
