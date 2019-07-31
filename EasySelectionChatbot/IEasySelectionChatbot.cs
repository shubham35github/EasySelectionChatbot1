using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySelectionChatbot
{
    public interface IEasySelectionChatbot
    {
        void CreateFeatureDictionary();
        void CreateMonitorsDictionary();
        void ReadDatabase(IEasySelectionChatbot easySelectionChatbot);
        void DisplayItems(string Feature, string FeatureValue);
        void BackPropagation();
    }
}
