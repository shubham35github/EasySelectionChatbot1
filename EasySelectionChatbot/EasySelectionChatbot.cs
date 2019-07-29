using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using System.IO;

namespace EasySelectionChatbot
{
    class EasySelectionChatbot:IEasySelectionChatbot
    {
        Dictionary<int, string> FeaturesDictionary = new Dictionary<int, string>();
        Dictionary<int, string> AnswerDictionary = new Dictionary<int, string>();

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

        void IEasySelectionChatbot.ReadDatabase()
        {
            using (ChatbotModalDataContext dbcontext = new ChatbotModalDataContext())
            {
                int feature_no = 1;
                for (int i = 1; i < FeaturesDictionary.Count; i++)
                {
                    int option_choosen = 0;
                    var list = new List<string>();
                    // Console.WriteLine(FeaturesDictionary[i]);
                    if (i == 1)
                    {
                        //string pk = "monitors_no";
                        // string db = FeaturesDictionary[i];
                        //Console.WriteLine(display);
                        //var Options =(from db in dbcontext.ChatbotTable_s
                        //  select db).Distinct();
                        var Options = dbcontext.ChatbotTable_s.Select(FeaturesDictionary[i]).Distinct();
                        //var Options = dbcontext.ChatbotTable_s.Where(FeaturesDictionary[i] + "=\"" + FeatureValue + "\"").Select(pk);
                        //if (Options!=null)

                        //string str = Options.ToString();
                        //Console.WriteLine(Options);
                        
                        if (Options.Count()>0)
                        {
                            foreach (var option in Options)
                            {
                                list.Add(option.ToString());
                            }
                            if (list.Contains("true") || list.Contains("false"))
                            {
                                Console.WriteLine("Do you want {0} :", FeaturesDictionary[i]);
                            }
                            else
                            {
                                Console.WriteLine("Choose the following {0} options:", FeaturesDictionary[i]);
                            }
                            int index = 1;
                            foreach (var option in Options)
                            {
                                Console.Write("{0}: ", index++);
                                Console.WriteLine(option);
                            }
                            Console.Write("{0}: Display Items\n{1}: Start Again\n{2}: Exit\n", index++, index++, index++);
                            option_choosen = Int32.Parse(Console.ReadLine());
                            AnswerDictionary.Add(i, list[option_choosen-1]);
                        }
                        //Console.WriteLine(AnswerDictionary[i]);
                    }
                    else
                    {
                         var Options = dbcontext.ChatbotTable_s.Where(FeaturesDictionary[feature_no] + "=\"" + AnswerDictionary[feature_no] + "\"").Select(FeaturesDictionary[i]).Distinct();
                        if (Options.Count()>0)
                         {
                            foreach (var option in Options)
                            {
                                list.Add(option.ToString());
                            }
                            if (list.Contains("true") || list.Contains("false"))
                            {
                                Console.WriteLine("Do you want {0} :", FeaturesDictionary[i]);
                            }
                            else
                            {
                                Console.WriteLine("Choose the following {0} options:", FeaturesDictionary[i]);
                            }
                            int index = 1;
                            foreach (var option in Options)
                            {
                                Console.Write("{0}: ", index++);
                                Console.WriteLine(option);
                            }
                            Console.Write("{0}: Display Items\n{1}: Start Again\n{2}: Exit\n", index++, index++, index++);
                            option_choosen = Int32.Parse(Console.ReadLine());
                            AnswerDictionary.Add(i, list[option_choosen - 1]);
                            feature_no =i;
                         }

                     }
                   // i = FeaturesDictionary.Count();
                }
            }
                //int feature_no = 1;
            
           // throw new NotImplementedException();
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
