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
            String s="";
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    if (((TextBox)item).Text.Length < 2)
                        MessageBox.Show("Въвели сте невалидно име!");
                    else
                    {
                        s = s + ((TextBox)item).Text;
                        s = s + '\n';
                    }
                }
            }
            
                MessageBox.Show("Здрасти " + s + "!!! \nТова е твоята първа програма на VisualStudio 2019!");
            
            
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

      protected void ClearText()
        {
            foreach(var item in MainGrid.Children)
            {
                if(item is TextBox)
                {
                    (item as TextBox).Clear() ;
                }
            }
        }
        protected void setFields(Student student)
        {
            txtName.Text = student._firstName;
            txtSurname.Text = student._secondName;
            txtLastname_.Text = student._lastName;
            txtFaculty.Text = student._faculty;
            txtOKS.Text = student._degree;
            txtStatus.Text = student._status.ToString();
            txtYear.Text = student._year.ToString();
            txtStream.Text = student._stream.ToString();
            txtSpec.Text = student._speciality;
            txtFacNum.Text = student._facNum;
            txtGroup.Text = student._group.ToString();

        }
        protected void disableAllFields()
        {
           
            foreach( UIElement item in MainGrid.Children)
            {
                item.IsEnabled = false;
            }
        }
        protected void enableAllFields()
        {
            foreach (Control item in MainGrid.Children)
            {
                item.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          /*  ClearText();
            setFields(StudentData.TestStudent[1]);
            disableAllFields();*/
        }
    }
}
