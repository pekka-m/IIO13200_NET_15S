using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Teht3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Pelaaja> pelaajat = new ObservableCollection<Pelaaja>();
        List<String> joukkueet = new List<String>();

        public MainWindow()
        {
            InitializeComponent();
            joukkueet.Add("Blues");
            joukkueet.Add("HIFK");
            joukkueet.Add("HPK");
            joukkueet.Add("Ilves");
            joukkueet.Add("JYP");
            joukkueet.Add("KalPa");
            joukkueet.Add("KooKoo");
            joukkueet.Add("Kärpät");
            joukkueet.Add("Lukko");
            joukkueet.Add("Pelicans");
            joukkueet.Add("SaiPa");
            joukkueet.Add("Sport");
            joukkueet.Add("Tappara");
            joukkueet.Add("TPS");
            joukkueet.Add("Ässät");
            comboBox_seura.ItemsSource = joukkueet;
            listBox.ItemsSource = pelaajat;
            listBox.DisplayMemberPath = "kokonimi";
            statusBarText.Text = "Kaikki valmista.";
        }

        private void button_uusiPelaaja_Click(object sender, RoutedEventArgs e)
        {
            if (!tarkastaUusi())
            {
                pelaajat.Add(new Pelaaja
                {
                    etunimi = textBox_etunimi.Text,
                    sukunimi = textBox_sukunimi.Text,
                    seura = comboBox_seura.Text,
                    siirtohinta = double.Parse(textBox_siirtohinta.Text)
                });
                statusBarText.Text = "Pelaaja lisätty.";
            }
            else statusBarText.Text = "Ilmeni mystinen virhe!";
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                textBox_etunimi.Text = (listBox.SelectedItem as Pelaaja).etunimi;
                textBox_sukunimi.Text = (listBox.SelectedItem as Pelaaja).sukunimi;
                textBox_siirtohinta.Text = (listBox.SelectedItem as Pelaaja).siirtohinta.ToString();
                comboBox_seura.SelectedItem = (listBox.SelectedItem as Pelaaja).seura;
            }
        }

        private void button_poista_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                pelaajat.Remove(listBox.SelectedItem as Pelaaja);
                statusBarText.Text = "Pelaaja poistettu.";
            }
        }

        private void button_tallenna_Click(object sender, RoutedEventArgs e)
        {
            if (!tarkasta())
            {
                (listBox.SelectedItem as Pelaaja).etunimi = textBox_etunimi.Text;
                (listBox.SelectedItem as Pelaaja).sukunimi = textBox_sukunimi.Text;
                (listBox.SelectedItem as Pelaaja).siirtohinta = double.Parse(textBox_siirtohinta.Text);
                (listBox.SelectedItem as Pelaaja).seura = comboBox_seura.SelectedItem.ToString();
                statusBarText.Text = "Pelaajaa muokattu.";
            }
            else statusBarText.Text = "Ilmeni mystinen virhe!";
        }

        private void button_lopetus_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_kirjoita_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter file = new System.IO.StreamWriter("pelaajat.LIIGA");
            foreach (Pelaaja pelaaja in pelaajat)
            {
                file.WriteLine(pelaaja.etunimi + ";" + pelaaja.sukunimi + ";" + pelaaja.seura + ";" + pelaaja.siirtohinta);
            }
            file.Close();
            statusBarText.Text = "Pelaajien tiedot kirjoitettu tiedostoon 'pelaajat.LIIGA'.";
        }

        private bool tarkasta()
        {
            bool virhe = false;
            if (textBox_etunimi.Text == "") virhe = true;
            if (textBox_sukunimi.Text == "") virhe = true;
            if (comboBox_seura.Text == "") virhe = true;
            if (textBox_siirtohinta.Text == "") virhe = true;
            double luku = 0;
            if (!double.TryParse(textBox_siirtohinta.Text, out luku)) virhe = true;
            return virhe;
        }

        private bool tarkastaUusi()
        {
            bool virhe = false;
            foreach (Pelaaja pelaaja in pelaajat)
            {
                if (pelaaja.etunimi + pelaaja.sukunimi == textBox_etunimi.Text + textBox_sukunimi.Text) virhe = true;
            }
            if (textBox_etunimi.Text == "") virhe = true;
            if (textBox_sukunimi.Text == "") virhe = true;
            if (comboBox_seura.Text == "") virhe = true;
            if (textBox_siirtohinta.Text == "") virhe = true;
            double luku = 0;
            if (!double.TryParse(textBox_siirtohinta.Text, out luku)) virhe = true;
            return virhe;
        }
    }
}
