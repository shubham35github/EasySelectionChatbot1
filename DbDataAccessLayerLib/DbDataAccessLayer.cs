using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatBotModelLib;
using DataAccessLayerContractLib;
using System.Data.Linq;
using System.Linq.Dynamic;

namespace DbDataAccessLayerLib
{
    public class DbDataAccessLayer : IDataAccessLayerContract
    {
        public Dictionary<int, string> ReadAttributes()
        {
            Dictionary<int, string> FeaturesDictionary = new Dictionary<int, string>();
            using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
            {
                var columnnames = from t in typeof(ChatbotTable_).GetProperties() select t.Name;
                int i = 0;
                foreach (var c in columnnames)
                {
                    FeaturesDictionary.Add(i, c.ToString());
                    i = i + 1;
                }
            }
            return FeaturesDictionary;
        }

        public List<string> ReadData(Dictionary<int, string> FeaturesDictionary, Dictionary<int, string> AnswerDictionary, int QuestionNumber)
        {
            List<string> options = new List<string>();
            using (ChatBotDataModelDataContext dbcontext = new ChatBotDataModelDataContext())
            {
                IQueryable optionsQueryable;
                if (QuestionNumber == 1)
                {
                    optionsQueryable = dbcontext.ChatbotTable_s.Where(FeaturesDictionary[QuestionNumber] + "!=\"" + null + "\"").Select(FeaturesDictionary[QuestionNumber]).Distinct();
                    
                }
                else
                {
                    int feature_no = AnswerDictionary.Keys.Max();
                    optionsQueryable = dbcontext.ChatbotTable_s.Where(FeaturesDictionary[feature_no] + "=\"" + AnswerDictionary[feature_no] + "\"").Where(FeaturesDictionary[QuestionNumber] + "!=\"" + null + "\"").Select(FeaturesDictionary[QuestionNumber]).Distinct();
                }
                foreach (var option in optionsQueryable)
                {
                    options.Add(option.ToString());
                }
                return options;
            }
        }
    }
}
