using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace CheckITs
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        public string vale;

        public Student(string val)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            InputBox.Visibility = System.Windows.Visibility.Visible;
          
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = System.Windows.Visibility.Collapsed;
           
            String questioncode = InputTextBox.Text;
            InputTextBox.Text = String.Empty;

           
            var questiondata = DbUtility.ReadXml<ObservableCollection<Question>>("Questions.xml");
            var Questiondetails = from s in questiondata where s.QuestionCode.Equals(questioncode) select s;

            stk_QuestionDetails.DataContext = Questiondetails;
        }



    }
}
