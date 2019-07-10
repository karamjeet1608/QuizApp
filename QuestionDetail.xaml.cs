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
    /// Interaction logic for QuestionDetail.xaml
    /// </summary>
    public partial class QuestionDetail : Window
    {
        public string questionid;

        public QuestionDetail(string id)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            //fetch the project details from Projects.xml and display it on Projectdetail page.
            questionid = id;
            var questiondata = DbUtility.ReadXml<ObservableCollection<Question>>("Questions.xml");
            var Questiondetails = from s in questiondata where s.QuestionId.Equals(questionid) select s;

            stk_QuestionDetails.DataContext = Questiondetails;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_UpdateQuestion_Click(object sender, RoutedEventArgs e)
        {
            var pro = DbUtility.ReadXml<ObservableCollection<Question>>("Questions.xml");
            var question = new ObservableCollection<Question>();
            var qs = pro.First(f => f.QuestionId == Questionid.Text);
            qs.QuestionTitle = Question.Text;
            qs.OptionA = OptionA.Text;
            qs.OptionB = OptionB.Text;
            qs.OptionC = OptionC.Text;
            qs.OptionD = OptionD.Text;
            qs.CorectionAnswer = CorrectAnswer.Text;
            DbUtility.WriteXml<ObservableCollection<Question>>(pro, "Questions.xml");
            MessageBox.Show("Question Successfully Updated");
            var manageQuestion = new ManageQuestion();
            manageQuestion.Show();
            this.Close();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to delete the Question", "Delete Question", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    XmlDocument docu = new XmlDocument();
                    docu.Load("Questions.xml");
                    foreach (XmlNode x in docu.SelectNodes("ArrayOfQuestion/Question"))
                        if (x.SelectSingleNode("QuestionId").InnerText == Questionid.Text)
                        {
                            x.ParentNode.RemoveChild(x);
                            docu.Save("Questions.xml");
                        }
                    var manageQuestion = new ManageQuestion();
                    manageQuestion.Show();
                    this.Close();
                    break;

                case MessageBoxResult.No:

                    break;
            }
        }
    }
}
