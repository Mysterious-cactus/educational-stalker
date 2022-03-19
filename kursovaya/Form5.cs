using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace kursovaya
{
    public partial class Form5 : Form
    {
        List<Militarian> militarians_f5 = new List<Militarian>();
        List<Scientist> scientists_f5 = new List<Scientist>();
        List<Stalker> stalkers_f5 = new List<Stalker>();
        List<Mutant> mutants_f5 = new List<Mutant>();
        public Form5( ref List<Stalker> stalkers, ref List<Scientist> scientists, ref List<Militarian> militarians)
        {
            FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
            label1.Parent = pictureBox1; label2.Parent = pictureBox1;
            militarians_f5 = militarians;
            scientists_f5 = scientists;
            stalkers_f5 = stalkers;
            RadioactRelease release = new RadioactRelease();
            release.Bang += DisplayResult1;
            release.Damage += DisplayResult2;
            release.Battle += DisplayResult3;
            release.Start();
        }

        private void goBack(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void DisplayResult1(object sender, RadioactReleaseEventArgs e)
        {
            await Task.Delay(1000);
            label2.Text = e.CalculateLevel();
            myTimer();
        }
        private async void DisplayResult2(object sender, DamageFromRadiationEventArgs e)
        {
            button2.Enabled = false;
            await Task.Delay(15000);
            label2.Text = "Получен урон от радиации:";
            listView1.Visible = true;
            foreach(var item in stalkers_f5)
            {
                await Task.Delay(1);
                int rnd = await GetMyRandom(10, 20);
                e.calculateDamage(item, rnd);
                ListViewItem lvi1 = new ListViewItem(new string[] {item.Name, item.Gang, item.ReturnHealth().Endurance.ToString(),
                    item.ReturnHealth().Immunity.ToString(), rnd.ToString(), item.DealDamage().ToString()});
                listView1.Items.Add(lvi1);
            }
            foreach (var item in militarians_f5)
            {
                await Task.Delay(1);
                int rnd = await GetMyRandom(10,20);
                e.calculateDamage(item, rnd);
                ListViewItem lvi1 = new ListViewItem(new string[] {item.Name, item.Rank, item.ReturnHealth().Endurance.ToString(),
                    item.ReturnHealth().Immunity.ToString(), rnd.ToString(), item.DealDamage().ToString()});
                listView1.Items.Add(lvi1);
            }
            foreach (var item in scientists_f5)
            {
                await Task.Delay(1);
                int rnd = await GetMyRandom(10,20);
                e.calculateDamage(item, rnd);
                ListViewItem lvi1 = new ListViewItem(new string[] {item.Name, item.Post, item.ReturnHealth().Endurance.ToString(),
                    item.ReturnHealth().Immunity.ToString(), rnd.ToString(), item.DealDamage().ToString()});
                listView1.Items.Add(lvi1);
            }
            button2.Enabled = true;
        }
        private async void DisplayResult3(object sender, EventArgs e)
        {
            await Task.Delay(500);
            label2.Text = Environment.NewLine + "В Зоне вас дожидаются неприятности:";
            listView2.Visible = true;
            mutants_f5 = await RandomDog();
            foreach (var item in mutants_f5)
            {
                ListViewItem lvi2 = new ListViewItem(new string[] {item.MutantType, item.Location.Title, item.ReturnItsHp().Endurance.ToString(),
                    item.ReturnItsHp().Immunity.ToString(), item.DealDamage().ToString()});
                listView2.Items.Add(lvi2);

            }
        }
        private async Task<int> GetMyRandom(int first, int second)
        {
            Random rnd1 = new Random();
            await Task.Delay(2).ConfigureAwait(false);
            int myRandom = rnd1.Next(first, second);
            return myRandom;
        }
        private async Task <List<Mutant>> RandomDog()
        {
            List<Mutant> mutants = new List<Mutant>();
            List<string> mutantTypes = new List<string>() {"Слепой пес", "Снорк", "Бюрер", "Контролер", "Псевдособака", "Кровосос"};
            List<Location> locations = new List<Location>() { new Location { Title = "Кордон", Square = 10 }, new Location { Title = "Рыжий лес", Square = 15 },
            new Location{ Title = "Свалка", Square = 20} };
            int j = await GetMyRandom(6, 15).ConfigureAwait(false);
            for (int i = 0; i < j; i++)
            {
                Thread.Sleep(1);
                mutants.Add(new Mutant() { Location = locations[GetMyRandom (0, 3).Result], 
                    MutantType = mutantTypes[GetMyRandom(0, 6).Result]});
            }
            return mutants;
        }
        private async void myTimer()
        {   
            label1.Visible = true;
            for (int i = 10; i > -1; i--)
            {
                await Task.Delay(1000);
                if (i < 10)
                {
                    label1.Text = "00:0" + i.ToString();
                }
                else
                {
                    label1.Text = "00:" + i.ToString();
                }
            }
            await Task.Delay(1000);
            label1.Text = "";
            await Task.Delay(1000);
            label1.Text = "БАМ";
            await Task.Delay(300);
            label1.Visible = false;
        }
    }
}
