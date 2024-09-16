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

namespace VeelGebruikteKlassen_1___Raadspel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Tip: Random number generator
        // private Random _random = new Random();
        // int _randomNumber = rnd.Next(1, 101); // van 1 tot 100 (101 telt niet mee)

        private int _numberToGuess;
        private int _numberOfAttempts = 0;
        // Random number generator
        private Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            _numberToGuess = int.Parse(numberTextBox.Text);
            timeLabel.Content = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToShortTimeString();
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            // Extra poging gewaagd
            _numberOfAttempts++;
            // _numberOfAttempts = _numberOfAttempts + 1;
            // _numberOfAttempts += 1;

            // Ingevoerd getal declareren en converteren naar getal.
            bool isInputNumber = short.TryParse(numberTextBox.Text, out short inputNumber);

            if (isInputNumber)
            {

                // Controle naar geraden getal.
                if (inputNumber == _numberToGuess)
                {
                    output1TextBox.Text = "Proficiat! U hebt het getal geraden!";
                    output2TextBox.Text = $"Aantal keren geraden: {_numberOfAttempts}\r\n\r\n";
                }
                else if (_numberToGuess < inputNumber)
                {
                    output1TextBox.Text = "Raad lager!";
                }
                else
                {
                    output1TextBox.Text = "Raad hoger!";
                }
            }
            //Tekst automatisch selecteren en focus daarop zetten
            numberTextBox.SelectAll();
            numberTextBox.Focus();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            _numberOfAttempts = 0;
            _numberToGuess = _random.Next(1, 101); // Genereer nieuw getal tussen 1 en 100 (101 telt niet mee)
            numberTextBox.Clear();
            output1TextBox.Clear();
            output2TextBox.Clear();

            numberTextBox.Focus();
        }

        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
