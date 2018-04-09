using System;
using System.Collections.Generic;
using System.Configuration;
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


namespace Insurinator.WPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clients vClients = new Clients();
            vClients.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Insurence ins = new Insurence();
            ins.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddEvent adev = new AddEvent();
            adev.Show();
   
        }
    }
}
