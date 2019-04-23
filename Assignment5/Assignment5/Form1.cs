using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Assignment5
{
    public partial class Form1 : Form
    {
        string[] article = { "the", "a", "one", "some", "any" };
        string[] noun = {"boy", "girl", "dog", "town", "cat", "bat"};
        string[] verb = { "drove", "jumped", "ran", "walked", "skipped", "flew" };
        string[] preposition = { "to", "from", "over", "under", "on", "around" };

        string title = "Sentence Generator";
        string myName = " Cameron Helkuik";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = string.Concat(title, myName);
            lblDateTime.Text = DateTime.Now.ToLongDateString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var output = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                var generatedString = "";
                Random rando = new Random();

                var firstWord = article[rando.Next(0, article.Length)];
                var uppercase =  char.ToUpper(firstWord[0]) + firstWord.Substring(1);

                generatedString += uppercase + " ";
                generatedString += noun[rando.Next(0, noun.Length)] + " ";
                generatedString += verb[rando.Next(0, verb.Length)] + " ";
                generatedString += preposition[rando.Next(0, preposition.Length)] + " ";
                generatedString += article[rando.Next(0, article.Length)] + " ";
                generatedString += noun[rando.Next(0, noun.Length)] + ". ";

                output.Append(generatedString);

                //For some reason if I don't have this Thread.Sleep(20), it prints the same sentence to the txtOutput. When I try to debug it with 
                //a breakpoint, it would work correctly and give me a new sentence. 
                Thread.Sleep(20);
            }

            txtOutput.Text = output.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
