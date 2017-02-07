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
        private int _index = 1;
        private int _correctAnswers = 0;
        private string[] _questions = new String[20];
        private string[] _answers = new String[20];
        private bool _hexOrBin = true;
        private int _difficulty = 0;


        public MainWindow()
        {
            InitializeComponent();
            generateExamQuestions();
            this.examQuestion.Text = _questions[_index-1];
        }

        #region // Technical stuff

        private void changeBin()
        {
            if(_difficulty == 1)
            {
                this.binaryQuestions.Text = BinaryGameModel.generateRandomBinary(_difficulty);

            }
            else if(_difficulty == 2)
            {
                this.binaryQuestions.Text = BinaryGameModel.generateRandomBinary(_difficulty);
            }
            else if (_difficulty == 3)
            {
                this.binaryQuestions.Text = BinaryGameModel.generateRandomBinary(_difficulty);
            }
        }

        private void changeHex()
        {
            
            if (_difficulty == 1)
            {
                this.binaryQuestions.Text = BinaryGameModel.generateRandomHex(_difficulty);
            }
            else if (_difficulty == 2)
            {
                this.binaryQuestions.Text = BinaryGameModel.generateRandomHex(_difficulty);
            }
            else if (_difficulty == 3)
            {
                this.binaryQuestions.Text = BinaryGameModel.generateRandomHex(_difficulty);
            }
        }
            
        private void generateExamQuestions()
        {
            _difficulty = 1;
            for (int i = 0; i < 10; i++)
            {
                if(i == 4)
                {
                    _difficulty = 2;
                }
                else if(i > 7)
                {
                    _difficulty = 3;
                }
                _questions[i] = BinaryGameModel.generateRandomBinary(_difficulty);
                _answers[i] = "";
                Console.WriteLine(_questions[i]);
                Thread.Sleep(10);
            }
            _difficulty = 2;
            for (int j = 10; j <20; j++)
            {
                if(j > 17)
                {
                    _difficulty = 3;
                }
                _questions[j] = BinaryGameModel.generateRandomHex(_difficulty);
                _answers[j] = "";
                Console.WriteLine(_questions[j]);
                Thread.Sleep(15);
            }
            _difficulty = 1;
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

        private bool compareHexDeci()
        {
            string tempDeci = null;
            string tempHex = null;
            tempHex = this.binaryQuestions.Text;
            tempDeci = BinaryGameModel.hexToDeci(tempHex);

            if (this.answer.Text == tempDeci)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

        #region // All the buttons

        private void menyBT_Click(object sender, RoutedEventArgs e)
        {
            testGrid.Visibility = Visibility.Collapsed;
            menyGrid.Visibility = Visibility.Visible;
        }

        private void testButt_Click(object sender, RoutedEventArgs e)
        {
            menyGrid.Visibility = Visibility.Collapsed;
            testGrid.Visibility = Visibility.Visible;

            _difficulty = 1;
            _hexOrBin = true;

            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
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
            _index = 1;
            generateExamQuestions();
            this.examQuestion.Text = _questions[_index - 1];
            this.TurnIn.IsEnabled = true;
            this.previousButt.IsEnabled = false;
            this.nextButt.IsEnabled = true;
            this.answerBox.Text = "";
            this.questionNumber.Content = _index + "/20";
        }

        private void enter_Button(object sender, KeyEventArgs e)
        {
            if(_hexOrBin)
            {
                bool ok = compareBinDeci();
                if (e.Key == Key.Enter)
                {
                    if (ok)
                    {
                        this.textRuta.Content = "correct!";
                    }
                    else
                    {
                        this.textRuta.Content = "Wrong, try again!";
                    }
                }
            }
            else
            {
                bool ok = compareHexDeci();
                if (e.Key == Key.Enter)
                {
                    if (ok)
                    {
                        this.textRuta.Content = "correct!";
                    }
                    else
                    {
                        this.textRuta.Content = "Wrong, try again!";
                    }
                }
            }
        }

        private void TurnIn_Click_1(object sender, RoutedEventArgs e)
        {

            if (_index == 19)
                _answers[19] = answerBox.Text.ToString();

            //if (_answers[9] == BinaryGameModel.binaryToDeci(_questions[9]))
            //    _correctAnswers++;
            if (_answers[19] == BinaryGameModel.hexToDeci(_questions[19]))
                _correctAnswers++;

            if (TurnIn.Content.ToString() == "Play again?")
            {
                TurnIn.Content = "Turn In";
                _correctAnswers = 0;
                _index = 1;
                generateExamQuestions();
                this.examQuestion.Text = _questions[_index - 1];
                this.questionNumber.Content = _index + "/20";
                this.previousButt.IsEnabled = false;
                this.nextButt.IsEnabled = true;
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (_answers[i] == "")
                    {

                    }
                    else if (_answers[i] == BinaryGameModel.binaryToDeci(_questions[i]))
                    {
                        _correctAnswers++;
                    }
                }
                for (int j = 10; j < 20; j++)
                {
                    if (_answers[j] == "")
                    {

                    }
                    else if (_answers[j] == BinaryGameModel.hexToDeci(_questions[j]))
                    {
                        _correctAnswers++;
                    }
                }

                questionNumber.Content = "You had " + _correctAnswers + " correct answers";
                _correctAnswers = 0;
                this.TurnIn.Content = "Play again?";
            }


            //this.TurnIn.IsEnabled = false;
        }

        private void previousButt_Click(object sender, RoutedEventArgs e)
        {
            answerBox.Focus();
            _answers[_index - 1] = answerBox.Text;
            --_index;
            answerBox.Text = _answers[_index - 1];
            this.questionNumber.Content = _index + "/20";
            this.examQuestion.Text = _questions[_index - 1];
            
            if(_index == 1)
            {
                this.previousButt.IsEnabled = false;
                this.nextButt.IsEnabled = true;
            }
            else if(_index > 1 && _index < 20)
            {
                this.nextButt.IsEnabled = true;
            }
        }

        private void nextButt_Click(object sender, RoutedEventArgs e)
        {
            answerBox.Focus();
            _answers[_index - 1] = answerBox.Text;
            ++_index;
            answerBox.Text = _answers[_index - 1];
            this.questionNumber.Content = _index + "/20";
            this.examQuestion.Text = _questions[_index - 1];

            if(_index > 1 && _index < 20)
            {
                this.previousButt.IsEnabled = true;
            }
            else if (_index == 20)
            {
                this.nextButt.IsEnabled = false;
            }
        }

        private void nextQue_Click(object sender, RoutedEventArgs e)
        {
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }

        #endregion

        private void answerBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {

                if (_index > 19)
                {
                    _answers[_index - 1] = answerBox.Text;
                    answerBox.Text = _answers[_index -1];
                }
                else
                {
                    _answers[_index - 1] = answerBox.Text;
                    ++_index;
                    answerBox.Text = _answers[_index - 1];
                    this.questionNumber.Content = _index + "/20";
                    this.examQuestion.Text = _questions[_index - 1];

                    if (_index > 1 && _index < 20)
                    {
                        this.previousButt.IsEnabled = true;
                    }
                    else if (_index == 20)
                    {
                        this.nextButt.IsEnabled = false;
                    }
                }   
            }

        }

        private void answer_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tempInput = null;
            tempInput = this.answer.Text;
            if (validateInput(tempInput))
            {
                nextQue.IsEnabled = true;
            }
            else
            {
                nextQue.IsEnabled = false;
            }
        }

        #region //Changes the difficulty for binary
        /// <summary>
        /// Makes diffrent difficulty for binary
        /// </summary>
        private void binEasy_Click(object sender, RoutedEventArgs e)
        {
            _difficulty = 1;
            _hexOrBin = true;
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }

        private void binMedium_Click(object sender, RoutedEventArgs e)
        {
            _difficulty = 2;
            _hexOrBin = true;
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }

        private void binHard_Click(object sender, RoutedEventArgs e)
        {
            _difficulty = 3;
            _hexOrBin = true;
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }
        #endregion

        #region //Changes the difficulty for hex
        /// <summary>
        /// Changes the difficulty for hex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hexEasy_Click(object sender, RoutedEventArgs e)
        {
            _hexOrBin = false;
            _difficulty = 1;
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }

        private void hexMedium_Click(object sender, RoutedEventArgs e)
        {
            _difficulty = 2;
            _hexOrBin = false;
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }

        private void hexHard_Click(object sender, RoutedEventArgs e)
        {
            _difficulty = 3;
            _hexOrBin = false;
            if (_hexOrBin)
            {
                changeBin();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
            else
            {
                changeHex();
                this.answer.Text = "";
                this.textRuta.Content = "";
                answer.Focus();
            }
        }
        #endregion
    }
}
