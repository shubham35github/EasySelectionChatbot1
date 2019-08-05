using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySelectionChatbot
{
    interface IEasySelectionChatbot
    {
        Dictionary<int ,string> ReadProductAttributes();
        Dictionary<int, string> ProcessChatbotFeatures(IDataInput dataInput,Dictionary<int,string> FeaturesDicionary);
        List<string> SelectItems(string Feature, string FeatureValue);
    }
}
