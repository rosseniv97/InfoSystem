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
using UserLogin;
using StudentRepository;
using System.ComponentModel;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Университетска информационна система";
        }

        private void BtnHello_Click(object sender, RoutedEventArgs e)
        {

            if (txtName.Text.Length >= 2)
                MessageBox.Show("Здрасти " + txtName.Text + "!!! \nТова е твоята първа програма на VisualStudio 2019!");
            else MessageBox.Show("Въведете валидно име!");
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Наистина ли искате да излезете от програмата", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
     }
}
