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

namespace Teht2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            comboBox_game.Items.Add("Suomi");
            comboBox_game.Items.Add("VikingLotto");
            comboBox_game.Items.Add("EuroJackpot");
        }

        private void button_draw_Click(object sender, RoutedEventArgs e)
        {
            List<List<int>> numbers = new List<List<int>>();
            BLLotto game = new BLLotto();
            int draws = 0;
            int.TryParse(txt_draws.Text, out draws);
            numbers = game.Draw(comboBox_game.Text, draws);
            foreach (var numberlist in numbers)
            {
                foreach (var number in numberlist)
                {
                    textBlock_result.Text += number.ToString();
                    textBlock_result.Text += " ";
                }
                textBlock_result.Text += "\n";
            }
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)
        {
            textBlock_result.Text = "";
        }
    }
}
