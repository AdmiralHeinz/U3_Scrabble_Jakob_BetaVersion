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



namespace U3_Scrabble_Jakob
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> words = new List<string>();/// create a new list for the words
        List<string> letters = new List<string>();/// creates a list for the letters to be used

        public MainWindow()
        {

            InitializeComponent();


            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string letterlower = TextBox.Text;/// reads the contents of the textbox as a string
            string letter = letterlower.ToUpper();
            
            
            letters = letter.Split(' ').ToList<string>(); /// splits string into an array converts to list and adds to letters list
            
            ///Console.WriteLine(letters[0]);

            ReadFile();

        }

        public void ReadFile()
        {
            

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();/// open file dialog to choose a file
            openFileDialog.ShowDialog();

            System.IO.StreamReader streamReader = new System.IO.StreamReader(openFileDialog.FileName);/// initalize the stream reader to read the choosen file

            while (!streamReader.EndOfStream)/// loop through the txt document
            {
                
                string word = streamReader.ReadLine();/// read a line of the fiile
                if (CheckWord(word) == true)
                {
                    words.Add(word);
                }
            }

            int wordslen = words.Count;/// read the length of the list
            int wordscounter = 0;/// create counter to stop loop at the end of the list
            while (wordscounter < wordslen)
            {
                Console.WriteLine(words[wordscounter]);/// display list to the console
                wordscounter++;
            }

        }

        public bool CheckWord(string word)
        {
            int lettercounter = 0;
            int lettercount = letters.Count;

            ///Console.WriteLine(letters[lettercounter]);
            ///Console.WriteLine(word);
            while (lettercounter < lettercount)
            {
                bool contains = word.Contains(letters[lettercounter]);
                if (contains == true)
                {
                    ///MessageBox.Show("hi");
                    lettercounter++;
                    
                    
                }

                else
                {
                    return false;
                }
            }

            return true;
 
        }
    }
}
