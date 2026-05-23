using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBotGUI
{
    public class Chatbot
    {
        Random random = new Random();

        private string rememberedTopic = "";

        private Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols and numbers.",
                    "Avoid using personal information in passwords.",
                    "Use different passwords for every account."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Avoid clicking suspicious links.",
                    "Always verify email senders.",
                    "Phishing emails often create fake urgency."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Keep your accounts private.",
                    "Avoid sharing sensitive information online.",
                    "Review app permissions regularly."
                }
            },

            {
                "scam",
                new List<string>()
                {
                    "Never send money to strangers online.",
                    "Scammers often pretend to be trusted companies.",
                    "Always verify payment websites."
                }
            }
        };

        public string GetResponse(string input)
        {
            input = input.ToLower();

            // Sentiment Detection
            if (input.Contains("sad") ||
                input.Contains("worried") ||
                input.Contains("scared"))
            {
                return "I'm sorry you're feeling that way. Staying informed helps you stay safe online.";
            }

            // Memory Feature
            if (input.Contains("interested in"))
            {
                rememberedTopic = input.Replace("interested in", "").Trim();

                return $"Great! I'll remember that you're interested in {rememberedTopic}.";
            }

            // Recall Feature
            if (input.Contains("tell me more") ||
                input.Contains("another tip"))
            {
                if (rememberedTopic != "")
                {
                    return $"Since you're interested in {rememberedTopic}, always stay updated on cybersecurity threats.";
                }

                return "Always protect your personal information online.";
            }

            // Keyword Recognition
            foreach (var item in responses)
            {
                if (input.Contains(item.Key))
                {
                    rememberedTopic = item.Key;

                    int index = random.Next(item.Value.Count);

                    return item.Value[index];
                }
            }

            // General Questions
            if (input.Contains("how are you"))
            {
                return "I'm functioning perfectly and ready to help!";
            }

            if (input.Contains("purpose"))
            {
                return "My purpose is to educate users about cybersecurity awareness.";
            }

            if (input.Contains("what can i ask"))
            {
                return "You can ask about passwords, phishing, privacy, scams, and safe browsing.";
            }

            if (input.Contains("hello") || input.Contains("hi"))
            {
                return "Hello! How can I help you today?";
            }

            return GetErrorMessage();
        }

        private string GetErrorMessage()
        {
            List<string> errors = new List<string>()
            {
                "I didn't quite understand that.",
                "Please rephrase your question.",
                "Try asking about cybersecurity topics."
            };

            return errors[random.Next(errors.Count)];
        }
    }
}