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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace CheckITs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int comboselecteditemId = 0;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //To fetch the Topiclist and display in the listbox
            List<string> data = new List<string>();
            XmlDocument docum = new XmlDocument();
            docum.Load("Topics.xml");
            foreach (XmlNode x in docum.SelectNodes("ArrayOfTopic/Topic"))
            {
                data.Add(x.SelectSingleNode("TopicTitle").InnerText);
            }
            cbx_TopicList.ItemsSource = data;
            cbx_TopicList.SelectedIndex = 0;

        }

        private void Btn_options_Click(object sender, RoutedEventArgs e)
        {
            var options = new Options();
            options.Show();
        }

        private void Cbx_TopicList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //To fetch the Questions on selection of the Topic and display in the listbox
            comboselecteditemId = cbx_TopicList.SelectedIndex + 1;
            string val = comboselecteditemId.ToString();
            var data = DbUtility.ReadXml<ObservableCollection<Question>>("Questions.xml");
            var Questions = from s in data where s.TopicId.Equals(val) select s;
            {
                QuestionList.ItemsSource = Questions;
            }
        }

        private void Btn_StartCheckIt_Click(object sender, RoutedEventArgs e)
        {
            string val = "";
            var question = new Question();
            question = (Question)QuestionList.SelectedItem;
            string id = question.QuestionId;
            MessageBox.Show(id);

            XmlDocument docu = new XmlDocument();
            docu.Load("Questions.xml");
            foreach (XmlNode x in docu.SelectNodes("ArrayOfQuestion/Question"))
            if (x.SelectSingleNode("QuestionId").InnerText == id)
            {
                     val = x.SelectSingleNode("QuestionCode").InnerText;
            }
            MessageBoxResult result = System.Windows.MessageBox.Show("The Question Code is:  " + val+ " Do you want to start the question?", "Start Question", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                   
                    var studentpage = new Student(val);
                    studentpage.Show();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}



