using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberSecurityBotGUI
{
    public partial class Form1 : Form
    {
        Chatbot bot = new Chatbot();

        SpeechSynthesizer synth = new SpeechSynthesizer();

        SoundPlayer player = new SoundPlayer();

        // 🎤 1. Voice Greeting
        public Form1()
        {
            InitializeComponent();

            player.SoundLocation = "Welcom.wav";
            player.Play();

            richTextBoxChat.AppendText("Bot: Welcome to the Cybersecurity Awareness Bot!\n\n");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string userInput = textBoxInput.Text;

            if (string.IsNullOrWhiteSpace(userInput))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }

            richTextBoxChat.AppendText("You: " + userInput + "\n");

            string response = bot.GetResponse(userInput);

            richTextBoxChat.AppendText("Bot: " + response + "\n\n");

            synth.SpeakAsync(response);

            textBoxInput.Clear();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
