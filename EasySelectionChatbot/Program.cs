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
            Console.WriteLine("------------------------------------------WELCOME TO PHILIPS COMMUNICATION TEAM-------------------------------------------\n");
            Console.WriteLine("Hi there! I am John and today I'm here to help you. Please choose the Option which best describe your Monitors for me to help you better.\n");
            Dictionary<int,string> FeaturesDictionary= easySelectionChatbot.ReadProductAttributes();
            easySelectionChatbot.ProcessChatbotFeatures(dataInput,FeaturesDictionary);
            Console.ReadKey();
        }
    }
}
