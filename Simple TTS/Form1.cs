using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace Simple_TTS
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer text;
        public Form1()
        {
            InitializeComponent();
            text = new SpeechSynthesizer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text.SpeakAsync("TTS");
            if (richTextBox1.Text != "")
            {
                text.SpeakAsync(richTextBox1.Text);
            }
        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void keyPressed(object sender, KeyPressEventArgs e)
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (e.KeyChar == c)
                {
                    text.SpeakAsync(c.ToString());
                }
            }
            for (char c = 'a'; c <= 'z'; c++)
            {
                if (e.KeyChar == c)
                {
                    text.SpeakAsync(c.ToString());
                }
            }
            if(e.KeyChar == (char)Keys.Space) 
            {
                text.SpeakAsync("Space");
            }
            else if(e.KeyChar == (char)Keys.Back)
            {
                text.SpeakAsync("Back");
            }
            else if(e.KeyChar == 46)
            {
                text.SpeakAsync("Period");
            }


            /*foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {

            }*/
        }

        private void richTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                if (Control.IsKeyLocked(Keys.CapsLock))
                {
                    text.SpeakAsync("Caps Lock is ON");
                }
                else
                {
                    text.SpeakAsync("Caps Lock is OFF");
                }
            }
        }
    }
}
