﻿using System;
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
            easySelectionChatbot.CreateMonitorsDictionary();
            easySelectionChatbot.CreateFeatureDictionary();
            easySelectionChatbot.ReadDatabase(easySelectionChatbot);
           // easySelectionChatbot.DisplayItems("category", "bedside");
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
