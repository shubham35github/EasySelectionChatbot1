using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySelectionChatbot
{
    public interface IEasySelectionChatbot
    {
        Dictionary<int ,string> ReadDatabaseColumns();
        Dictionary<int, string> ProcessChatbotFeatures(IEasySelectionChatbot easySelectionChatbot,Dictionary<int,string> FeaturesDictionary);
        List<string> SelectItems(string Feature, string FeatureValue);
        void DisplayItems(List<string> SelectedItems);
        void BackPropagation();
    }
}
