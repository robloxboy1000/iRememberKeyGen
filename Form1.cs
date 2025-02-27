using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Enc;

namespace iRemember_KeyGen
{
    public partial class Form1 : Form
    {
        private int _stream; // Handle for the audio stream
        private string _filePath; // Store the selected file path
        public Form1()
        {
            InitializeComponent();
            InitializeBass();
            _filePath = "./Resources/i remember - NIVEK FFORHS.mp3";
        }
        private void InitializeBass()
        {
            // Initialize BASS audio library
            if (!Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero))
            {
                MessageBox.Show("BASS Initialization Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create a new stream
            _stream = Bass.BASS_StreamCreateFile(_filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            if (_stream == 0)
            {
                MessageBox.Show("Failed to load MP3!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Play the file
            Bass.BASS_ChannelPlay(_stream, false);
        }
        

        private void button1_Click(object sender, EventArgs e, string randomString)
        {
           
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string randomKey = "";

            // Generate 25 characters
            for (int i = 0; i < 25; i++)
            {
                randomKey += characters[random.Next(characters.Length)];

                // Add a hyphen every 5 characters, except at the end
                if ((i + 1) % 5 == 0 && i != 24)
                {
                    randomKey += "-";
                }
            }

            // Display the generated key in the text box
            textBoxRandomKey.Text = randomKey;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Free resources on exit
            Bass.BASS_Stop();
            Bass.BASS_Free();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Show the context menu
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
    
}
