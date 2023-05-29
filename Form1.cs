using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace iRemember_KeyGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Play the .wav audio file from resources
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.I_Remember);
            player.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e, string randomString)
        {
           
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Generate a random string
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomString = new string(Enumerable.Repeat(characters, 25)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            // Insert hyphens in the random string
            var sections = Enumerable.Range(0, 5)
                .Select(i => randomString.Substring(i * 5, 5));
            randomString = string.Join("-", sections.ToArray());

            // Display the random string in the text box
            textBoxRandomKey.Text = randomString;
        }
    }
    
}
