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
        string ReadDatabase();
        void DisplayItems(string Feature, string FeatureValue);
        void ResetItems();
        void AbortApplication();
        void BackPropagation();
    }
}
