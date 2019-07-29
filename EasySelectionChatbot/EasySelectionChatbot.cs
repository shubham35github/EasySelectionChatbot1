using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace EasySelectionChatbot
{
    class EasySelectionChatbot:IEasySelectionChatbot
    {
        Dictionary<int, string> FeaturesDictionary = new Dictionary<int, string>();


        void IEasySelectionChatbot.CreateFeatureDictionary()
        {
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                var columnnames = from t in typeof(ChatbotTable_).GetProperties() select t.Name;
                int i = 0;
                foreach (var c in columnnames)
                {
                    FeaturesDictionary.Add(i, c.ToString());
                    i = i + 1;
                }

            }
            //      throw new NotImplementedException();
        }

        string IEasySelectionChatbot.ReadDatabase()
        {

            throw new NotImplementedException();
        }

        void IEasySelectionChatbot.DisplayItems(string Feature, string FeatureValue)
        {
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                string pk = "monitors_no";

                //Console.WriteLine(display);
                var linquery = dbcontext.ChatbotTable_s.Where(Feature + "=\"" + FeatureValue + "\"").Select(pk);
                foreach (var c in linquery)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            //throw new NotImplementedException();
        }

        void IEasySelectionChatbot.ResetItems()
        {
            throw new NotImplementedException();
        }

        void IEasySelectionChatbot.AbortApplication()
        {
            throw new NotImplementedException();
        }

        void IEasySelectionChatbot.BackPropagation()
        {
            throw new NotImplementedException();
        }
    }
}
