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
    public partial class Form2 : Form
    {
        protected int bolt = 0;
        protected int bread = 0;
        protected int medicine = 0;
        protected int artefact = 0;
        List<Stalker> stalkers_f2 = new List<Stalker>();
        public Form2(ref List<Stalker> stalkers)
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            label1.Parent = pictureBox1; label2.Parent = pictureBox1; label3.Parent = pictureBox1; label4.Parent = pictureBox1;
            label5.Parent = pictureBox1; label6.Parent = pictureBox1; label7.Parent = pictureBox1; label8.Parent = pictureBox1;
            comboBox1.SelectedIndex = 0;
            stalkers_f2 = stalkers;
            foreach (var st1 in stalkers_f2)
            {
                ListViewItem lvi1 = new ListViewItem(new string[] {st1.Name, st1.DateOfBirth.ToShortDateString(), st1.ShowReputation().ToString(),
                    st1.Gang, st1.ReturnHealth().Endurance.ToString(), st1.ReturnHealth().Immunity.ToString(), st1.ReturnInventory().Bolt.ToString(),
                    st1.ReturnInventory().Medicine.ToString(), st1.ReturnInventory().Artefacts.ToString(), st1.ReturnInventory().Bread.ToString()});
                listView1.Items.Add(lvi1);
            }
            
        }

        private void goBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewStalker(object sender, EventArgs e)
        {
            Stalker st1;
            Inventory in1 = new Inventory(bread, bolt, medicine, artefact);
            if (textBox1.Text != "")
            {
                st1 = new Stalker(dateTimePicker1.Value.Date, (int)numericUpDown1.Value, comboBox1.SelectedItem.ToString(), in1, textBox1.Text);
                stalkers_f2.Add(st1);
                ListViewItem lvi1 = new ListViewItem(new string[] {st1.Name, st1.DateOfBirth.ToShortDateString(), st1.ShowReputation().ToString(), 
                    st1.Gang, st1.ReturnHealth().Endurance.ToString(), st1.ReturnHealth().Immunity.ToString(), st1.ReturnInventory().Bolt.ToString(),
                    st1.ReturnInventory().Medicine.ToString(), st1.ReturnInventory().Artefacts.ToString(), st1.ReturnInventory().Bread.ToString()});
                listView1.Items.Add(lvi1);
            } else 
            {
                st1 = new Stalker(dateTimePicker1.Value.Date, (int)numericUpDown1.Value, comboBox1.SelectedItem.ToString(), in1);
                stalkers_f2.Add(st1);
                ListViewItem lvi1 = new ListViewItem(new string[] {st1.Name, st1.DateOfBirth.ToShortDateString(), st1.ShowReputation().ToString(),
                    st1.Gang, st1.ReturnHealth().Endurance.ToString(), st1.ReturnHealth().Immunity.ToString(), st1.ReturnInventory().Bolt.ToString(),
                    st1.ReturnInventory().Medicine.ToString(), st1.ReturnInventory().Artefacts.ToString(), st1.ReturnInventory().Bread.ToString()});
                listView1.Items.Add(lvi1);
            }
            GeneralInventory.Artefacts += artefact;
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

        private void plusArtefact(object sender, EventArgs e)
        {
            artefact += 1;
            label7.Text = "артефактов:  " + artefact.ToString();
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
            artefact = 0;
            label5.Text = "болтов:  0";
            label6.Text = "аптечек:  0";
            label7.Text = "артефактов:  0";
            label8.Text = "батонов:  0";
            textBox1.Text = "";
            numericUpDown1.Value = 0;
            comboBox1.SelectedIndex = 0;
        }
    }
}
