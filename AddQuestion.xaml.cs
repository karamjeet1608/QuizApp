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
using System.Xml;

namespace CheckITs
{
    /// <summary>
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public AddQuestion()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Btn_AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = DbUtility.ReadXml<ObservableCollection<Question>>("Questions.xml");
                var question = new ObservableCollection<Question>();
                Question qs = new Question();
                qs.TopicId = "text";
                XmlDocument doc = new XmlDocument();
                doc.Load("Questions.xml");
                int count = 1;
                foreach (XmlNode xn in doc.SelectNodes("ArrayOfQuestion/Question"))
                {
                    count = count + 1;
                }
                string questionid = Convert.ToString(count);
                qs.QuestionId = questionid;
                qs.QuestionTitle = Question.Text;
                qs.OptionA = OptionA.Text;
                qs.OptionB = OptionB.Text;
                qs.OptionC = OptionC.Text;
                qs.OptionD = OptionD.Text;
                qs.CorectionAnswer = CorrectAnswer.Text;
                {
                    data.Add(qs);
                    DbUtility.WriteXml<ObservableCollection<Question>>(data, "Questions.xml");
                    MessageBox.Show("Question Successfully Added");
                    var gobacktomain = new MainWindow();
                    gobacktomain.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
