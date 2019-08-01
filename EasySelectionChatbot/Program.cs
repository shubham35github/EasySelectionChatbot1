using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySelectionChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            IEasySelectionChatbot easySelectionChatbot = new EasySelectionChatBot();
            IDataInput dataInput = new EasySelectionChatBot();
            Console.WriteLine("---------------------------------WELCOME TO THE INTELLIGENT CHATBOT---------------------------------\n");
            Dictionary<int,string> FeaturesDictionary= easySelectionChatbot.ReadProductAttributes();
            easySelectionChatbot.ProcessChatbotFeatures(easySelectionChatbot,dataInput,FeaturesDictionary);
        }
    }
}
