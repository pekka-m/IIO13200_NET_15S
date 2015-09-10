using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
            comboBox_seura.Items.Add("Blues");
            comboBox_seura.Items.Add("HIFK");
            comboBox_seura.Items.Add("HPK");
            comboBox_seura.Items.Add("Ilves");
            comboBox_seura.Items.Add("JYP");
            comboBox_seura.Items.Add("KalPa");
            comboBox_seura.Items.Add("KooKoo");
            comboBox_seura.Items.Add("Kärpät");
            comboBox_seura.Items.Add("Lukko");
            comboBox_seura.Items.Add("Pelicans");
            comboBox_seura.Items.Add("SaiPa");
            comboBox_seura.Items.Add("Sport");
            comboBox_seura.Items.Add("Tappara");
            comboBox_seura.Items.Add("TPS");
            comboBox_seura.Items.Add("Ässät");
        }

        private void button_uusiPelaaja_Click(object sender, RoutedEventArgs e)
        {
            if (!tarkasta())
            {
                listBox.Items.Add(new Pelaaja
                {
                    etunimi = textBox_etunimi.Text,
                    sukunimi = textBox_sukunimi.Text,
                    seura = comboBox_seura.Text,
                    siirtohinta = double.Parse(textBox_siirtohinta.Text)
                });
                listBox.DisplayMemberPath = "kokonimi";
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                Pelaaja pelaaja = (Pelaaja)(listBox.SelectedItem);
                textBox_etunimi.Text = pelaaja.etunimi;
                textBox_sukunimi.Text = pelaaja.sukunimi;
                textBox_siirtohinta.Text = pelaaja.siirtohinta.ToString();
                comboBox_seura.SelectedItem = pelaaja.seura;
            }
        }

        private void button_poista_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void button_tallenna_Click(object sender, RoutedEventArgs e)
        {
            if (!tarkasta())
            {
                Pelaaja pelaaja = (Pelaaja)(listBox.SelectedItem);
                pelaaja.etunimi = textBox_etunimi.Text;
                pelaaja.sukunimi = textBox_sukunimi.Text;
                pelaaja.siirtohinta = double.Parse(textBox_siirtohinta.Text);
                pelaaja.seura = comboBox_seura.SelectedItem.ToString();
                listBox.Items.Refresh();
            }
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

        private void button_lopetus_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void button_kirjoita_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "pellaajat"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results 
            if (result == true)
            {
                // Save document 
                string filename = dlg.FileName;
            }
        }
    }
}
