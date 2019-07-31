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
            IEasySelectionChatbot easySelectionChatbot = new EasySelectionChatbot();
            Dictionary<int,string> FeaturesDictionary= easySelectionChatbot.ReadDatabaseColumns();
            easySelectionChatbot.ProcessChatbotFeatures(easySelectionChatbot, FeaturesDictionary);
            Console.ReadKey();
        }
    }
}
