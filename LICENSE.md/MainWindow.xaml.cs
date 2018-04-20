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

namespace WpfApp1_Motus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pickedword;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_NewGame(object sender, RoutedEventArgs e)
        {
            newgame();
        }

        private void btn_Validate(object sender, RoutedEventArgs e)
        {
            string chosenword = TextBoxInfo.Text;
            pickedword = NewWord(chosenword);
            TextBoxInfo.Text = string.Empty;
            givenstartedletters(chosenword);
        }

        private void btn_valideressai(object sender, RoutedEventArgs e)
        {
            TextBlockInfo.Text = string.Empty;
            string word = TextBoxInfo.Text;
           if  (AnswersTest(word))
                {
                youWin();
                }
           else StringComparison(word, pickedword);
        }

        string NewWord(string newword)
        {

            newword = TextBoxInfo.Text;
            int lentghWord = newword.Length;
            bool wordHasSpace = newword.Contains(" ");
            if (wordHasSpace) // || lentghWord == 1)
            {
                //  if (wordHasSpace)
                return TextBlockInfo.Text = "You have entered more than 1 word, try again: ";
                // newword = TextBoxInfo.Text;
                //  if (lentghWord == 1)
                //     Console.WriteLine("you word must contain more than 1 letter");
                // newword = Console.ReadLine();
            }

            else return newword;
        }
        void newgame()
        {
            TextBlockInfo.Text = "Enter a word, and press Validate";
            TextBoxInfo.Text = string.Empty;
        }

        bool AnswersTest(string word)
        {
            word = TextBoxInfo.Text;
            if (word != pickedword)
            {
                return false;
                //  TextBlockInfo.Text = "bad match, try again";
            }

            else return true;
        }
        void youWin()
        {
            TextBlockInfo.Text = "you found it, well done!";
        }

        void givenstartedletters(string word)
        {
           // TextBlockInfo.Text = "here's a little help to get you started";
            int l = word.Length;
           // Random random = new Random();
            //int r = random.Next(0, l);
            char[] letterword = word.ToCharArray();
           // char charact = letterword[r];
            // int i;
            TextBlockInfo.Text ="The first letter is "+ letterword[0].ToString() +" and the word has "+ l + " letters. Now, try a guess and press Validate guess";

        }

        void StringComparison(string a, string b)
        {
            char[] lettera = a.ToCharArray();
            char[] letterb = b.ToCharArray();
            if (a.Length == b.Length)
            {
                for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
                {
                    if (lettera[i] == letterb[i])
                    {
                        TextBlockInfo.Text += ((lettera[i]).ToString());

                    }
                    else TextBlockInfo.Text += "-";
                    ;
                }
            }
            else TextBlockInfo.Text = "The 2 words do not have the same lenght! Try again";

        }
    }
}
