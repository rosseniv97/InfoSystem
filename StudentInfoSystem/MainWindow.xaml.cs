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
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Student student;
        public List<string> StudStatusChoices { get; set; }
        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnection))
            {
                string sqlquery =
                @"SELECT StatusDescr
                FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Student _Student
        {
            get
            {
                return student;
            }
            set
            {
                student = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("student"));
                
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            FillStudStatusChoices();
            _Student = StudentData.TestStudent[1];
            
            this.Title = "Университетска информационна система";

        }


        
        protected virtual void Onload(EventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Тестов режим?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Вие сте в тестов режим");
                enableAllFields();
                setFields(StudentData.TestStudent[1]);
            }
            if (result == MessageBoxResult.No)
            {
                disableAllFields();
            }
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
           // txtName.Text = student._firstName;
           // txtSurname.Text = student._secondName;
            txtLastname_.Text = student._lastName;
            txtFaculty.Text = student._faculty;
            txtOKS.Text = student._degree;
          //  txtStatus.Text = student._status.ToString();
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
            foreach (UIElement item in MainGrid.Children)
            {
                item.IsEnabled = true;
            }
        }

        private void SetFieldsButton(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult result = MessageBox.Show("Тестов режим?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Вие сте в тестов режим");
                enableAllFields();
                setFields(StudentData.TestStudent[1]);
                
            }
            if (result == MessageBoxResult.No)
            {
                disableAllFields();
            }


            /*  ClearText();
              setFields(StudentData.TestStudent[1]);
              disableAllFields();*/
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            Student candStudent = new Student() ;
            candStudent = StudentData.LogIn(usernameBox.Text, passwordBox.Text);
            if (student == null)
            {
                MessageBox.Show("Грешно потребителско име или парола");
                usernameBox.Text = "";
                passwordBox.Text = "";
            }
            else
            {
                 setFields(student);
                _Student = candStudent;

                btnLogOut.Visibility = System.Windows.Visibility.Visible;
                btnLogIn.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void LogOut(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtLastname_.Clear();
            txtFaculty.Clear();
            txtOKS.Clear();
         //   txtStatus.Clear();
            txtYear.Clear();
            txtStream.Clear();
            txtSpec.Clear();
            txtFacNum.Clear();
            txtGroup.Clear();
            usernameBox.Clear();
            passwordBox.Clear();
            MessageBox.Show("Вие излязохте успешно");
            btnLogIn.Visibility = System.Windows.Visibility.Visible;
            student = null;
        }
    }
}
