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

namespace PetShopWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Welcome();
        }

        private void NavMain(object sender, RoutedEventArgs e)
        {
            Main.Content = new Welcome();
        }

        private void NavAnimals(object sender, RoutedEventArgs e)
        {
            Main.Content = new Animals();
        }

        private void NavCategories(object sender, RoutedEventArgs e)
        {
            Main.Content = new Categories();
        }

        private void NavComments(object sender, RoutedEventArgs e)
        {
            Main.Content = new Comments();
        }

        private void NavRatings(object sender, RoutedEventArgs e)
        {
            Main.Content = new Ratings();
        }

    }
}
