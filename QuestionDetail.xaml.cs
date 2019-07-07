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
using System.Windows.Shapes;

namespace CheckITs
{
    /// <summary>
    /// Interaction logic for QuestionDetail.xaml
    /// </summary>
    public partial class QuestionDetail : Window
    {
        private string id;

        public QuestionDetail(string id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

     

        private void Btn_UpdateQuestion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
