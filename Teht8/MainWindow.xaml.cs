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
using System.Xml.Linq;

namespace Teht8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (XMLWorker.NaytaPalautteet() == null)
            {
                MessageBox.Show(Properties.Settings.Default.PalauteXML + " tiedostoa ei löytynyt, luodaan uusi.");
                // tiedostoa ei löytynyt tai ei kerennyt ladata tai jotain...
                // tässä tehtäisiin uusi tiedosto
                // XMLWorker.TeeXMLTiedosto();
            }
            else
            {
                datagrid_palautteet.ItemsSource = XMLWorker.NaytaPalautteet();
            }
        }

        private void button_laheta_Click(object sender, RoutedEventArgs e)
        {
            XMLWorker.TallennaPalaute(textBox_nimi.Text, textBox_olen_oppinut.Text, textBox_haluan_oppia.Text, textBox_hyvaa.Text, textBox_parannettavaa.Text, textBox_muuta.Text);
            datagrid_palautteet.ItemsSource = XMLWorker.NaytaPalautteet();
        }
    }
}
