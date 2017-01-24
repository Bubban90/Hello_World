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

namespace BinaryModell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        }
    }
}
