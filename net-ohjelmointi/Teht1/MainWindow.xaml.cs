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

namespace Teht1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Double ikkunalasinAla;
            Double karminPiiri;
            Double karminAla;

            if (Tarkistus())
            {
                ikkunalasinAla = (Double.Parse(txtIkkunanLeveys.Text) - Double.Parse(txtKarminLeveys.Text) * 2) * (Double.Parse(txtIkkunanKorkeus.Text) - Double.Parse(txtKarminLeveys.Text) * 2);
                blckIkkunanAla.Text = ikkunalasinAla.ToString();

                karminPiiri = Double.Parse(txtIkkunanKorkeus.Text) * 2 + Double.Parse(txtIkkunanLeveys.Text) * 2;
                blckKarminPiiri.Text = karminPiiri.ToString();

                karminAla = Double.Parse(txtIkkunanLeveys.Text) * Double.Parse(txtKarminLeveys.Text) * 2 + (Double.Parse(txtIkkunanKorkeus.Text) - Double.Parse(txtKarminLeveys.Text) * 2) * Double.Parse(txtKarminLeveys.Text) * 2;
                blckKarminAla.Text = karminAla.ToString();
            }
            else MessageBox.Show("VIRHE!");

        }

        private bool Tarkistus()
        {
            Double ikkunanKorkeus;
            Double ikkunanLeveys;
            Double karminLeveys;

            bool virhe = false;
            if (!Double.TryParse(txtIkkunanKorkeus.Text, out ikkunanKorkeus)) virhe = true;
            if (!Double.TryParse(txtIkkunanLeveys.Text, out ikkunanLeveys)) virhe = true;
            if (!Double.TryParse(txtKarminLeveys.Text, out karminLeveys)) virhe = true;
            if (!virhe) return true;
            else return false;

        }
    }
}
