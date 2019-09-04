using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace ChatBotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            ChatBotProcessorLib.ChatBotProcessor process = container.Resolve<ChatBotProcessorLib.ChatBotProcessor>();
            process.ProcessChatBot();
        }
    }
}
