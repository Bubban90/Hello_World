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
using System.Threading;

namespace BinaryModell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int index = 1;
        private int correctAnswers = 0;
        private string[] questions = new String[10];
        private string[] answers = new String[10];

        public MainWindow()
        {
            InitializeComponent();
            generateExamQuestions();
            this.examQuestion.Text = questions[index-1];
        }

        private bool compareBinDeci()
        {
            string tempDeci = null;
            string tempBin = null;
            tempBin = this.binaryQuestions.Text;
            tempDeci = BinaryGameModel.binaryToDeci(tempBin);

            if (this.answer.Text == tempDeci)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validateInput(string tempInput)
        {
            foreach (char c in tempInput)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }

        private void answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tempInput = null;
            tempInput = this.answer.Text;
            if (validateInput(tempInput))
            {
                turnIn.IsEnabled = true;
            }
            else
            {
                turnIn.IsEnabled = false;
            }
        }

        private void turnIn_Click(object sender, RoutedEventArgs e)
        {
            bool ok = compareBinDeci();
            if (ok)
            {
                this.textRuta.Content = "Rätt!";
            }
            else
            {
                this.textRuta.Content = "Fel! gör om gör rätt!";
            }
        }

        private void changeBin()
        {
            this.binaryQuestions.Text = BinaryGameModel.generateRandomBinary();
        }

        private void generateExamQuestions()
        {

            for (int i = 0; i < 10; i++)
            {
                questions[i] = BinaryGameModel.generateRandomBinary();
                answers[i] = "";
                Console.WriteLine(questions[i]);
                Thread.Sleep(10);
            }
        }

        private void resetButt_Click(object sender, RoutedEventArgs e)
        {
            changeBin();
            this.textRuta.Content = "";
            this.answer.Text = "";
        }

        private void menyBT_Click(object sender, RoutedEventArgs e)
        {
            testGrid.Visibility = Visibility.Collapsed;
            menyGrid.Visibility = Visibility.Visible;
        }

        private void testButt_Click(object sender, RoutedEventArgs e)
        {
            menyGrid.Visibility = Visibility.Collapsed;
            testGrid.Visibility = Visibility.Visible;
        }

        private void examButt_Click(object sender, RoutedEventArgs e)
        {
            menyGrid.Visibility = Visibility.Collapsed;
            examGrid.Visibility = Visibility.Visible;
        }

        private void menyBExam_Click(object sender, RoutedEventArgs e)
        {
            examGrid.Visibility = Visibility.Collapsed;
            menyGrid.Visibility = Visibility.Visible;
            index = 1;
            generateExamQuestions();
            this.examQuestion.Text = questions[index - 1];
            this.TurnIn.IsEnabled = true;
            this.previousButt.IsEnabled = false;
            this.answerBox.Text = "";
            this.questionNumber.Content = "1/10";
        }

        private void enter_Button(object sender, KeyEventArgs e)
        {
            bool ok = compareBinDeci();
            if(e.Key == Key.Enter)
            {
                if (ok)
                {
                    this.textRuta.Content = "Rätt!";
                }
                else
                {
                    this.textRuta.Content = "Fel! gör om gör rätt!";
                }
                changeBin();
                this.answer.Text = "";
            }
            
        }

        private void previousButt_Click(object sender, RoutedEventArgs e)
        {
            answers[index - 1] = answerBox.Text;
            --index;
            answerBox.Text = answers[index - 1];
            this.questionNumber.Content = index + "/10";
            this.examQuestion.Text = questions[index - 1];
            
            if(index == 1)
            {
                this.previousButt.IsEnabled = false;
                this.nextButt.IsEnabled = true;
            }
            else if(index > 1 && index < 10)
            {
                this.nextButt.IsEnabled = true;
            }
        }

        private void nextButt_Click(object sender, RoutedEventArgs e)
        {
            answers[index - 1] = answerBox.Text;
            ++index;
            answerBox.Text = answers[index - 1];
            this.questionNumber.Content = index + "/10";
            this.examQuestion.Text = questions[index - 1];

            if(index > 1 && index < 10)
            {
                this.previousButt.IsEnabled = true;
            }
            else if (index == 10)
            {
                this.nextButt.IsEnabled = false;
            }
        }

        private void TurnIn_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if (answers[i] == "")
                {

                }
                else if(answers[i] == BinaryGameModel.binaryToDeci(questions[i]))
                {
                    correctAnswers++;
                }
            }

            this.questionNumber.Content = "You had " + correctAnswers + "correct Answers";
            correctAnswers = 0;
            this.TurnIn.IsEnabled = false;
        }
    }
}
