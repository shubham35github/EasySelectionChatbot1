using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySelectionChatbot
{
    public interface IEasySelectionChatbot
    {
        Dictionary<int ,string> ReadProductAttributes();
        Dictionary<int, string> ProcessChatbotFeatures(IEasySelectionChatbot easySelectionChatbot, IDataInput dataInput,Dictionary<int,string> FeaturesDicionary);
        List<string> SelectItems(string Feature, string FeatureValue);
    }
}
