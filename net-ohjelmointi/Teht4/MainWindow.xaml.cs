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
using System.Configuration;
using System.Xml;

// aivan karmeaa koodia mutta toimii...
// kun ei ymmarra mistaan mitaan

namespace Teht4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // lisataan comboBoxiin kaikki maat

            List<string> KaikkiMaat = new List<string>();
            List<string> Maat = new List<string>();

            KaikkiMaat.Add("Kaikki");

            XmlDocument doc = new XmlDocument();

            doc.Load(Properties.Settings.Default.ViiniXML);
 
            XmlNodeList nodes = doc.SelectNodes("viinikellari/wine/maa/text()");

            foreach (XmlNode node in nodes)
            {
                KaikkiMaat.Add(node.Value);
            }
            
            Maat = KaikkiMaat.Distinct().ToList();
            
            comboBox.ItemsSource = Maat;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XElement Wines = XElement.Load(Properties.Settings.Default.ViiniXML);
            System.ComponentModel.ICollectionView c = System.Windows.Data.CollectionViewSource.GetDefaultView(Wines.Elements());

            if (comboBox.Text.ToString() == "Kaikki" || comboBox.Text.ToString() == "")
            {
                DGViinit.ItemsSource = c;
            }
            else
            {
                c.Filter = new Predicate<object>(Filtteri);
                DGViinit.ItemsSource = c;
            }
            DGViinit.ItemsSource = c;
        }

        private Boolean Filtteri(object i)
        {
            return (i as XElement).Element("maa").Value.ToString().Contains(comboBox.Text.ToString());
        }

    }
}
