using System;
using System.Collections.Generic;
using System.IO;
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

namespace Assignment5Group5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string MSG_TO_HIGH = "Your choice is too high.";
        const string MSG_TO_LOW = "Your choice is too low.";
        const string MSG_WINNER = "You choice is same as computer's choice.";
        const string DIRNAME = "ProjectResult";
        const string FILENAME = "resultNumberGame.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        public int randonNumberGenerator()
        {
            Random ran = new Random();
            int computerChoice = ran.Next(1, 100);
            return computerChoice;
        }
        public int userChoice()
        {
            int userChoice = int.Parse(txtUserChoice.Text);
            return userChoice;
        }
        public string gameLogic()
        {
            if (randonNumberGenerator() == userChoice())
                return MSG_WINNER;
            else if (randonNumberGenerator() < userChoice())
                return MSG_TO_HIGH;
            else 
                return MSG_TO_LOW;
        }
        public void displayMessage()
        {
            lblResult.Content = gameLogic().ToString();
        }
        public void saveToFile()
        {
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullpath = System.IO.Path.Combine(path, DIRNAME);
            Directory.CreateDirectory(fullpath);
            string filePath = System.IO.Path.Combine(fullpath, FILENAME);
            StreamWriter sw = File.CreateText(filePath);
            string result = userChoice().ToString();
            sw.WriteLine(result);
            sw.Close();
        }
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {            
            displayMessage();
            saveToFile();
        }
    }
}
