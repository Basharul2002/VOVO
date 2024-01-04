using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VOVO
{
    internal class Captcha
    {
        private SpeechSynthesizer voice;

        public static void SpeakNumericText(string numericText)
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            voice.SelectVoiceByHints(VoiceGender.NotSet);

            foreach (char digit in numericText)
            {
                if (char.IsDigit(digit))
                {
                    string digitWord = DigitToWord(digit);
                    voice.SpeakAsync(digitWord);
                }
            }
        }

        static string DigitToWord(char digit)
        {
            switch (digit)
            {
                case '0':
                    return "zero";
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
                default:
                    return string.Empty;
            }
        }
       
    }


}
