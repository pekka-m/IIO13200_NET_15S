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
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

// miten asia hoidettaisiin oikein käyttäen kerroksia: esitys, logiikka jne. jne... ??

namespace JsonDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<JAMK.IT.User> Users = new ObservableCollection<JAMK.IT.User>();

        public MainWindow()
        {
            InitializeComponent();
            textBox.Text = "[{'Name':'Olli Opiskelija','Gender':'Male','Birthday':'1991-10-10'}," + 
                "{'Name':'Matti Meikalainen','Gender':'Male','Birthday':'1890-12-12'}," +
                "{'Name':'Sepe Zebbe','Gender':'-','Birthday':'1500-04-09'}]";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // kun textBox pyyhitään tyhjäksi, näytetään Json REST APIsta
            if (textBox.Text == "")
            {
                dataGrid.ItemsSource = JAMK.IT.Politic.GetRESTData("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
            }
            else
            {
                try
                {
                    JArray arr = JsonConvert.DeserializeObject<JArray>(textBox.Text);
                    foreach (var item in arr.Children())
                    {
                        var itemProperties = item.Children<JProperty>();
                        var name = itemProperties.FirstOrDefault(x => x.Name == "Name");
                        var gender = itemProperties.FirstOrDefault(x => x.Name == "Gender");
                        var birthday = itemProperties.FirstOrDefault(x => x.Name == "Birthday");
                        JAMK.IT.User user = new JAMK.IT.User(name.Value.ToString(), gender.Value.ToString(), birthday.Value.ToString());
                        Users.Add(user);
                    }
                    dataGrid.ItemsSource = Users;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n... eli asiat meni etelään");
                }
            }
        }
    }
}
