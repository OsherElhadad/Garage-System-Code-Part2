using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
namespace OsherProject
{
    public partial class Form2 : Form
    {
        //private SpeechRecognitionEngine recognitionEngine;

        public Form2()
        {
            InitializeComponent();
            SpeechSynthesizer a = new SpeechSynthesizer();
            a.Volume = 100;
            a.Rate = 0;
            a.Speak("aviram shtok");
                //recognitionEngine = new SpeechRecognitionEngine();
                //recognitionEngine.SetInputToDefaultAudioDevice();
                //recognitionEngine.SpeechRecognized += (s, args) =>
                //{
                //    foreach (RecognizedWordUnit word in args.Result.Words)
                //    {
                //        if (word.Confidence > 0.5f)
                //            txtOutput.Text += word.Text + " ";
                //    }
                //    txtOutput.Text += Environment.NewLine;
                //};
                //recognitionEngine.LoadGrammar(new DictationGrammar());
            }
            private void btnStart_Click(object sender, EventArgs e)
            {
                //recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            private void btnStop_Click(object sender, EventArgs e)
            {
                //recognitionEngine.RecognizeAsyncStop();
            }
    }
}
